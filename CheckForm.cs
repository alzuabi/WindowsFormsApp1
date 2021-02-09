using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PullAndClassification
{
    public partial class CheckForm : MetroForm
    {
        public CheckForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
        }
        public void FillFilesDifferances(IQueryable<MULTISYSDbContext.Models.ProjectFile> queryables) {
            try
            {
                dataGridViewFilesDifferances.MultiSelect = true;
                dataGridViewFilesDifferances.AllowUserToAddRows = false;
                dataGridViewFilesDifferances.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataTable dtFiles = new DataTable();
                var temp = queryables.Select(
                    x => new
                    {
                        x.File,
                        x.Properties
                    }
                    );


                dtFiles.Columns.Add("File", typeof(string));
                dtFiles.Columns.Add("Properties", typeof(string));
               
                foreach (var t in temp)
                {

                    dtFiles.Rows.Add(t.File, t.Properties);

                }
                dataGridViewFilesDifferances.DataSource = dtFiles;
            }
            catch { }
        }
    }
}
