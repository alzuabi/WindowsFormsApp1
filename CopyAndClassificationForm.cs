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

        private SelectFileForm selectedFilesForm;
        IEnumerable<Temp.FileInfo> filtered = null;
        private bool fromSvn = false;

        public bool FromSvn { get => fromSvn; set => fromSvn = value; }

        public CopyAndClassificationForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
        }

        private void Select_Destination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destination.Text = Path.Combine(folderBrowserDialog.SelectedPath);
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
                sourceLocalFile.Text = Path.Combine(folderBrowserDialog.SelectedPath);
            }

        }

        [Obsolete]
        private List<Temp.FileInfo> GetFolderFiles(
            SvnClient client,
            SvnTarget folderTarget,
            ref List<Temp.FileInfo> filesFound,
            SvnListArgs arg,
            string extention,
            ProjectFileNameParser projectFileNameParser)
        {
            ProjectFileNameStructure projectFileNameStructure = new ProjectFileNameStructure();
            Collection<SvnListEventArgs> listResults;

            if (client.GetList(folderTarget, arg, out listResults))
            {
                foreach (SvnListEventArgs item in listResults
                    .Where(item => !string.IsNullOrEmpty(Path.Combine(item.Name)) && //skip empty paths
                    !item.EntryUri.AbsoluteUri.ToString().Equals(Path.Combine(folderTarget.TargetName).ToString() + "/"))) // skip checked dirctories
                {

                    if (item.Entry.NodeKind == SvnNodeKind.File)
                    {
                        if (Path.GetExtension(item.Name).Equals(extention))
                            filesFound.Add(new Temp.FileInfo
                            {
                                Name = Path.Combine(item.Name),
                                Path = item.EntryUri.AbsoluteUri,
                                Size = item.Entry.FileSize / 1024,
                                ValidFileStrusture = projectFileNameParser.ValiateFileName(Path.Combine(item.Name)).success,
                                PathToClassify = projectFileNameParser.ValiateFileName(Path.Combine(item.Name)).path,
                                PropertyParts = projectFileNameParser.ValiateFileName(Path.Combine(item.Name)).propertyParts

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

                ProjectFileNameParser? projectFileNameParser = new ProjectFileNameParser(Session.GetDatabaseContext(), Session.CurrentProjectId);
                if (projectFileNameParser is null)
                    SummaryMessageBox("project FileName Parser is null!", "Error", MessageBoxIcon.Error );
                List <Temp.FileInfo> filesFound = new List<Temp.FileInfo>();
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
                            Name = Path.Combine(f.Name),
                            Path = Path.Combine(f.FullName),
                            Size = f.Length / 1024,
                            ValidFileStrusture = projectFileNameParser.ValiateFileName(Path.Combine(f.Name)).success,
                            PathToClassify = string.IsNullOrEmpty (projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path)?
                                 projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path:
                               FormatPath( Path.Combine(prefexFolder, projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path)),
                            PropertyParts = projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).propertyParts,
                            ProjectFileProperties = Tuple.Create(Session.CurrentProjectId,
                             string.IsNullOrEmpty(projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path) ?
                                projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path :
                                Path.Combine(prefexFolder, projectFileNameParser.ValiateFileName(Path.GetFileNameWithoutExtension(f.Name)).path))
                            


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
                Destination = Path.Combine(destination.Text)
            };

            pullAndPushForm.ShowDialog();
        }



        private void Source_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Path.Combine(metroSourceSVNTextBox.Text)) && string.IsNullOrWhiteSpace(Path.Combine(sourceLocalFile.Text)))
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
            if (string.IsNullOrWhiteSpace(Path.Combine(destination.Text)))
            {
                e.Cancel = true;
                destination.Focus();
                errorProviderSource.SetError(destination, "Please set Destination path in user settings");
            }
            else
            {
                e.Cancel = false;
                errorProviderSource.SetError(destination, "");
            }
        }

        private void MetroProjectListComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (metroProjectListComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                metroProjectListComboBox.Focus();
                errorProviderSelectProject.SetError(metroProjectListComboBox, "Should select project!");
            }
            else
            {
                e.Cancel = false;
                errorProviderSelectProject.SetError(metroProjectListComboBox, "");
            }
        }

        private void ButtonGetFiles_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                BackgroundWorker bgw = new BackgroundWorker();
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
            selectedFilesForm = new SelectFileForm()
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
                filtered = FilterFiles(false, fromSvn, Path.Combine(metroSourceSVNTextBox.Text), Path.Combine(sourceLocalFile.Text), ".rvt");
            }

            catch (Exception)
            {

            }

        }

        private void CopyAndClassificationForm_Load(object sender, EventArgs e)
        {

            metroProjectListComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            Session.GetDatabaseContext().Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
            new ComboboxItem()
            {
                Text = Path.Combine(project.Name),
                Value = project.Id
            })
        );
            if (Session.CurrentProjectId != -1 && Session.CurrentProject is not null)
                metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);


        }

        private void MetroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            if (Session.CurrentProject is null)
                SummaryMessageBox("Project not found!", "Error", MessageBoxIcon.Error);
            else
            {
                metroLabelProjectName.Text = Session.CurrentProject.Name;
                UserSetting.setCurrentProjectId(Session.GetDatabaseContext(), Session.CurrentProjectId);
                if (UserSetting.getRootDistinationPath(Session.GetDatabaseContext()) is not null)
                    destination.Text =  Path.Combine(
                        UserSetting.getRootDistinationPath(Session.GetDatabaseContext()),
                        Session.CurrentProject.Name
                        );
            }
        }

        private void metroButtonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void MetroProjectListComboBox_Click(object sender, EventArgs e)
        {
            refreshComboBox(metroProjectListComboBox);
        }
    }
}
