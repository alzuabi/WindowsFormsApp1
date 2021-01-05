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
using PullAndClassificationForm;
using SvnClient;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1
{
    public partial class PandCForm : Form
    {
        private readonly SelectFilesForm selectedFilesForm = new SelectFilesForm();
        public List<string> selectedFiles = new List<string>();
        static string global_dest;
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

        private void Copy_and_Classification_Click(object sender, EventArgs e)
        {

            var classification = Classification.GetInstance();
            //var filtered = GetFilesWithoutHidden(fromSvn, sourceSVN.Text, sourceLocalFile.Text);
            selectedFiles.AddRange(selectedFilesForm.GetSelectedFiles());
            string d = destination.Text;
            Temp.CloneDirectory(global_dest + "/.svn", d+"/.svn");
            try
            {
                    
                foreach (var file in selectedFiles)
                {
                    classification.pullAndClassification(file, d);
                }
                //if (Directory.Exists(s))
                //{
                //    Directory.Delete(s);
                //}
            }
            catch (Exception)
            {

            
            }
        }

        private void Svn_CheckedChanged(object sender, EventArgs e)
        {
            selectSourceLocalFile.Visible = false;
            sourceLocalFile.Visible = false;
            SVNconf.Visible = true;
            fromSvn = true;
        }

        private void LocalFiles_CheckedChanged(object sender, EventArgs e)
        {
            selectSourceLocalFile.Visible = true;
            sourceLocalFile.Visible = true;
            SVNconf.Visible = false;
            fromSvn = false;
        }

        private void SelectSourceLocalFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceLocalFile.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void SelectFiles_Click(object sender, EventArgs e)
        {
            var filtered = GetFilesWithoutHidden(fromSvn, sourceSVN.Text, sourceLocalFile.Text);
            
            selectedFilesForm.FillFilesDataGridView(filtered);
            selectedFilesForm.ShowDialog();
        }


        private IEnumerable<FileInfo> GetFilesWithoutHidden(bool fromSvn, string sourceSVN, string sourceLocalFile) {
            string s;
            string d;
            if (fromSvn)
            {
                Temp temp = new Temp();
                s = sourceSVN;
                d = temp.GetTemporaryDirectory();
                global_dest = d;

                Parameters parameters = new Parameters()
                {
                    Cleanup = true,
                    Command = Command.CheckoutUpdate,
                    DeleteUnversioned = true,
                    Message = "Adding new directory for my project",
                    Mkdir = true,
                    Password = PasswordTestBox1.Text != "" ? PasswordTestBox1.Text : null,
                    Path = d,
                    Revert = true,
                    TrustServerCert = true,
                    UpdateBeforeCompleteSync = false,
                    Url = s,
                    Username = UserNameTextBox1.Text == "" ? null : UserNameTextBox1.Text,
                    Verbose = true,

                };
                SvnUtils.CheckoutUpdate(parameters);
                s = d;
            }
            else
            {
                s = sourceLocalFile;
            }
            DirectoryInfo directory = new DirectoryInfo(s);
            FileInfo[] files = directory.GetFiles();
            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
            return filtered;

        }

        private void PandCForm_Load(object sender, EventArgs e)
        {

        }

        private void PushToSvn_Click(object sender, EventArgs e)
        {
            Parameters parameters = new Parameters()
            {
                Cleanup = true,
                Command = Command.CompleteSync,
                DeleteUnversioned = true,
                Message = "Adding new directory for my project",
                Mkdir = true,
                Password = PasswordTestBox2.Text == "" ? null : PasswordTestBox2.Text,
                Path = destination.Text,
                Revert = true,
                TrustServerCert = true,
                UpdateBeforeCompleteSync = false,
                //Url = dsetSvn.Text,
                Username = UserNameTextBox2.Text == "" ? null : UserNameTextBox2.Text,
                Verbose = true,

            };
            SvnUtils.CompleteSync(parameters);
        }
    }
}
