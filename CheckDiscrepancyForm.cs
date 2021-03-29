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
                metroUpdateProjectButton.Visible = false;
                IEnumerable<Temp.FileInfo>? filtered = FilterFiles(false, Path.Combine(destination), RVTEXT);
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
                DataTable dtFiles = new();
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

            int ProjectFileId = Session.GetDatabaseContext().ProjectFiles.Where(s => s.File.Equals(path)).Select(s => s.Id).FirstOrDefault();
            List<ProjectFileProperty> temp = Session.GetDatabaseContext().ProjectFileProperties.Where(x => x.ProjectFileId == ProjectFileId).ToList();
            List<PropertyParts> output = temp.ConvertAll(new Converter<ProjectFileProperty, PropertyParts>(ConvertFromProjectFilePropertyToPropertyParts));

            return output;

        }

        private IEnumerable<Temp.FileInfo> FilterFiles(bool withHidden, string sourceLocalFile, string extention)
        {
            try
            {
                ProjectFileNameParser projectFileNameParser = new(Session.GetDatabaseContext(), Session.CurrentProjectId);

                List<Temp.FileInfo> filesFound = new();

                DirectoryInfo directory = new(Path.Combine(sourceLocalFile));
                System.IO.FileInfo[] files = new DirectoryInfo(Path.Combine(sourceLocalFile, PREFEXFolder)).GetFiles("*.*", SearchOption.AllDirectories).Where(file => !file.Directory.FullName.Contains(".svn")).ToArray();

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
                    row.DefaultCellStyle.ForeColor = Color.Crimson;
                    row.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.Crimson;
                    
                }
                else if (!(bool)row.Cells["inFileSystem"].Value)
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
                        row.DefaultCellStyle.ForeColor = Color.SaddleBrown;
                    row.DefaultCellStyle.SelectionForeColor = Color.SaddleBrown;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue; ;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
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
                })
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
                    MessageBox.Show(new Form { Size = new Size(600, 800) }, "Some Data is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string tempText = "";
                DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];
                if ((bool)newDataRow.Cells["inDatabase"].Value == false)
                {
                    foreach (var c in ListControls)
                    {
                        foreach (LinkedListNode<Tuple<int, Control, string>> tubleControl in c.LinkedList)
                            if (string.IsNullOrEmpty(tubleControl.Value.Item2.Text))
                            {
                                SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                                return;
                            }
                    }
                    List<PropertyParts> propertyParts = new();
                    newDataRow.Cells["ClassificationPath"].Value = cleanClassificationPath(Path.Combine(UserSetting.getReceptionFolderName(Session.GetDatabaseContext()), Path.Combine(ListControls.Select(linkedControls =>
                    {
                        string finalText = "";
                        LinkedListNode<Tuple<int, Control, string>> last = linkedControls.LinkedList.Last.Value;
                        foreach (LinkedListNode<Tuple<int, Control, string>> tubleControl in linkedControls.LinkedList)
                        {
                            LinkedListNode<Tuple<int, Control, string>> linkedListNode = tubleControl;
                            finalText += proceccUpdate(tubleControl.Value, propertyParts, tempText);
                            if (!tubleControl.Equals(last))
                                finalText += "_";
                            tempText = Path.Combine(tempText, finalText);
                        }
                        newDataRow.Cells["_propertyParts"].Value = propertyParts;
                        return finalText;
                    }).ToArray())));
                    newDataRow.Cells["_ProjectFileProperties"].Value = Tuple.Create(Session.CurrentProjectId, newDataRow.Cells["ClassificationPath"].Value.ToString());
                }
                else
                {
                    foreach (var c in ListControls)
                    {
                        foreach (LinkedListNode<Tuple<int, Control, string>> tubleControl in c.LinkedList)
                            if (string.IsNullOrEmpty(tubleControl.Value.Item2.Text))
                            {
                                SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                                return;
                            }
                    }
                    List<PropertyParts> propertyParts = new();

                    for (int i = 0; i < ListControls.Count; i++)
                    {
                        using var db = Session.GetDatabaseContext();
                        var temp = ListControls[i].LinkedList;
                        switch (temp.Count)
                        {
                            case 1:

                                var p = temp.ToArray();
                                LinkedListNode<Tuple<int, Control, string>> tubleControl1 = p[0];
                                ProjectFileProperty projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl1.Value.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl1.Value.Item2.Text;
                                    db.SaveChanges();
                                }
                                break;

                            case 2:
                                p = temp.ToArray();
                                tubleControl1 = p[0];
                                LinkedListNode<Tuple<int, Control, string>> tubleControl2 = p[1];
                                projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl1.Value.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl1.Value.Item2.Text + "_" + tubleControl2.Value.Item2.Text;
                                    db.SaveChanges();
                                }
                                break;

                            case 3:
                                p = temp.ToArray();

                                tubleControl1 = p[0];
                                tubleControl2 = p[1];
                                LinkedListNode<Tuple<int, Control, string>> tubleControl3 = p[2];
                                projectFileProperty = db.ProjectFileProperties.SingleOrDefault(b => b.Id == tubleControl1.Value.Item1);
                                if (projectFileProperty != null)
                                {
                                    projectFileProperty.Value = tubleControl1.Value.Item2.Text + "_" + tubleControl2.Value.Item2.Text + "_" + (tubleControl3.Value.Item2 as CheckBox).Checked;
                                    db.SaveChanges();
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
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
                    metroUpdateProjectButton.Visible = false;
                    DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];

                    string file = newDataRow.Cells["Id"].Value as string;
                    int id = Session.GetDatabaseContext().ProjectFiles.AsEnumerable().Where(s => Path.GetFullPath(s.File).Equals(Path.GetFullPath(file))).Select(s => s.Id).FirstOrDefault();
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
                        ListControls = PrepareControls.RenderAndReturnListofLinkedControlsInForm(this, id);
                        List<PropertyParts> propertyParts = GetPropertyPartsFromDB(file);
                        if (propertyParts.Count > 0)
                        {
                            for (int i = 0; i < propertyParts.Count; i++)
                            {
                                List<LinkedListNode<Tuple<int, Control, string>>> tuples = GetTupleIntControlerWithId(propertyParts[i].FNSId);
                                if (tuples is not null)
                                    switch (tuples.Count)
                                    {
                                        case 1:

                                            tuples.First().Value.Item2.Text = propertyParts[i].Name;
                                            break;

                                        case 2:

                                            tuples[0].Value.Item2.Text = GetPart2(propertyParts[i].Name, '_', 2);
                                            var temp = GetPart2(propertyParts[i].Name, '_', 1);
                                            if (temp.Contains("True"))
                                                (tuples[1].Value.Item2 as CheckBox).Checked = true;
                                            else if (temp.Contains("False"))
                                                (tuples[1].Value.Item2 as CheckBox).Checked = false;

                                            break;
                                        case 3:

                                            tuples[0].Value.Item2.Text = GetPart2(propertyParts[i].Name, '_', 3);

                                            tuples[1].Value.Item2.Text = GetPart2(propertyParts[i].Name, '_', 2);

                                            temp = GetPart2(propertyParts[i].Name, '_', 1);
                                            if (temp.Contains("True"))
                                                (tuples[2].Value.Item2 as CheckBox).Checked = true;
                                            else if (temp.Contains("False"))
                                                (tuples[2].Value.Item2 as CheckBox).Checked = false;
                                            else
                                                tuples[2].Value.Item2.Text = temp;

                                            break;
                                    };
                            }

                        }

                    }
                    else
                    {
                        ClassificationButton.Visible = true;
                        metroUpdateProjectButton.Visible = true;
                        ListControls = PrepareControls.RenderAndReturnListofLinkedControlsInForm(this);
                        if (string.IsNullOrEmpty(newDataRow.Cells["ClassificationPath"].Value.ToString()))
                        {
                            foreach (var l in ListControls)
                            {
                                foreach (LinkedListNode<Tuple<int, Control, string>> tubleControl in l.LinkedList)
                                {
                                    switch (tubleControl.Value.Item2)
                                    {

                                        case ComboBox comboBox:
                                            comboBox.SelectedIndex = comboBox.Items.Count - 1;
                                            break;
                                        case DateTimePicker dateTimePicker:
                                            dateTimePicker.Text = "";
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
                                    List<LinkedListNode<Tuple<int, Control, string>>> tuple = GetTupleIntControlerWithId(propertyParts[i].FNSId);
                                    if (tuple is not null)
                                        if (tuple.Count == 1)
                                            tuple.First().Value.Item2.Text = propertyParts[i].Name;
                                        else if (tuple.Count == 2)
                                        {
                                            ProjectFileNameStructure? projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.NameType.Equals(FNSTypes.fns_date_index.Id)).FirstOrDefault();
                                            if (projectFileNameStructures is not null)
                                            {
                                                DateTimePicker dateTimePicker = new()
                                                {
                                                    Value = DateTime.ParseExact(GetPart(propertyParts[i].Name, "_", 0), projectFileNameStructures.Description, null),
                                                    CustomFormat = projectFileNameStructures.Description,
                                                    Format = DateTimePickerFormat.Custom
                                                };
                                                tuple[0].Value.Item2.Text = dateTimePicker.Value.ToString();
                                                tuple[1].Value.Item2.Text = GetPart(propertyParts[i].Name, "_", 1);
                                            }
                                        }
                                }
                            }
                        }
                    }

                }
            }
        }

        private List<LinkedListNode<Tuple<int, Control, string>>> GetTupleIntControlerWithId(int fNSId)
        {
            List<LinkedListNode<Tuple<int, Control, string>>> tuples = new();
            foreach (LinkedControls linkedControls in ListControls)
            {
                foreach (LinkedListNode<Tuple<int, Control, string>> tuple in linkedControls.LinkedList)
                {
                    if (tuple.Value.Item1 == fNSId)
                        tuples.Add(tuple);
                }
            }
            return tuples;
        }

        private void MetroButtonFinish_Click(object sender, EventArgs e)
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
                    Path.Combine(newDataRow.Cells["ClassificationPath"].Value.ToString()),
                    Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name),
                    false,
                    true);
                Tuple<int, string> _ProjectFileproperties = (Tuple<int, string>)newDataRow.Cells["_ProjectFileProperties"].Value;

                List<int> projectFileId = SaveProjectFile(_ProjectFileproperties, newDataRow.Cells["Id"].Value.ToString());
                SaveProjectFileProperties(projectFileId, newDataRow.Cells["_propertyParts"].Value as List<PropertyParts>/*, row.Cells["_fullPath"].Value.ToString()*/);
                FillFilesDifferances(Path.Combine(UserSetting.getRootDistinationPath(Session.GetDatabaseContext()), Session.CurrentProject.Name));
            }
        }

        private void RemoveFromDB_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridViewFilesDifferances.Rows[indexRow];
            using var db = Session.GetDatabaseContext();
            var file = newDataRow.Cells["Id"].Value.ToString();
            var row = db.ProjectFiles.AsEnumerable().FirstOrDefault(r => Path.GetFullPath(r.File).Equals(Path.GetFullPath(file)));
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

        private void MetroProjectListComboBox_Click(object sender, EventArgs e)
        {
            RefreshComboBox(metroProjectListComboBox);
        }
        private object cleanClassificationPath(string classificationPath)
        {
            string[] words = classificationPath.Split('\\');
            string[] outPut = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                outPut[i] = words[i].TrimEnd('_');
            }
            return Path.Combine(outPut);

        }
        private string proceccUpdate(Tuple<int, Control, string> tubleControl, List<PropertyParts> propertyParts, string finalText)
        {
            var projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.Id == tubleControl.Item1).FirstOrDefault();
            string text = "";
            switch (tubleControl.Item2)
            {
                case DateTimePicker picker:
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

                default:
                    string n;
                    if (tubleControl.Item2 is CheckBox c)
                        n = c.Checked.ToString();
                    else
                        n = tubleControl.Item2.Text;
                    propertyParts.Add(
                          new PropertyParts()
                          {
                              CreateFolder = projectFileNameStructures.CreateFolder,
                              FNSId = projectFileNameStructures.Id,
                              FolderOrder = projectFileNameStructures.FolderOrder,
                              Name = n,
                              NameType = projectFileNameStructures.NameType
                          }
                          );
                    if (tubleControl.Item2 is CheckBox check)
                        text = check.Checked ? getTempName(finalText) : "";
                    else
                        text = tubleControl.Item2.Text;
                    break;
            }
            if (projectFileNameStructures.CreateFolder)
                return text;
            else
                return "";
        }


        public string getTempName(string finalText)
        {
            string tempDir = "temp_";
            int lastNum = 0;
            try
            {


                string root = UserSetting.getRootDistinationPath(Session.GetDatabaseContext());
                string rec = UserSetting.getReceptionFolderName(Session.GetDatabaseContext());
                string curProjName = Session.CurrentProject.Name;
                string checkDir = Path.Combine(root, curProjName, rec, Path.Combine(finalText));
                string[] dirs = Directory.GetDirectories((Path.GetDirectoryName(checkDir)), new DirectoryInfo(checkDir).Name + tempDir + "*", SearchOption.TopDirectoryOnly);
                if (dirs.Length > 0)
                {
                    foreach (string s in dirs)
                    {
                        int n = getLastNum(s, tempDir);
                        if (n >= lastNum)
                            lastNum = n + 1;
                    }
                }
                return tempDir + lastNum;
            }
            catch
            {
                return tempDir + lastNum;
            }
        }

        public int getLastNum(string checkdir, string tempDir)
        {
            string toBeSearched = tempDir;
            string num = checkdir.Substring(checkdir.IndexOf(toBeSearched) + toBeSearched.Length);
            return int.Parse(num);
        }

    }
}
