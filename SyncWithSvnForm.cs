using SharpSvn;
using SvnClient;
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
using WindowsFormsApp1.Utils;

namespace PullAndClassificationForm
{
    public partial class SyncWithSvnForm : Form
    {
        public string Destination { get; set; } 
        public string Url { get; set; }
        public SyncWithSvnForm()
        {
            InitializeComponent();
        }

        private void PushToSvn_Click(object sender, EventArgs e)
        {
            Parameters parameters;
            if (Url == null)
            {
                Temp temp = new Temp();
                string d = temp.GetTemporaryDirectory();
                parameters = new Parameters()
                {
                    Cleanup = true,
                    Command = Command.CheckoutUpdate,
                    DeleteUnversioned = true,
                    Message = "Adding new directory for my project",
                    Mkdir = true,
                    Password = PasswordTestBox2.Text != "" ? PasswordTestBox2.Text : null,
                    Path = d,
                    Revert = true,
                    TrustServerCert = true,
                    UpdateBeforeCompleteSync = false,
                    Url = textBoxDestSVN.Text,
                    Username = UserNameTextBox2.Text == "" ? null : UserNameTextBox2.Text,
                    Verbose = true,

                };
                SvnUtils.CheckoutUpdate(parameters);
                Temp.CloneDirectory(d + "/.svn", Destination + "/.svn");

                parameters.Path = Destination;
                parameters.Command = Command.CompleteSync;
                SvnUtils.CompleteSync(parameters);
            }
            else
            {
                parameters = new Parameters()
                {
                    Cleanup = true,
                    Command = Command.CompleteSync,
                    DeleteUnversioned = true,
                    Message = "Adding new directory for my project",
                    Mkdir = true,
                    Password = PasswordTestBox2.Text != "" ? PasswordTestBox2.Text : null,
                    Path = Destination,
                    Revert = true,
                    TrustServerCert = true,
                    UpdateBeforeCompleteSync = false,
                    Url = textBoxDestSVN.Text,
                    Username = UserNameTextBox2.Text == "" ? null : UserNameTextBox2.Text,
                    Verbose = true,

                };
                SvnUtils.CompleteSync(parameters);
            }
        }

        private void ButtonFrom_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFrom.Text = folderBrowserDialog.SelectedPath;
                if (Directory.Exists(Destination + "/.svn"))
                {
                    using (var client = new SharpSvn.SvnClient())
                    {
                        try
                        {
                            client.GetInfo(Destination, out SvnInfoEventArgs info);
                            textBoxDestSVN.Text = info.Uri.ToString();
                            textBoxDestSVN.ReadOnly = true;
                            Url = textBoxDestSVN.Text;
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        private void PullAndPushForm_Load(object sender, EventArgs e)
        {
            textBoxFrom.Text = Destination;
            if (Directory.Exists(Destination + "/.svn"))
            {
                using (var client = new SharpSvn.SvnClient())
                {
                    try
                    {
                        client.GetInfo(Destination, out SvnInfoEventArgs info);
                        textBoxDestSVN.Text = info.Uri.ToString();
                       
                        textBoxDestSVN.ReadOnly = true;
                        Url = textBoxDestSVN.Text;
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}
