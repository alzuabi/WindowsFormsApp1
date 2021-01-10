using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullAndClassification.Forms
{
    public partial class SelectFileForm : Form
    {
        public SelectFileForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        public void FillFilesDataGridView(IEnumerable<System.IO.FileInfo> filtered)
        {
            filesDataGridView.MultiSelect = true;
            filesDataGridView.AllowUserToAddRows = false;
            filesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dtFiles = new DataTable();
            var temp = filtered.Select(
                x => new
                {
                    x.FullName,
                    x.Name,
                    x.Length
                    //, x.LastWriteTime 
                }
                );

            //DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            //{
            //    ValueType = typeof(bool),
            //    Name = "checkBox",
            //    HeaderText = "Selected",
            //};

            dtFiles.Columns.Add("Name", typeof(string));
            dtFiles.Columns.Add("Size", typeof(string));
            dtFiles.Columns.Add("Selected", typeof(bool));
            dtFiles.Columns.Add("_fullPath", typeof(string));

            dtFiles.Columns["Selected"].DefaultValue = true;
            //dtFiles.Columns.Add("LastWriteTime", typeof(DateTime));
            foreach (var t in temp)
            {

                dtFiles.Rows.Add(t.Name, (t.Length / 1024) + " KB", true, t.FullName
                    //,t.LastWriteTime
                    );

            }


            filesDataGridView.DataSource = dtFiles;
            //checkBoxColumn.Selected = true;

            //checkBoxColumn.TrueValue = true;
            //filesDataGridView.Columns.Add(checkBoxColumn);

            filesDataGridView.Columns["_fullPath"].Visible = false;

            //for (int i = 0; i < filesDataGridView.Rows.Count; i++)
            //{
            //    filesDataGridView.Rows[i].Cells[2].Value = true;
            //    Console.WriteLine(filesDataGridView.Rows[i].Cells[2].Value);
            //    Console.WriteLine("-------------------------------------------------");
            //}
            //filesDataGridView.ReadOnly = false;
            //filesDataGridView.Enabled = true;
            //foreach (DataGridViewRow row in filesDataGridView.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
            //    chk.Value = true;
            //    Console.WriteLine(chk.Value);
            //    Console.WriteLine("-------------------------------------------------");
            //}

            //checkBoxColumn.Selected = true;

        }
        public List<string> GetSelectedFiles()
        {
            return filesDataGridView.Rows.OfType<DataGridViewRow>()
                .Where(s => s.Cells["Selected"].Value.Equals(true))
                .Select(s => s.Cells["_fullPath"].Value.ToString())
                .ToList();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonSelectedFilesOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
