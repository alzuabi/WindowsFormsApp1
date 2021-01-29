using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using PullAndClassification.Utils;
using SharpSvn;
//using Svn;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Utils;
using static Utils.Temp;

namespace PullAndClassification.Forms
{
    public partial class SyncWithSvnForm : MetroForm
    {
        private BackgroundWorker bgw = new BackgroundWorker();
        public string Destination { get; set; }
        public string Url { get; set; }
        public SyncWithSvnForm(int currentProjectId = -1)
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.context = new DatabaseContext();
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.context);
            //if (currentProjectId == -1)
            //    Session.CurrentProjectId = Session.DefaultProjectId;
            //else
            //    Session.CurrentProjectId = currentProjectId;

            Session.CurrentProject = Session.context.Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
        }

        private void PushToSvn_Click(object sender, EventArgs e)
        {
            metroProgressBar1.Visible = true;
            bgw.DoWork += new DoWorkEventHandler(Bgw_DoPush);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_RunWorkerCompleted);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();
           

        }

        private void Bgw_DoPush(object sender, DoWorkEventArgs e)
        {
            Destination = metroFromTextBox.Text;
            Parameters parameters;

            Temp temp = new Temp();
            string d = temp.GetTemporaryDirectory();
            parameters = new Parameters()
            {
                Cleanup = true,
                Command = Command.CheckoutUpdate,
                DeleteUnversioned = true,
                Message = "Adding new directory for my project",
                Mkdir = true,
                Password = metroPasswordTextBox.Text != "" ? metroPasswordTextBox.Text : null,
                Path = d,
                Revert = true,
                TrustServerCert = true,
                UpdateBeforeCompleteSync = true,
                Url = metroLabelRepoUrl.Text,
                Username = metroUserNameTextBox.Text == "" ? null : metroUserNameTextBox.Text,
                Verbose = true,

            };
            SvnUtils.CheckoutUpdate(parameters);
            Temp.CloneDirectory(d + "/.svn", Destination + "/.svn");

            parameters.Path = Destination;
            parameters.Command = Command.CompleteSync;
            SvnUtils.CompleteSync(parameters);
            Temp.DeleteDirectory(d);
        }

        private void ButtonFrom_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog("Source Folder");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                metroFromTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void PullAndPushForm_Load(object sender, EventArgs e)
        {
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            metroLabelRepoUrl.Text = Session.CurrentProject.RepoUrl;
            Session.context.Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem()
                {
                    Text = project.Name,
                    Value = project.Id
                })
            );
        }

        private void selectDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog("Destination Folder");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                metroDestinationTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void iconCloneButton_Click(object sender, EventArgs e)
        {
            metroProgressBar1.Visible = true;
            bgw.DoWork += new DoWorkEventHandler(Bgw_DoClone);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_RunWorkerCompleted);
            bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();

            
        }

        private void Bgw_DoClone(object sender, DoWorkEventArgs e)
        {
            Destination = metroDestinationTextBox.Text;
            Temp temp = new Temp();
            string d = temp.GetTemporaryDirectory();
            Parameters parameters = new Parameters()
            {
                Cleanup = true,
                Command = Command.CheckoutUpdate,
                DeleteUnversioned = true,
                Message = "Adding new directory for my project",
                Mkdir = true,
                Password = metroPasswordTextBox.Text != "" ? metroPasswordTextBox.Text : null,
                Path = d,
                Revert = true,
                TrustServerCert = true,
                UpdateBeforeCompleteSync = true,
                Url = metroLabelRepoUrl.Text,
                Username = metroUserNameTextBox.Text == "" ? null : metroUserNameTextBox.Text,
                Verbose = true,

            };
            SvnUtils.CheckoutUpdate(parameters);
            Temp.CloneDirectory(Path.Combine(d, ".svn"), Path.Combine(Destination, ".svn"));

            parameters.Path = Destination;
            parameters.Command = Command.CompleteSync;
            SvnUtils.CompleteSync(parameters);
            Temp.DeleteDirectory(d);
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            metroProgressBar1.Visible = false;
        }

        private void metroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            Session.CurrentProject = Session.context.Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();

            metroLabelProjectName.Text = Session.CurrentProject.Name;
            metroLabelRepoUrl.Text = Session.CurrentProject.RepoUrl;
        }
        private void UpdateProgressBar(object sender, SvnProgressEventArgs e)
        {
            if (e.TotalProgress != -1)
            {
                metroProgressBar1.Maximum = (int)e.TotalProgress;
            }
            metroProgressBar1.Value = (int)e.Progress;

        }
    }
}
