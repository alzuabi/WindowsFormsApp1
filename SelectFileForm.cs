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
            Session.context = new DatabaseContext();
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.context);

            Session.CurrentProject = Session.context.Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
        }
        public void FillFilesDataGridView(IEnumerable<Temp.FileInfo> filtered)
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

            dtFiles.Columns["Selected"].DefaultValue = true;
            foreach (var t in temp)
            {

                dtFiles.Rows.Add(t.Name, t.Size + " KB", t.Selected, t.Path,
                    t.ValidFileStrusture, t.PathToClassify);

            }
            filesDataGridView.DataSource = dtFiles;
            filesDataGridView.Columns["_fullPath"].Visible = false;

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
            Controls1 = new PrepareControls().GetAdditionalControls(
               Session.CurrentProject.ProjectFileNameStructures.ToList(),
               778,
               20,
               60,
               this);

        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
            newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Controls1.Select(linkedControls =>
            {
                string text = "";
                foreach (Tuple<int, Control> tubleControl in linkedControls.LinkedList)

                    switch (tubleControl.Item2)
                    {
                        
                        case DateTimePicker picker:
                            {
                                var projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures.Where(s => s.Id == tubleControl.Item1).FirstOrDefault();
                                if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date.Id))
                                {
                                    text += picker.Value.ToString(projectFileNameStructures.Description);
                                    break;
                                }
                                else if (projectFileNameStructures.NameType.Equals(FNSTypes.fns_date_index.Id))
                                {
                                    text += picker.Value.ToString(projectFileNameStructures.Description)+"_";
                                }
                                break;
                            }
                        default:
                            text += tubleControl.Item2.Text;
                            break;
                    }
                return text;
            }
            ).ToArray());
        }
    }
}
