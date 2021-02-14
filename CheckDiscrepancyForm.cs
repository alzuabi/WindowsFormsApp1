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

namespace PullAndClassification
{
    public partial class CheckDiscrepancyForm : MetroForm
    {
        public CheckDiscrepancyForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
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
                          p?.Properties,
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
                        p.Properties,
                        inDatabase = true,
                        inFileSystem = f != null
                    };
                var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);

                //var query = filtered.LeftOuterJoin(
                //    projectFiles,
                //    lft => lft.Path,
                //    rgt => rgt.File,
                //    (lft, rgt) => new ProjectFile
                //    {
                //        File = lft.Path,
                //        Properties = rgt.Properties == null ? "" : rgt.Properties,

                //    }
                //    );

                dataGridViewFilesDifferances.MultiSelect = true;
                dataGridViewFilesDifferances.AllowUserToAddRows = false;
                dataGridViewFilesDifferances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataTable dtFiles = new DataTable();
                var temp = fullOuterJoin.Select(
                    x => new
                    {
                        x.Id,
                        x.path,
                        x.Properties,
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

                    dtFiles.Rows.Add(t.Id, t.path,t.Properties,t.inDatabase,t.inFileSystem);

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
                FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(file => !file.Directory.FullName.Contains(".svn")).ToArray();

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
    }
}
