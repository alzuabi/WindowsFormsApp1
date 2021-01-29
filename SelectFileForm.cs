using MetroFramework.Controls;
using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using PullAndClassification.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;

namespace PullAndClassification.Forms
{
    public partial class SelectFileForm : MetroForm
    {
        private int indexRow;
        //private static Random random = new Random();
        private CopyAndClassificationForm copyAndClassificationForm;
        private List<MetroTextBox> controls;
        public CopyAndClassificationForm CopyAndClassificationForm
        {
            get { return copyAndClassificationForm; }
            set { copyAndClassificationForm = value; }
        }

        public List<MetroTextBox> Controls1 { get => controls; set => controls = value; }

        public SelectFileForm(int currentProjectId = -1)
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.context = new DatabaseContext();
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.context);
            //if (currentProjectId == -1)
            //    Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.context);
            //else
            //    Session.CurrentProjectId = currentProjectId;

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

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //filesDataGridView.Columns.
            //filesDataGridView.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Modify";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

        }
        private void FilesDataGridView_ModifyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            //FileStructure fileStructure = new FileStructure().GetFileStructure();

            //metroProjectNameTextBox.Text = fileStructure.ProjectName;
            //metroLotTextBox.Text = fileStructure.Lot;
            //metroProjectDateTime.Value = fileStructure.Date;
            //metroIndexTextBox.Text = fileStructure.Index.ToString();

            indexRow = e.RowIndex;

            //FileStructureForm fileStructureForm = new FileStructureForm(new FileStructure(), e.RowIndex);
            //fileStructureForm.ShowDialog();
            //MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
        }
        public List<DataGridViewRow> GetSelectedFiles(DataGridView dataGridView) => dataGridView.Rows.OfType<DataGridViewRow>()
                .Where(s => s.Cells["Selected"].Value.Equals(true))
                //.Select(s => s.Cells["_fullPath"].Value.ToString())
                .ToList();


        private void ButtonSelectedFilesOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Classification_Click(object sender, EventArgs e)
        {
            classificationProgressBar.Visible = true;
            CopyAndClassify(
                true,
                this,
                copyAndClassificationForm.Destination.Text,
                copyAndClassificationForm.FromSvn,
                copyAndClassificationForm.UserNameTextBox1.Text,
                copyAndClassificationForm.PasswordTestBox1.Text,
                copyAndClassificationForm.MetroSourceSVNTextBox.Text,
                copyAndClassificationForm.SourceLocalFile.Text
                );

            //Db.context.LOTs.ToList().ForEach(r => Console.WriteLine(r.ToString()));
            //context.Projects.ToList().ForEach(r => Console.WriteLine(r.ToString()));

        }
        //public bool CheckFileStructure(string fileName)
        //{
        //    return NextBoolean();
        //}
        //public bool NextBoolean()
        //{

        //    return random.Next(0, 2) > 0;
        //}
        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();
        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(Handle, 0x112, 0xf012, 0);
        //}

        private void FilesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
            foreach (DataGridViewRow row in FilesDataGridView.Rows)
                if (!(bool)row.Cells["fileStrusture"].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.MediumVioletRed;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
        }

        private void MetroUpdateProjectButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = filesDataGridView.Rows[indexRow];
            newDataRow.Cells["ClassificationPath"].Value = Path.Combine(Controls1.Select(c => c.Text).ToArray());
            //newDataRow.Cells["Name"].Value = metroProjectNameTextBox.Text + metroLotTextBox.Text + metroProjectDateTime.Value + metroIndexTextBox.Text;
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
            //controls.ForEach(c => Controls.Add(c));
        }
    }
}
