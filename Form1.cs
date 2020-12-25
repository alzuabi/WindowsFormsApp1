using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Service;

namespace WindowsFormsApp1
{
    public partial class PandCForm : Form
    {
        public PandCForm()
        {
            InitializeComponent();
        }

        private void Select_Source_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.ShowDialog();
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog
            {
                Title = "What to select",
                InitialDirectory = @"c:\"
            };
            if (folderSelectDialog.ShowDialog == DialogResult.OK)
            {
                source.Text = folderSelectDialog.FileName;
            }
        }

        private void Select_Destination_Click(object sender, EventArgs e)
        {
            FolderSelectDialog folderSelectDialog = new FolderSelectDialog
            {
                Title = "What to select",
                InitialDirectory = @"c:\"
            };
            if (folderSelectDialog.ShowDialog == DialogResult.OK)
            {
                destination.Text = folderSelectDialog.FileName;
            }
        }

        private void Pull_and_Classification_Click(object sender, EventArgs e)
        {
//asdads

        }
    }
}
