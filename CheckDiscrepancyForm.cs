using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using PullAndClassification.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;

namespace PullAndClassification
{
    public partial class CheckDiscrepancyForm : MetroForm
    {
        private int indexRow;
        private List<LinkedControls> controls;
        public List<LinkedControls> ListControls { get => controls; set => controls = value; }


        public CheckDiscrepancyForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());

            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
           
            if (Session.CurrentProject is not null && UserSetting.getRootDistinationPath(Session.GetDatabaseContext()) is not null)
                FillFilesDifferances(Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name));
        }
        public void FillFilesDifferances(string destination)
        {
            try
            {
                RemoveFromDB.Visible = false;
                ClassificationButton.Visible = false;
                IEnumerable<Temp.FileInfo>? filtered = FilterFiles(false, Path.Combine(destination), ".rvt");
                List<ProjectFile>? projectFiles = Session.GetDatabaseContext().ProjectFiles.Where(project => project.ProjectId == Session.CurrentProjectId).ToList();

                var leftOuterJoin =
                      from f in filtered
                      join p in projectFiles on Path.GetFullPath(f.Path) equals Path.GetFullPath(p.File) into t
                      from p in t.DefaultIfEmpty()
                      select new 
                      {
                          Id = FormatPath(Path.Combine(f.Path)),

                          inDatabase = p != null,
                          inFileSystem = true,
                      };

                var rightOuterJoin =
                    from p in projectFiles
                    join f in filtered on Path.GetFullPath(p?.File) equals Path.GetFullPath(f?.Path) into t
                    from f in t.DefaultIfEmpty()
                    select new 
                    {
                        Id = FormatPath(Path.Combine(p?.File)),
                       
                        inDatabase = true,
                        inFileSystem = f != null,
                    };
                var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);


                dataGridViewFilesDifferances.MultiSelect = true;
                dataGridViewFilesDifferances.AllowUserToAddRows = false;
                dataGridViewFilesDifferances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataTable dtFiles = new DataTable();
                var temp = fullOuterJoin.Select(
                    x => new
                    {
                        x.Id,

                        x.inDatabase,
                        x.inFileSystem,
                    }
                    );


                dtFiles.Columns.Add("Id", typeof(string));
                dtFiles.Columns.Add("inDatabase", typeof(bool));
                dtFiles.Columns.Add("inFileSystem", typeof(bool));
                dtFiles.Columns.Add("_propertyParts", typeof(object));
                dtFiles.Columns.Add("ClassificationPath", typeof(string));
                dtFiles.Columns.Add("_ProjectFileProperties", typeof(Tuple<int, string>));
                dtFiles.Columns.Add("_fullPath", typeof(string));

                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(Path.Combine(t.Id), t.inDatabase, t.inFileSystem, GetPropertyPartsFromDB(Path.Combine(t.Id)));

                }
                dataGridViewFilesDifferances.DataSource = dtFiles;

                dataGridViewFilesDifferances.Columns["_propertyParts"].Visible = false;
                dataGridViewFilesDifferances.Columns["_ProjectFileProperties"].Visible = false;
                dataGridViewFilesDifferances.Columns["_fullPath"].Visible = false;

                dataGridViewFilesDifferances.Update();

            }
            catch
            {
                dataGridViewFilesDifferances.DataSource = null;
                dataGridViewFilesDifferances.Update();


            }
        }

        private List<PropertyParts> GetPropertyPartsFromDB(string path)
        {

            if (string.IsNullOrEmpty(path))
                return null;

            var ProjectFileId = Session.GetDatabaseContext().ProjectFiles.Where(s => s.File.Equals(path)).Select(s => s.Id).FirstOrDefault();
            List<ProjectFileProperty> temp = Session.GetDatabaseContext().ProjectFileProperties.Where(x => x.ProjectFileId == ProjectFileId)
                .ToList();

            List<PropertyParts> output = temp.ConvertAll(new Converter<ProjectFileProperty, PropertyParts>(ConvertFromProjectFilePropertyToPropertyParts));

            return output;

        }

        private IEnumerable<Temp.FileInfo> FilterFiles(bool withHidden, string sourceLocalFile, string extention)
        {
            try
            {
                ProjectFileNameParser projectFileNameParser = new ProjectFileNameParser(Session.GetDatabaseContext(), Session.CurrentProjectId);

                List<Temp.FileInfo> filesFound = new List<Temp.FileInfo>();

                DirectoryInfo directory = new DirectoryInfo(Path.Combine(sourceLocalFile));
                System.IO.FileInfo[] files = new DirectoryInfo(Path.Combine(sourceLocalFile,PREFEXFolder)).GetFiles("*.*", SearchOption.AllDirectories).Where(file => !file.Directory.FullName.Contains(".svn")).ToArray();

                var filtered = files
                    .Where(f => f.Attributes.HasFlag(FileAttributes.Hidden).Equals(withHidden))
                    .Where(f => Path.GetExtension(f.Name).Equals(extention))
                    .Select(f => new Temp.FileInfo
                    {
                        Name = Path.Combine(f.Name),
                        Path = Uri.UnescapeDataString(Path.Combine(FormatPath(Path.Combine(new Uri(Path.Combine(directory.FullName + "/")).MakeRelativeUri(new Uri(Path.Combine(f.FullName))).ToString())))),
                        Size = f.Length / 1024,
                        ValidFileStrusture = projectFileNameParser.ValiateFileName(Path.Combine(f.Name)).success,
                        PathToClassify = projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path,
                        PropertyParts = projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).propertyParts,
                        ProjectFileProperties = Tuple.Create(Session.CurrentProjectId, projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path)


                    }).ToList();
                return filtered;

            }
            catch (Exception ex) { return new List<Temp.FileInfo>(); }
        }

        private void DataGridViewFilesDifferances_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridViewFilesDifferances.Rows)
                if (!(bool)row.Cells["inDatabase"].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkOrange;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (!(bool)row.Cells["inFileSystem"].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(0, 198, 247);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
        }

        private void CheckDiscrepancyForm_Load(object sender, EventArgs e)
        {
            metroProjectListComboBox.DropDownStyle = ComboBoxStyle.DropDown;

            Session.GetDatabaseContext().Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem()
                {
                    Text = Path.Combine(project.Name),
                    Value = project.Id
                }
                )

            );
            if (Session.CurrentProjectId != -1 && Session.CurrentProject is not null)
            {
                metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
                metroLabelProjectName.Text = Session.CurrentProject.Name;

            }
        }

        private void MetroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            UpdateSettings();
            Control[]? controls = Controls.Find("Added_", true);
            if (controls.Length > 0)
                Array.ForEach(controls, element => Controls.Remove(element));

            if (Session.CurrentProjectId != -1)
            {
                metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
                metroLabelProjectName.Text = Session.CurrentProject.Name;
                try
                {
                    FillFilesDifferances(Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(new Form { Size = new Size(600, 800) }, "Some Data is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void UpdateSettings()
        {
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            if (Session.CurrentProject is null)
                SummaryMessageBox("Project not found!", "Error", MessageBoxIcon.Error);
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            UserSetting.setCurrentProjectId(Session.GetDatabaseContext(), Session.CurrentProjectId);
            metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];
                if ((bool)newDataRow.Cells["inDatabase"].Value == false)
                {
                    foreach (var c in ListControls)
                    {
                        foreach (Tuple<int, Control> tubleControl in c.LinkedList)
                            if (string.IsNullOrEmpty(tubleControl.Item2.Text))
                            {
                                SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                                return;
                            }
                    }
                    List<PropertyParts> propertyParts = new List<PropertyParts>();
                    newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Temp.PREFEXFolder, Path.Combine(ListControls.Select(linkedControls =>
                     {
                         string finalText = "";

                         foreach (Tuple<int, Control> tubleControl in linkedControls.LinkedList)
                         {
                             var projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.Id == tubleControl.Item1).FirstOrDefault();
                             string text = "";
                             //if (!string.IsNullOrEmpty(tubleControl.Item2.Text))
                             //{
                             switch (tubleControl.Item2)
                             {

                                 case DateTimePicker picker:
                                     {
                                         //_properties.Add(projectFileNameStructures.NameType, picker.Value.ToString(projectFileNameStructures.Description));
                                         if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date.Id))
                                         {
                                             text = picker.Value.ToString(projectFileNameStructures.Description);
                                             propertyParts.Add(new PropertyParts()
                                             {
                                                 CreateFolder = projectFileNameStructures.CreateFolder,
                                                 FNSId = projectFileNameStructures.Id,
                                                 FolderOrder = projectFileNameStructures.FolderOrder,
                                                 Name = picker.Value.ToString(projectFileNameStructures.Description),
                                                 NameType = projectFileNameStructures.NameType

                                             });
                                             break;
                                         }
                                         else if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date_index.Id))
                                         {
                                             propertyParts.Add(new PropertyParts()
                                             {
                                                 CreateFolder = projectFileNameStructures.CreateFolder,
                                                 FNSId = projectFileNameStructures.Id,
                                                 FolderOrder = projectFileNameStructures.FolderOrder,
                                                 Name = picker.Value.ToString(projectFileNameStructures.Description),
                                                 NameType = projectFileNameStructures.NameType

                                             });
                                             text = picker.Value.ToString(projectFileNameStructures.Description) + "_";
                                         }
                                         break;
                                     }
                                 default:
                                     //if (_properties.ContainsKey(projectFileNameStructures.NameType))
                                     //    _properties[projectFileNameStructures.NameType] = _properties[projectFileNameStructures.NameType] + "_" + tubleControl.Item2.Text;
                                     //else
                                     //    _properties.Add(projectFileNameStructures.NameType, tubleControl.Item2.Text);
                                     if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date_index.Id))
                                     {
                                         propertyParts.FindLast(s => s.NameType.Equals(projectFileNameStructures.NameType)).Name += "_" + tubleControl.Item2.Text;
                                         text = tubleControl.Item2.Text;
                                         break;
                                     }
                                     else
                                     {
                                         propertyParts.Add(
                                                       new PropertyParts()
                                                       {
                                                           CreateFolder = projectFileNameStructures.CreateFolder,
                                                           FNSId = projectFileNameStructures.Id,
                                                           FolderOrder = projectFileNameStructures.FolderOrder,
                                                           Name = tubleControl.Item2.Text,
                                                           NameType = projectFileNameStructures.NameType
                                                       }
                                                       );
                                         text = tubleControl.Item2.Text;
                                         break;
                                     }
                             }
                             if (projectFileNameStructures.CreateFolder)
                                 finalText += text;
                             //}
                             //else {
                             //    SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                             //}
                         }
                         newDataRow.Cells["_propertyParts"].Value = propertyParts;
                         return finalText;
                     }

                    ).ToArray()));
                    newDataRow.Cells["_ProjectFileProperties"].Value = Tuple.Create(Session.CurrentProjectId, newDataRow.Cells["ClassificationPath"].Value.ToString());

                }
                //Dictionary<string, string> _properties = new Dictionary<string, string>();
                else 
                {
                    foreach (var c in ListControls)
                    {
                        foreach (Tuple<int, Control> tubleControl in c.LinkedList)
                            if (string.IsNullOrEmpty(tubleControl.Item2.Text))
                            {
                                SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                                return;
                            }
                    }
                    List<PropertyParts> propertyParts = new List<PropertyParts>();
                    //newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Controls1.Select(linkedControls =>
                    //{
                    //string finalText = "";
                    for (int i = 0; i < ListControls.Count; i++)
                    {
                        var temp = ListControls[i].LinkedList;
                        if (temp.Count == 1)
                        {
                            using (var db = Session.GetDatabaseContext())
                            {
                                Tuple<int, Control> tubleControl = temp.First();
                                ProjectFileProperty projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl.Item2.Text;
                                    db.SaveChanges();
                                }
                            }
                        }
                        else if (temp.Count == 2)
                        {
                            using (var db = Session.GetDatabaseContext())
                            {
                                Tuple<int, Control> tubleControl1 = temp.First();
                                Tuple<int, Control> tubleControl2 = temp.Last();
                                ProjectFileProperty projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl1.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl1.Item2.Text+"_"+ tubleControl2.Item2.Text;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    foreach (var linkedControls in ListControls)
                    {
                        foreach (Tuple<int, Control> tubleControl in linkedControls.LinkedList)
                        {
                            //var projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.Id == tubleControl.Item1).FirstOrDefault();
                            //string text = "";

                            using (var db = Session.GetDatabaseContext())
                            {
                                ProjectFileProperty projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl.Item2.Text;
                                    db.SaveChanges();
                                }
                            }
                        }
                    }

                }
            }
            catch {
                SummaryMessageBox("Please check the files!", "", MessageBoxIcon.Information);
            }

        }
        private void DataGridViewFilesDifferances_ModifyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Control[]? controls = Controls.Find("Added_", true);
            if (controls.Length > 0)
                Array.ForEach(controls, element => Controls.Remove(element));
            {

                indexRow = e.RowIndex;
                if (e.RowIndex != -1)
                {

                    ClassificationButton.Visible = false;
                    DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];

                    string file = newDataRow.Cells["Id"].Value as string;
                    var id = Session.GetDatabaseContext().ProjectFiles.AsEnumerable().Where(s => Path.GetFullPath(s.File).Equals(Path.GetFullPath(file))).Select(s => s.Id).FirstOrDefault();
                    if (id != 0)
                    {
                        if ((bool)newDataRow.Cells["inFileSystem"].Value == false)
                        {
                            RemoveFromDB.Visible = true;
                        }
                        else
                        {
                            RemoveFromDB.Visible = false;
                        }
                        ListControls = PrepareControls.RenderAndReturnListofLinkedControlsInForm2(this, id);
                        List<PropertyParts> propertyParts = GetPropertyPartsFromDB(file);
                        if (propertyParts.Count > 0)
                        {
                            for (int i = 0; i < propertyParts.Count; i++)
                            {
                                List<Tuple<int, Control>> tuple = GetTupleIntControlerWithId(propertyParts[i].FNSId);
                                if (tuple is not null)
                                    if (tuple.Count == 1)
                                        tuple.First().Item2.Text = propertyParts[i].Name;
                                    else if (tuple.Count == 2)
                                    {
                                        ProjectFileNameStructure? projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.NameType.Equals(FNSTypes.fns_date_index.Id)).FirstOrDefault();
                                        if (projectFileNameStructures is not null)
                                        {
                                            DateTimePicker dateTimePicker = new DateTimePicker
                                            {
                                                Value = DateTime.ParseExact(GetPart(propertyParts[i].Name, "_", 0), projectFileNameStructures.Description, null),
                                                CustomFormat = projectFileNameStructures.Description,
                                                Format = DateTimePickerFormat.Custom
                                            };
                                            tuple[0].Item2.Text = dateTimePicker.Value.ToString();
                                            tuple[1].Item2.Text = GetPart(propertyParts[i].Name, "_", 1);
                                        }
                                    }
                            }
                        }

                    }
                    else
                    {
                        ClassificationButton.Visible = true;
                        ListControls = PrepareControls.RenderAndReturnListofLinkedControlsInForm(this);
                        if (string.IsNullOrEmpty(newDataRow.Cells["ClassificationPath"].Value.ToString()))
                        {

                            foreach (var l in ListControls)
                            {
                                foreach (Tuple<int, Control> tubleControl in l.LinkedList)
                                {
                                    switch (tubleControl.Item2)
                                    {

                                        case ComboBox comboBox:
                                            comboBox.SelectedIndex = comboBox.Items.Count - 1;
                                            break;
                                        case DateTimePicker dateTimePicker:
                                            dateTimePicker.Text = "";
                                            break;
                                        default:
                                            tubleControl.Item2.Text = "";
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            List<PropertyParts> propertyParts = newDataRow.Cells["_propertyParts"].Value as List<PropertyParts>;
                            if (propertyParts.Count > 0)
                            {
                                for (int i = 0; i < propertyParts.Count; i++)
                                {
                                    List<Tuple<int, Control>> tuple = GetTupleIntControlerWithId(propertyParts[i].FNSId);
                                    if (tuple is not null)
                                        if (tuple.Count == 1)
                                            tuple.First().Item2.Text = propertyParts[i].Name;
                                        else if (tuple.Count == 2)
                                        {
                                            ProjectFileNameStructure? projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.NameType.Equals(FNSTypes.fns_date_index.Id)).FirstOrDefault();
                                            if (projectFileNameStructures is not null)
                                            {
                                                DateTimePicker dateTimePicker = new DateTimePicker
                                                {
                                                    Value = DateTime.ParseExact(GetPart(propertyParts[i].Name, "_", 0), projectFileNameStructures.Description, null),
                                                    CustomFormat = projectFileNameStructures.Description,
                                                    Format = DateTimePickerFormat.Custom
                                                };
                                                tuple[0].Item2.Text = dateTimePicker.Value.ToString();
                                                tuple[1].Item2.Text = GetPart(propertyParts[i].Name, "_", 1);
                                            }
                                        }
                                }
                            }
                        }
                    }
                    //}

                    //getClassificationFolderFromProparties()
                    //else
                    //{
                    //    classificationFolder.Visible = true;
                    //    classificationFolderText.Visible = true;
                    //}
                }
            }
        }

        private List<Tuple<int, Control>> GetTupleIntControlerWithId(int fNSId)
        {
            List<Tuple<int, Control>> tuples = new List<Tuple<int, Control>>();
            foreach (LinkedControls linkedControls in ListControls)
            {
                foreach (Tuple<int, Control> tuple in linkedControls.LinkedList)
                {
                    if (tuple.Item1 == fNSId)
                        tuples.Add(tuple);
                }
            }
            return tuples;
        }

        private void metroButtonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Classification_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];
            //  IEnumerable<DataGridViewRow> emptyFileClassificationPath = GetSelectedFiles(FilesDataGridView).Where(s => string.IsNullOrEmpty(s.Cells["ClassificationPath"].Value.ToString()));
            if (string.IsNullOrEmpty(newDataRow.Cells["ClassificationPath"].Value.ToString()))
            {
                SummaryMessageBox("Classificatio path for below files is not valid\n" + newDataRow.Cells["Id"].Value, "Error", MessageBoxIcon.Error);
            }
            else
            {
                var classification = Classification.Service.Classification.GetInstance();

                classification.CopyAndClassification(null,
                     Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name, newDataRow.Cells["Id"].Value.ToString()),
                    Path.Combine(/*UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name, */newDataRow.Cells["ClassificationPath"].Value.ToString()),
                    Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name),
                    false,
                    true);
                Tuple<int, string> _ProjectFileproperties = (Tuple<int, string>)newDataRow.Cells["_ProjectFileProperties"].Value;

                int projectFileId = SaveProjectFile(_ProjectFileproperties, newDataRow.Cells["Id"].Value.ToString());
                SaveProjectFileProperties(projectFileId, newDataRow.Cells["_propertyParts"].Value as List<PropertyParts>/*, row.Cells["_fullPath"].Value.ToString()*/);
                FillFilesDifferances(Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name));


            }
        }

        private void RemoveFromDB_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];
            using var db = Session.GetDatabaseContext();
            var file = newDataRow.Cells["Id"].Value.ToString();
            var row = db.ProjectFiles.AsEnumerable().FirstOrDefault(r => Path.GetFullPath( r.File).Equals(Path.GetFullPath(file)));
            if (row != null)
            {
                
                db.ProjectFiles.Remove(row);
                var projectProps = db.ProjectFileProperties.AsEnumerable().Where(s => s.ProjectFileId == row.Id).ToList();
                if (projectProps is not null)
                {
                    foreach (var r in projectProps)
                        db.ProjectFileProperties.Remove(r);

                    db.SaveChanges();

                }
                db.SaveChanges();
                FillFilesDifferances(Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name));

            }

        }

        private void metroProjectListComboBox_Click(object sender, EventArgs e)
        {
            RefreshComboBox(metroProjectListComboBox);
        }
    }
}
