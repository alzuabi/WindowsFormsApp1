using Classification.Utils;
using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using PullAndClassification.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;

namespace PullAndClassification.Forms
{
    public partial class SelectFileForm : MetroForm
    {
        private int indexRow;
        private CopyAndClassificationForm copyAndClassificationForm;
        private List<LinkedControls> controls;
        public CopyAndClassificationForm CopyAndClassificationForm
        {
            get { return copyAndClassificationForm; }
            set { copyAndClassificationForm = value; }
        }

        public List<LinkedControls> Controls1 { get => controls; set => controls = value; }

        public SelectFileForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());

            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            if (Session.CurrentProject is null)
                SummaryMessageBox("Project not found!", "Error", MessageBoxIcon.Error);
        }
        public void FillFilesDataGridView(IEnumerable<Temp.FileInfo> filtered)
        {
            try
            {
                filesDataGridView.MultiSelect = true;
                filesDataGridView.AllowUserToAddRows = false;
                filesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataTable dtFiles = new DataTable();
                var temp = filtered.Select(
                    x => new
                    {

                        x.Name,
                        x.Size,
                        x.Selected,
                        x.Path,
                        x.ValidFileStrusture,
                        x.PathToClassify,
                        x.PropertyParts,
                        x.ProjectFileProperties
                    }
                    );


                dtFiles.Columns.Add("Name", typeof(string));
                dtFiles.Columns.Add("Size", typeof(string));
                dtFiles.Columns.Add("Selected", typeof(bool));
                dtFiles.Columns.Add("_fullPath", typeof(string));
                dtFiles.Columns.Add("FileStrusture", typeof(bool));
                dtFiles.Columns.Add("ClassificationPath", typeof(string));
                dtFiles.Columns.Add("_propertyParts", typeof(object));
                dtFiles.Columns.Add("_ProjectFileProperties", typeof(Tuple<int, string>));

                dtFiles.Columns["Selected"].DefaultValue = true;
                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(
                        t.Name,
                        t.Size + " KB",
                        t.Selected,
                        t.Path,
                        t.ValidFileStrusture,
                        t.ValidFileStrusture ? t.PathToClassify : "",
                        t.PropertyParts,
                        t.ProjectFileProperties
                       );

                }

                filesDataGridView.DataSource = dtFiles;
                filesDataGridView.Columns["_fullPath"].Visible = false;
                filesDataGridView.Columns["_propertyParts"].Visible = false;
                filesDataGridView.Columns["_ProjectFileProperties"].Visible = false;


                filesDataGridView.Columns["Name"].ReadOnly = true;
                filesDataGridView.Columns["Size"].ReadOnly = true;
                filesDataGridView.Columns["Selected"].ReadOnly = false;
                filesDataGridView.Columns["_fullPath"].ReadOnly = true;
                filesDataGridView.Columns["FileStrusture"].ReadOnly = true;
                filesDataGridView.Columns["ClassificationPath"].ReadOnly = true;
                filesDataGridView.Columns["_propertyParts"].ReadOnly = true;
                filesDataGridView.Columns["_ProjectFileProperties"].ReadOnly = true;

            }
            catch { }

        }
        private void FilesDataGridView_ModifyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            if (e.RowIndex != -1)
            {

                DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
                List<PropertyParts> propertyParts = newDataRow.Cells["_propertyParts"].Value as List<PropertyParts>;
                if (propertyParts.Count > 0)
                {
                    for (int i = 0; i < propertyParts.Count; i++)
                    {
                        List<Tuple<int, Control>> tuple = GetTupleIntControlerWithId(propertyParts[i].FNSId);
                        if (tuple is not null)
                            if (tuple.Count == 1)
                                tuple.First().Item2.Text = propertyParts[i].Name;
                            else
                            {
                                tuple[0].Item2.Text = propertyParts[i].Name.Split('_')[0]; ;
                                tuple[1].Item2.Text = propertyParts[+i].Name.Split('_')[1];
                            }
                    }
                }
                else
                {
                    foreach (var l in Controls1)
                    {
                        foreach (Tuple<int, Control> tubleControl in l.LinkedList)
                        {
                            switch (tubleControl.Item2)
                            {

                                case ComboBox comboBox:
                                    comboBox.SelectedIndex = comboBox.Items.Count-1;
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
            }
        }

        private List<Tuple<int, Control>> GetTupleIntControlerWithId(int fNSId)
        {
            List<Tuple<int, Control>> tuples = new List<Tuple<int, Control>>();
            foreach (LinkedControls linkedControls in Controls1)
            {
                foreach (Tuple<int, Control> tuple in linkedControls.LinkedList)
                {
                    if (tuple.Item1 == fNSId)
                        tuples.Add(tuple);
                }
            }
            return tuples;
        }

        public List<DataGridViewRow> GetSelectedFiles(DataGridView dataGridView) => dataGridView.Rows.OfType<DataGridViewRow>()
        .Where(s => s.Cells["Selected"].Value.Equals(true))
        .ToList();


        private void Classification_Click(object sender, EventArgs e)
        {
            IEnumerable<DataGridViewRow> emptyFileClassificationPath = GetSelectedFiles(FilesDataGridView).Where(s => string.IsNullOrEmpty(s.Cells["ClassificationPath"].Value.ToString()));
            if (emptyFileClassificationPath.Count() > 0)
            {
                SummaryMessageBox("Classificatio path for below files is not valid\n" + string.Join(Environment.NewLine, emptyFileClassificationPath.Select(s => s.Cells["Name"].Value)), "Error", MessageBoxIcon.Error);
            }
            else
            {
                classificationProgressBar.Visible = true;
                List<string> summary = CopyAndClassify(
                    true,
                    this,
                    copyAndClassificationForm.Destination.Text,
                    copyAndClassificationForm.FromSvn,
                    copyAndClassificationForm.UserNameTextBox1.Text,
                    copyAndClassificationForm.PasswordTestBox1.Text,
                    copyAndClassificationForm.MetroSourceSVNTextBox.Text,
                    copyAndClassificationForm.SourceLocalFile.Text
                    );
                SummaryMessageBox(summary.Aggregate(new StringBuilder(),
                                                   (sb, val) => sb.AppendLine(val),
                                                   sb => sb.ToString()), "Summary", MessageBoxIcon.Information);
            }
        }


        private void FilesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in FilesDataGridView.Rows)
            {
                if ((bool)row.Cells["fileStrusture"].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(0, 198, 247);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
              
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }


        private void SelectFileForm_Load(object sender, EventArgs e)
        {
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            try
            {
                Controls1 = PrepareControls.RenderAndReturnListofLinkedControlsInForm(this);
                //Controls1 = new PrepareControls().GetAdditionalControls(
                //   Session.CurrentProject.ProjectFileNameStructures.ToList(),
                //   778,
                //   20,
                //   60,
                //   this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form { Size = new Size(600, 800) }, "Please Check project tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
            //Dictionary<string, string> _properties = new Dictionary<string, string>();
            foreach (var c in Controls1)
            {
                foreach (Tuple<int, Control> tubleControl in c.LinkedList)
                    if (string.IsNullOrEmpty(tubleControl.Item2.Text))
                    {
                        SummaryMessageBox("Please fill all feilds!", "Error", MessageBoxIcon.Error);
                        return;
                    }
            }
                List<PropertyParts> propertyParts = new List<PropertyParts>();
            newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Controls1.Select(linkedControls =>
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

            ).ToArray());
            newDataRow.Cells["_ProjectFileProperties"].Value = Tuple.Create(Session.CurrentProjectId, newDataRow.Cells["ClassificationPath"].Value.ToString());
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            //CheckDiscrepancyForm checkForm = new CheckDiscrepancyForm();
            //checkForm.FillFilesDifferances(copyAndClassificationForm.Destination.Text);
            //checkForm.ShowDialog();
        }

        private void metroButtonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
