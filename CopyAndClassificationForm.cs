﻿using System;
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
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
            }
            else
            {
                var classification = Classification.GetInstance();
                selectedFiles.AddRange(selectedFilesForm.GetSelectedFiles());
                string d = destination.Text;
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
            FileInfo[] files = directory.GetFiles("*.*", SearchOption.AllDirectories).Where(file => !file.Directory.FullName.Contains(".svn")).ToArray();
            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
            return filtered;

        }

        private void PandCForm_Load(object sender, EventArgs e)
        {

        }

       

        private void ButtonPullAndPush_Click(object sender, EventArgs e)
        {
            SyncWithSvnForm pullAndPushForm = new SyncWithSvnForm
            {
                Destination = destination.Text
            };
            
            pullAndPushForm.ShowDialog();
        }

    

        private void Source_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(sourceSVN.Text) && string.IsNullOrWhiteSpace(sourceLocalFile.Text))
            //{
            //    e.Cancel = true;
            //    sourceSVN.Focus();
            //    sourceLocalFile.Focus();
            //    errorProviderSource.SetError(sourceLocalFile, "Sources should not be left blank!");
            //    errorProviderSource.SetError(sourceSVN, "Sources should not be left blank!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProviderSource.SetError(sourceLocalFile, "");
            //    errorProviderSource.SetError(sourceSVN, "");
            //}

        }

        private void Destination_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(destination.Text))
            {
                e.Cancel = true;
                destination.Focus();
                errorProviderSource.SetError(destination, "Destination should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSource.SetError(destination, "");
            }

        }
    }
}
