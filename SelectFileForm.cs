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
using System.Text;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;
using FileInfo = Utils.Temp.FileInfo;

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

        public List<LinkedControls> ListLinkedControls { get => controls; set => controls = value; }

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
        public void FillFilesDataGridView(IEnumerable<FileInfo> filtered)
        {
            try
            {
                filesDataGridView.MultiSelect = true;
                filesDataGridView.AllowUserToAddRows = false;
                filesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataTable dtFiles = new();
                var temp = filtered.Select(
                    x => new
                    {
                        x.Selected,
                        x.Name,
                        x.ValidFileStrusture,
                        x.PathToClassify,
                        x.Size,
                        x.Path,
                        x.PropertyParts,
                        x.ProjectFileProperties
                    }
                    );

                dtFiles.Columns.Add("Selected", typeof(bool));
                dtFiles.Columns.Add("Name", typeof(string));
                dtFiles.Columns.Add("FileStrusture", typeof(bool));
                dtFiles.Columns.Add("ClassificationPath", typeof(string));
                dtFiles.Columns.Add("Size", typeof(string));
                dtFiles.Columns.Add("_fullPath", typeof(string));
                dtFiles.Columns.Add("_propertyParts", typeof(object));
                dtFiles.Columns.Add("_ProjectFileProperties", typeof(Tuple<int, string>));
                dtFiles.Columns["Selected"].DefaultValue = true;

                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(
                        t.Selected,
                        t.Name,
                        t.ValidFileStrusture,
                        t.ValidFileStrusture ? t.PathToClassify : "",
                        t.Size + " KB",
                        t.Path,
                        t.PropertyParts,
                        t.ProjectFileProperties
                       );

                }

                filesDataGridView.DataSource = dtFiles;
                filesDataGridView.Columns["_fullPath"].Visible = false;
                filesDataGridView.Columns["_propertyParts"].Visible = false;
                filesDataGridView.Columns["_ProjectFileProperties"].Visible = false;
                filesDataGridView.Columns["Selected"].ReadOnly = false;
                filesDataGridView.Columns["Name"].ReadOnly = true;
                filesDataGridView.Columns["FileStrusture"].ReadOnly = true;
                filesDataGridView.Columns["Size"].ReadOnly = true;
                filesDataGridView.Columns["_fullPath"].ReadOnly = true;
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
                try
                {
                    DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
                    List<PropertyParts> propertyParts = newDataRow.Cells["_propertyParts"].Value as List<PropertyParts>;
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
                                        tuples[0].Value.Item2.Text = propertyParts[i].Name;
                                        int j = ++i;
                                        if (propertyParts[j].Name.Contains("True"))
                                            (tuples[1].Value.Item2 as CheckBox).Checked = true;
                                        else if (propertyParts[j].Name.Contains("False"))
                                            (tuples[1].Value.Item2 as CheckBox).Checked = false;
                                        break;

                                    case 3:
                                        tuples[0].Value.Item2.Text = GetPart2(propertyParts[i].Name, '_', 3);

                                        tuples[1].Value.Item2.Text = propertyParts[++i].Name;
                                        j = ++i;
                                        if (propertyParts[j].Name.Contains("True"))
                                            (tuples[2].Value.Item2 as CheckBox).Checked = true;
                                        else if (propertyParts[j].Name.Contains("False"))
                                            (tuples[2].Value.Item2 as CheckBox).Checked = false;
                                        else
                                            tuples[2].Value.Item2.Text = propertyParts[j].Name;

                                        break;
                                }
                        }
                    }
                    else
                        FillDefault(ListLinkedControls);
                    
                }
                catch
                {
                    FillDefault(ListLinkedControls);
                }
            }
        }

        private void FillDefault(List<LinkedControls> listLinkedControls)
        {
            foreach (var l in listLinkedControls)
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
                        case CheckBox checkBox:
                            checkBox.Text = "temp";
                            checkBox.Checked = false;
                            break;
                        case MetroFramework.Controls.MetroTextBox text:
                            if (text.ReadOnly)
                                tubleControl.Value.Item2.Text = textMach;
                            break;
                        default:
                            tubleControl.Value.Item2.Text = "";
                            break;
                    }
                }
            }
        }

        private List<LinkedListNode<Tuple<int, Control, string>>> GetTupleIntControlerWithId(int fNSId)
        {
            List<LinkedListNode<Tuple<int, Control, string>>> tuples = new();
            foreach (LinkedControls linkedControls in ListLinkedControls)
            {
                foreach (LinkedListNode<Tuple<int, Control, string>> tuple in linkedControls.LinkedList)
                {
                    if (tuple.Value.Item1 == fNSId)
                        tuples.Add(tuple);
                }
            }
            return tuples;
        }

        public List<DataGridViewRow> GetSelectedFiles(DataGridView dataGridView) => 
            dataGridView.Rows.OfType<DataGridViewRow>()
            .Where(s => s.Cells["Selected"].Value.Equals(true))
            .ToList();


        private void Classification_Click(object sender, EventArgs e)
        {
            if (GetSelectedFiles(FilesDataGridView).Count == 0)
                SummaryMessageBox("Please check the files", "", MessageBoxIcon.Information);
            else
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
        }


        private void FilesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in FilesDataGridView.Rows)
            {
                if (!(bool)row.Cells["fileStrusture"].Value)
                {
                    row.DefaultCellStyle.ForeColor = Color.Crimson;
                    row.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.Crimson;
                }

                //else
                //{
                //    row.DefaultCellStyle.BackColor = Color.White;
                //    row.DefaultCellStyle.ForeColor = Color.Black;
                //}
            }
        }


        private void SelectFileForm_Load(object sender, EventArgs e)
        {
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            try
            {
                ListLinkedControls = PrepareControls.RenderAndReturnListofLinkedControlsInForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form { Size = new Size(600, 800) }, "Please Check project tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                string tempText = "";
                DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
                foreach (var c in ListLinkedControls)
                {
                    foreach (LinkedListNode<Tuple<int, Control, string>> tubleControl in c.LinkedList)
                        if (string.IsNullOrEmpty(tubleControl.Value.Item2.Text) && tubleControl.Value.Item2 is not CheckBox)
                        {
                            SummaryMessageBox("Please fill all feilds!", "", MessageBoxIcon.Error);
                            return;
                        }
                }
                List<PropertyParts> propertyParts = new();
                newDataRow.Cells["ClassificationPath"].Value =
                    cleanClassificationPath(Path.Combine(UserSetting.getReceptionFolderName(Session.GetDatabaseContext()),
                    Path.Combine(ListLinkedControls.Select(linkedControls =>
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
            catch (Exception ex)
            {
                SummaryMessageBox("Please check the files!", "Error", MessageBoxIcon.Information);
            }
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

        private string proceccUpdate(Tuple<int, Control, string> tubleControl, List<PropertyParts> propertyParts, string tempText)
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
                        text = check.Checked ? getTempName(tempText) : "";
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
                string checkdir = Path.Combine(root, curProjName, rec, Path.Combine(finalText));
                string[] dirs = Directory.GetDirectories((Path.GetDirectoryName(checkdir)), new DirectoryInfo(checkdir).Name + tempDir + "*", SearchOption.TopDirectoryOnly);
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

        private bool tempIsexist(string checkdir, string tempDir)
        {
            return Directory.EnumerateDirectories(Path.GetDirectoryName(checkdir), new DirectoryInfo(checkdir).Name + tempDir + "*").Any();

        }

        private void MetroButtonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
