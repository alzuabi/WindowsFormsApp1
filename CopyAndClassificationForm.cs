using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using PullAndClassification.Utils;
using SharpSvn;
using Utils;
using static Utils.Temp;

namespace PullAndClassification.Forms
{
    public partial class CopyAndClassificationForm : MetroForm
    {
        private BackgroundWorker bgw = new BackgroundWorker();

        private SelectFileForm selectedFilesForm;
        IEnumerable<Temp.FileInfo> filtered = null;
        private bool fromSvn = false;

        public bool FromSvn { get => fromSvn; set => fromSvn = value; }

        public CopyAndClassificationForm(int currentProjectId = -1)
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

        private void Select_Destination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destination.Text = folderBrowserDialog.SelectedPath;
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
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog("Source Folder");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                sourceLocalFile.Text = folderBrowserDialog.SelectedPath;
            }

        }

        [Obsolete]
        private List<Temp.FileInfo> GetFolderFiles(SvnClient client, SvnTarget folderTarget, ref List<Temp.FileInfo> filesFound, SvnListArgs arg, string extention, ProjectFileNameParser projectFileNameParser)
        {
            Collection<SvnListEventArgs> listResults;

            if (client.GetList(folderTarget, arg, out listResults))
            {
                foreach (SvnListEventArgs item in listResults
                    .Where(item => !string.IsNullOrEmpty(item.Name) &&
                    !item.EntryUri.AbsoluteUri.ToString().Equals(folderTarget.TargetName.ToString() + "/")))
                {

                    if (item.Entry.NodeKind == SvnNodeKind.File)
                    {
                        if (Path.GetExtension(item.Name).Equals(extention))
                            filesFound.Add(
                                        new Temp.FileInfo
                                        {
                                            Name = item.Name,
                                            Path = item.EntryUri.AbsoluteUri,
                                            Size = item.Entry.FileSize / 1024,
                                            ValidFileStrusture = projectFileNameParser.ValiateFileName(item.Name).success,
                                            PathToClassify = projectFileNameParser.ValiateFileName(item.Name).path
                                        }
                                        );
                    }
                    else
                        GetFolderFiles(client, item.EntryUri, ref filesFound, arg, extention, projectFileNameParser);

                }
            }
            return filesFound;
        }


        [Obsolete]
        private IEnumerable<Temp.FileInfo> FilterFiles(bool withHidden, bool fromSvn, string sourceSVN, string sourceLocalFile, string extention)
        {
            try
            {
                //var projectFileNameParser = new ProjectFileNameParser(1);
                ProjectFileNameParser projectFileNameParser = new ProjectFileNameParser(Session.CurrentProjectId);

                List<Temp.FileInfo> filesFound = new List<Temp.FileInfo>();
                if (fromSvn)
                {
                    using (SvnClient svnClient = new SvnClient())
                    {

                        SvnListArgs arg = new SvnListArgs
                        {
                            RetrieveEntries = SvnDirEntryItems.Size

                        };
                        GetFolderFiles(svnClient, sourceSVN, ref filesFound, arg, extention, projectFileNameParser);

                    }
                    return filesFound;

                }
                else
                {
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
                            PathToClassify = projectFileNameParser.ValiateFileName(f.Name).path

                        }).ToList();
                    return filtered;
                }
            }
            catch (Exception ex) { return null; }
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
            if (string.IsNullOrWhiteSpace(metroSourceSVNTextBox.Text) && string.IsNullOrWhiteSpace(sourceLocalFile.Text))
            {
                e.Cancel = true;
                metroSourceSVNTextBox.Focus();
                sourceLocalFile.Focus();
                errorProviderSource.SetError(sourceLocalFile, "Sources should not be left blank!");
                errorProviderSource.SetError(metroSourceSVNTextBox, "Sources should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSource.SetError(sourceLocalFile, "");
                errorProviderSource.SetError(metroSourceSVNTextBox, "");
            }

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

        private void ButtonGetFiles_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                metroProgressBar1.Visible = true;
                metroLabel2.Visible = true;
                bgw.DoWork += new DoWorkEventHandler(Bgw_DoWork);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }

        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            metroProgressBar1.Visible = false;
            metroLabel2.Visible = false;
            selectedFilesForm = new SelectFileForm(Session.CurrentProjectId)
            {
                CopyAndClassificationForm = this
            };
            selectedFilesForm.FillFilesDataGridView(filtered);
            selectedFilesForm.ShowDialog();
        }

        [Obsolete]
        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                filtered = FilterFiles(false, fromSvn, metroSourceSVNTextBox.Text, sourceLocalFile.Text, ".rvt");
            }

            catch(Exception ex) {
                
            }

        }

        private void CopyAndClassificationForm_Load(object sender, EventArgs e)
        {
            if(Session.CurrentProjectId==-1)
                metroLabelProjectName.Text = "Select Project";
            else
                metroLabelProjectName.Text = Session.CurrentProject.Name;

            Session.context.Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem()
                {
                    Text = project.Name,
                    Value = project.Id
                })
            );
        }

        private void MetroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            Session.CurrentProject = Session.context.Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            metroLabelProjectName.Text = Session.CurrentProject.Name;
        }
    }







}
