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
using Classifacation.Service;
using SvnClient;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1
{
    public partial class PandCForm : Form
    {
        bool fromSvn = false;
        public PandCForm()
        {
            InitializeComponent();
        }

        private void Select_Destination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();
           
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destination.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Pull_and_Classification_Click(object sender, EventArgs e)
        {

            var classification = Classification.GetInstance();
            string s;
            string d;
            if (fromSvn)
            {
                Temp temp = new Temp();
                s = sourceSVN.Text;
                d = temp.GetTemporaryDirectory();
                

                Parameters parameters = new Parameters()
                {
                    Cleanup = true,
                    Command = Command.CheckoutUpdate,
                    DeleteUnversioned = true,
                    Message = "Adding new directory for my project",
                    Mkdir = true,
                    Password = null,
                    Path = d,
                    Revert = true,
                    TrustServerCert = true,
                    UpdateBeforeCompleteSync = false,
                    Url = s,
                    Username = null,
                    Verbose = true,

                };
                SvnUtils.CheckoutUpdate(parameters);
                s = d;
            }
            else {
                s = sourceLocalFile.Text;
            }
     
            try
            {
                d = destination.Text;
                DirectoryInfo directory = new DirectoryInfo(s);
                FileInfo[] files = directory.GetFiles();
                //string[] allfiles = Directory.GetFiles(s, "*.*", SearchOption.AllDirectories);
                var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
                foreach (var file in filtered)
                {
                    classification.pullAndClassification(file.FullName, d);
                }
                if (Directory.Exists(s))
                {
                    Directory.Delete(s);
                }
            }
            catch (Exception ex) {

            
            }
        }

        private void svn_CheckedChanged(object sender, EventArgs e)
        {
            selectSourceLocalFile.Visible = false;
            sourceLocalFile.Visible = false;
            selectSourceSVN.Visible = true;
            sourceSVN.Visible = true;
            fromSvn = true;
        }

        private void localFiles_CheckedChanged(object sender, EventArgs e)
        {
            selectSourceLocalFile.Visible = true;
            sourceLocalFile.Visible = true;
            selectSourceSVN.Visible = false;
            sourceSVN.Visible = false;
        }

        private void selectSourceLocalFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = FolderFileSelectDialog.GetFileDialog();
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    sourceLocalFile.Text = openFileDialog.FileName;
            //}

            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceLocalFile.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void selectSourceSvn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceSVN.Text = folderBrowserDialog.SelectedPath;
            }

        }
    }
}
