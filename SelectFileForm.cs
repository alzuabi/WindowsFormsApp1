using Classification.Utils;
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
            //Session.context = new DatabaseContext();
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());

            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
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
                        x.Path,
                        x.Name,
                        x.Size,
                        x.Selected,
                        x.ValidFileStrusture,
                        x.PathToClassify
                    }
                    );


                dtFiles.Columns.Add("Name", typeof(string));
                dtFiles.Columns.Add("Size", typeof(string));
                dtFiles.Columns.Add("Selected", typeof(bool));
                dtFiles.Columns.Add("_fullPath", typeof(string));
                dtFiles.Columns.Add("FileStrusture", typeof(bool));
                dtFiles.Columns.Add("ClassificationPath", typeof(string));
                dtFiles.Columns.Add("_ProjectFileProperties", typeof(Tuple<int, string, Dictionary<string,string>>));

                dtFiles.Columns["Selected"].DefaultValue = true;
                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(t.Name, t.Size + " KB", t.Selected, t.Path,
                        t.ValidFileStrusture,
                        t.ValidFileStrusture ? t.PathToClassify:""
                       );

                }
                filesDataGridView.DataSource = dtFiles;
                filesDataGridView.Columns["_fullPath"].Visible = false;
                filesDataGridView.Columns["_ProjectFileProperties"].Visible = false;
                filesDataGridView.Columns["Name"].ReadOnly = true;
                filesDataGridView.Columns["Size"].ReadOnly = true;
                filesDataGridView.Columns["Selected"].ReadOnly = false;
                filesDataGridView.Columns["_fullPath"].ReadOnly = true;
                filesDataGridView.Columns["FileStrusture"].ReadOnly = true;
                filesDataGridView.Columns["ClassificationPath"].ReadOnly = true;
                filesDataGridView.Columns["_ProjectFileProperties"].ReadOnly = true;

            }
            catch { }

        }
        private void FilesDataGridView_ModifyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
        }

        public List<DataGridViewRow> GetSelectedFiles(DataGridView dataGridView) => dataGridView.Rows.OfType<DataGridViewRow>()
                .Where(s => s.Cells["Selected"].Value.Equals(true))
                .ToList();


        private void Classification_Click(object sender, EventArgs e)
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
                                                   sb => sb.ToString()), "Summary");
            }
        public void SummaryMessageBox(string message, string caption)
        {
            MessageBox.Show(new Form { Size = new Size(600, 800) }, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void FilesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in FilesDataGridView.Rows)
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



        private void SelectFileForm_Load(object sender, EventArgs e)
        {
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            try
            {
                Controls1 = new PrepareControls().GetAdditionalControls(
                   Session.CurrentProject.ProjectFileNameStructures.ToList(),
                   778,
                   20,
                   60,
                   this);
            }
            catch(Exception ex)
                {
                MessageBox.Show(new Form { Size = new Size(600, 800) }, "Please Check project tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
            //Tuple<int, string, Dictionary<string, string>> _ProjectFileproperties;
            Dictionary<string, string> _properties = new Dictionary<string, string>();

            newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Controls1.Select(linkedControls =>
            {
                string text = "";
                foreach (Tuple<int, Control> tubleControl in linkedControls.LinkedList)
                {
                    var projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.Id == tubleControl.Item1).FirstOrDefault();


                   

                    switch (tubleControl.Item2)
                    {

                        case DateTimePicker picker:
                            {
                                _properties.Add(projectFileNameStructures.NameType, picker.Value.ToString(projectFileNameStructures.Description));
                                if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date.Id))
                                {
                                    text += picker.Value.ToString(projectFileNameStructures.Description);
                                    break;
                                }
                                else if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date_index.Id))
                                {
                                    text += picker.Value.ToString(projectFileNameStructures.Description) + "_";
                                }
                                break;
                            }
                        default:
                            if (_properties.ContainsKey(projectFileNameStructures.NameType))
                                _properties[projectFileNameStructures.NameType] = _properties[projectFileNameStructures.NameType] + "_" + tubleControl.Item2.Text;
                            else
                                _properties.Add(projectFileNameStructures.NameType, tubleControl.Item2.Text);

                            text += tubleControl.Item2.Text;
                            break;
                    }
                }

                return text;
            }
            ).ToArray());
            newDataRow.Cells["_ProjectFileProperties"].Value = Tuple.Create <int, string, Dictionary< string,string>> (Session.CurrentProjectId, newDataRow.Cells["ClassificationPath"].Value.ToString(), _properties);
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            CheckDiscrepancyForm checkForm = new CheckDiscrepancyForm();
            checkForm.FillFilesDifferances(copyAndClassificationForm.Destination.Text);
            checkForm.ShowDialog();
        }
    }
}
