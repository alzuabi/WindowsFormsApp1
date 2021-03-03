using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using PullAndClassification.Utils;
using SharpSvn;
using System;
using System.ComponentModel;
using System.Drawing;
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
        //public static MetroFramework.Controls.MetroLabel GetMetroLabel()
        //{
        //    return metroLabel6;
        //}
        public static MetroFramework.Controls.MetroLabel SpeedLabel;
        public string Destination { get; set; }
        public string Url { get; set; }
        public SyncWithSvnForm(/*int currentProjectId = -1*/)
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            //Session.context = new DatabaseContext();
            Session.CurrentProjectId = UserSetting.getCurrentProjectId(Session.GetDatabaseContext());
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            metroDestinationTextBox.Text = metroFromTextBox.Text = UserSetting.getRootDistinationPath(Session.GetDatabaseContext());
            SpeedLabel = new MetroFramework.Controls.MetroLabel
            {
                Location = new System.Drawing.Point { X = 566, Y = 288 },
                Style = MetroFramework.MetroColorStyle.Blue,
                BackColor = Color.FromArgb(17, 17, 17),
                Theme = MetroFramework.MetroThemeStyle.Dark


            };

        }

        private void PushToSvn_Click(object sender, EventArgs e)
        {
            metroLabel6.Text = 0.ToString();
            if (string.IsNullOrEmpty(metroDestinationTextBox.Text))
                MessageBox.Show("Please set Destination in user settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                BackgroundWorker bgw = new BackgroundWorker();
                metroProgressBar1.Visible = true;
                bgw.DoWork += new DoWorkEventHandler(Bgw_DoPush);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }
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
                Command = Command.CompleteSync,
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
            CloneDirectory(Path.Combine(d, ".svn"), Path.Combine(Destination, ".svn"));

            //Temp.CloneDirectory(d + "/.svn", Destination + "/.svn");

            parameters.Path = Destination;
            parameters.Command = Command.CompleteSync;
            SvnUtils.CompleteSync(parameters);
            DeleteDirectory(d);
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
            SpeedLabel = new MetroFramework.Controls.MetroLabel
            {
                Location = new System.Drawing.Point { X = 566, Y = 288 },
                Style = MetroFramework.MetroColorStyle.Blue,
                BackColor = Color.FromArgb(17, 17, 17),
                Theme = MetroFramework.MetroThemeStyle.Dark


            };
            Session.GetDatabaseContext().Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem()
                {
                    Text = project.Name,
                    Value = project.Id
                })
            );
            if (Session.CurrentProjectId != -1 && Session.CurrentProject is not null)
                metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
        }

        private void SelectDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog("Destination Folder");

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                metroDestinationTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void IconCloneButton_Click(object sender, EventArgs e)
        {
            metroLabel6.Text = 0.ToString();
            if (string.IsNullOrEmpty(metroDestinationTextBox.Text))
                MessageBox.Show("Please set Destination in user settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                BackgroundWorker bgw = new BackgroundWorker();
                metroProgressBar1.Visible = true;
                bgw.DoWork += new DoWorkEventHandler(Bgw_DoClone);
                //bgw.DoWork += new DoWorkEventHandler(Bgw_DoDowenload);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_RunWorkerCompleted);
                //bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_DownloadCompleted);

                bgw.WorkerReportsProgress = true;
                bgw.RunWorkerAsync();
            }
        }

        private void Bgw_DoDowenload(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Bgw_DoClone(object sender, DoWorkEventArgs e)
        {


            Destination = Path.Combine(metroDestinationTextBox.Text);
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
            CloneDirectory(Path.Combine(d, ".svn"), Path.Combine(Destination, ".svn"));
            File.SetAttributes(Path.Combine(Destination, ".svn"), File.GetAttributes(Path.Combine(Destination, ".svn")) | FileAttributes.Hidden);

            parameters.Path = Destination;
            parameters.Command = Command.CompleteSync;
            SvnUtils.CompleteSync(parameters);
            DeleteDirectory(d);
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                metroProgressBar1.Visible = false;
        }

        private void MetroProjectListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;
            Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
            metroLabelProjectName.Text = Session.CurrentProject.Name;
            UserSetting.setCurrentProjectId(Session.GetDatabaseContext(), Session.CurrentProjectId);

            metroLabelRepoUrl.Text = Session.CurrentProject.RepoUrl;
        }
        private void UpdateProgressBar(object sender, SvnProgressEventArgs e)
        {
            if (e.TotalProgress != -1)
            {
                metroProgressBar1.Maximum = (int)e.TotalProgress;
            }

        }

        private void buttonSelectedFilesOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroProjectListComboBox_Click(object sender, EventArgs e)
        {
            refreshComboBox(metroProjectListComboBox);
        }
    }
}
