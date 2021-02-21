using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using PullAndClassification.Utils;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;

namespace PullAndClassification
{
    public partial class CheckDiscrepancyForm : MetroForm
    {
        private List<LinkedControls> controls;
        public List<LinkedControls> Controls1 { get => controls; set => controls = value; }


        public CheckDiscrepancyForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());

            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            if (Session.CurrentProject is null)
                SummaryMessageBox("Project not found!", "Error", MessageBoxIcon.Error);
        }
        public void FillFilesDifferances(string destination)
        {
            try
            {
                var filtered = FilterFiles(false, destination, ".rvt");
                var projectFiles = Session.GetDatabaseContext().ProjectFiles.Where(project => project.ProjectId == Session.CurrentProjectId).ToList();

                var leftOuterJoin =
                      from f in filtered
                      join p in projectFiles on f.Path equals p.File into t
                      from p in t.DefaultIfEmpty()
                      select new
                      {
                          Id = f.Path,
                          path = f.Path,
                          //p?.Properties,
                          inDatabase = p != null,
                          inFileSystem = true
                      };
                var rightOuterJoin =
                    from p in projectFiles
                    join f in filtered on p.File equals f.Path into t
                    from f in t.DefaultIfEmpty()
                    select new
                    {
                        Id = p.File,
                        path = f?.Path,
                        //p.Properties,
                        inDatabase = true,
                        inFileSystem = f != null
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
                        x.path,
                        //x.Properties,
                        x.inDatabase,
                        x.inFileSystem
                    }
                    );


                dtFiles.Columns.Add("Id", typeof(string));
                dtFiles.Columns.Add("path", typeof(string));
                dtFiles.Columns.Add("Properties", typeof(string));
                dtFiles.Columns.Add("inDatabase", typeof(bool));
                dtFiles.Columns.Add("inFileSystem", typeof(bool));

                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(t.Id, t.path,/* t.Properties,*/ t.inDatabase, t.inFileSystem);

                }
                dataGridViewFilesDifferances.DataSource = dtFiles;
            }
            catch { }
        }
        private IEnumerable<Temp.FileInfo> FilterFiles(bool withHidden, string sourceLocalFile, string extention)
        {
            try
            {
                ProjectFileNameParser projectFileNameParser = new ProjectFileNameParser(Session.GetDatabaseContext(), Session.CurrentProjectId);

                List<Temp.FileInfo> filesFound = new List<Temp.FileInfo>();

                DirectoryInfo directory = new DirectoryInfo(sourceLocalFile);
                System.IO.FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(file => !file.Directory.FullName.Contains(".svn")).ToArray();

                var filtered = files
                    .Where(f => f.Attributes.HasFlag(FileAttributes.Hidden).Equals(withHidden))
                    .Where(f => Path.GetExtension(f.Name).Equals(extention))
                    .Select(f => new Temp.FileInfo
                    {
                        Name = f.Name,
                        Path = f.FullName,
                        Size = f.Length / 1024,
                        ValidFileStrusture = projectFileNameParser.ValiateFileName(f.Name).success,
                        PathToClassify = projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path

                    }).ToList();
                return filtered;

            }
            catch (Exception ex) { return null; }
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
            
            Session.context.Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem()
                {
                    Text = project.Name,
                    Value = project.Id
                }
                )
            
            );
            if (Session.CurrentProjectId != -1)
            {
                metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
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
                catch (Exception ex)
                {
                    MessageBox.Show(new Form { Size = new Size(600, 800) }, "Please Check project tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MetroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            UpdateSettings();
            Control[]? controls = Controls.Find("Added_", true);
            if (controls.Length > 0)
                Array.ForEach(controls, element => Controls.Remove(element));

            CheckDiscrepancyForm_Load(null, EventArgs.Empty);

        }

        private void UpdateSettings()
        {
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            if (Session.CurrentProject is null)
                SummaryMessageBox("Project not found!", "Error",MessageBoxIcon.Error);
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            UserSetting.setCurrentProjectId(Session.GetDatabaseContext(), Session.CurrentProjectId);
            metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
        }
    }
}
