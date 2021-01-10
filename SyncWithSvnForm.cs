using SharpSvn;
using Svn;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Utils;

namespace PullAndClassification.Forms
{
    public partial class SyncWithSvnForm : Form
    {
        public string Destination { get; set; } 
        public string Url { get; set; }
        public SyncWithSvnForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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
                Utils.SvnUtils.CheckoutUpdate(parameters);
                Temp.CloneDirectory(d + "/.svn", Destination + "/.svn");

                parameters.Path = Destination;
                parameters.Command = Command.CompleteSync;
                Utils.SvnUtils.CompleteSync(parameters);
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
                Utils.SvnUtils.CompleteSync(parameters);
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
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonSelectedFilesOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
