
using System.Windows.Forms;

namespace PullAndClassification.Forms
{
    partial class CopyAndClassificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProviderSource = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDestination = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.destination = new MetroFramework.Controls.MetroTextBox();
            this.sourceLocalFile = new MetroFramework.Controls.MetroTextBox();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.buttonGetFiles = new FontAwesome.Sharp.IconButton();
            this.selectDestination = new FontAwesome.Sharp.IconButton();
            this.selectSourceLocalFile = new FontAwesome.Sharp.IconButton();
            this.SVNconf = new System.Windows.Forms.GroupBox();
            this.metroPasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroUsernameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroSourceSVNTextBox = new MetroFramework.Controls.MetroTextBox();
            this.url = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localFiles = new System.Windows.Forms.RadioButton();
            this.svn = new System.Windows.Forms.RadioButton();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.errorProviderSelectProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroButtonFinish = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDestination)).BeginInit();
            this.panel4.SuspendLayout();
            this.SVNconf.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSelectProject)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProviderSource
            // 
            this.errorProviderSource.ContainerControl = this;
            // 
            // errorProviderDestination
            // 
            this.errorProviderDestination.ContainerControl = this;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.metroLabel2);
            this.panel4.Controls.Add(this.destination);
            this.panel4.Controls.Add(this.sourceLocalFile);
            this.panel4.Controls.Add(this.metroProgressBar1);
            this.panel4.Controls.Add(this.buttonGetFiles);
            this.panel4.Controls.Add(this.selectDestination);
            this.panel4.Controls.Add(this.selectSourceLocalFile);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.SVNconf);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(38, 98);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 292);
            this.panel4.TabIndex = 19;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(94, 232);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 40;
            this.metroLabel2.Text = "Loading...";
            this.metroLabel2.Visible = false;
            // 
            // destination
            // 
            // 
            // 
            // 
            this.destination.CustomButton.Image = null;
            this.destination.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.destination.CustomButton.Name = "";
            this.destination.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.destination.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.destination.CustomButton.TabIndex = 1;
            this.destination.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.destination.CustomButton.UseSelectable = true;
            this.destination.CustomButton.Visible = false;
            this.destination.Lines = new string[0];
            this.destination.Location = new System.Drawing.Point(378, 189);
            this.destination.MaxLength = 32767;
            this.destination.Name = "destination";
            this.destination.PasswordChar = '\0';
            this.destination.ReadOnly = true;
            this.destination.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.destination.SelectedText = "";
            this.destination.SelectionLength = 0;
            this.destination.SelectionStart = 0;
            this.destination.ShortcutsEnabled = true;
            this.destination.Size = new System.Drawing.Size(298, 23);
            this.destination.Style = MetroFramework.MetroColorStyle.Blue;
            this.destination.TabIndex = 38;
            this.destination.UseSelectable = true;
            this.destination.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.destination.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.destination.Validating += new System.ComponentModel.CancelEventHandler(this.Destination_Validating);
            // 
            // sourceLocalFile
            // 
            // 
            // 
            // 
            this.sourceLocalFile.CustomButton.Image = null;
            this.sourceLocalFile.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.sourceLocalFile.CustomButton.Name = "";
            this.sourceLocalFile.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sourceLocalFile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sourceLocalFile.CustomButton.TabIndex = 1;
            this.sourceLocalFile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sourceLocalFile.CustomButton.UseSelectable = true;
            this.sourceLocalFile.CustomButton.Visible = false;
            this.sourceLocalFile.Lines = new string[0];
            this.sourceLocalFile.Location = new System.Drawing.Point(378, 123);
            this.sourceLocalFile.MaxLength = 32767;
            this.sourceLocalFile.Name = "sourceLocalFile";
            this.sourceLocalFile.PasswordChar = '\0';
            this.sourceLocalFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sourceLocalFile.SelectedText = "";
            this.sourceLocalFile.SelectionLength = 0;
            this.sourceLocalFile.SelectionStart = 0;
            this.sourceLocalFile.ShortcutsEnabled = true;
            this.sourceLocalFile.Size = new System.Drawing.Size(298, 23);
            this.sourceLocalFile.Style = MetroFramework.MetroColorStyle.Blue;
            this.sourceLocalFile.TabIndex = 37;
            this.sourceLocalFile.UseSelectable = true;
            this.sourceLocalFile.Visible = false;
            this.sourceLocalFile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sourceLocalFile.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.sourceLocalFile.Validating += new System.ComponentModel.CancelEventHandler(this.Source_Validating);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(184, 240);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.metroProgressBar1.Size = new System.Drawing.Size(492, 5);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressBar1.TabIndex = 33;
            this.metroProgressBar1.Visible = false;
            // 
            // buttonGetFiles
            // 
            this.buttonGetFiles.FlatAppearance.BorderSize = 0;
            this.buttonGetFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGetFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.buttonGetFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetFiles.ForeColor = System.Drawing.Color.DimGray;
            this.buttonGetFiles.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            this.buttonGetFiles.IconColor = System.Drawing.Color.Black;
            this.buttonGetFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonGetFiles.IconSize = 30;
            this.buttonGetFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetFiles.Location = new System.Drawing.Point(326, 251);
            this.buttonGetFiles.Name = "buttonGetFiles";
            this.buttonGetFiles.Size = new System.Drawing.Size(106, 40);
            this.buttonGetFiles.TabIndex = 29;
            this.buttonGetFiles.Text = "Select Files";
            this.buttonGetFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGetFiles.UseVisualStyleBackColor = true;
            this.buttonGetFiles.Click += new System.EventHandler(this.ButtonGetFiles_Click);
            // 
            // selectDestination
            // 
            this.selectDestination.Enabled = false;
            this.selectDestination.FlatAppearance.BorderSize = 0;
            this.selectDestination.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.selectDestination.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.selectDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDestination.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDestination.ForeColor = System.Drawing.Color.DimGray;
            this.selectDestination.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.selectDestination.IconColor = System.Drawing.Color.Black;
            this.selectDestination.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.selectDestination.IconSize = 30;
            this.selectDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectDestination.Location = new System.Drawing.Point(215, 180);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(104, 38);
            this.selectDestination.TabIndex = 28;
            this.selectDestination.Text = "Destination";
            this.selectDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectDestination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectDestination.UseVisualStyleBackColor = true;
            this.selectDestination.Click += new System.EventHandler(this.Select_Destination_Click);
            // 
            // selectSourceLocalFile
            // 
            this.selectSourceLocalFile.BackColor = System.Drawing.Color.Transparent;
            this.selectSourceLocalFile.FlatAppearance.BorderSize = 0;
            this.selectSourceLocalFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.selectSourceLocalFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.selectSourceLocalFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectSourceLocalFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSourceLocalFile.ForeColor = System.Drawing.Color.DimGray;
            this.selectSourceLocalFile.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            this.selectSourceLocalFile.IconColor = System.Drawing.Color.Black;
            this.selectSourceLocalFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.selectSourceLocalFile.IconSize = 30;
            this.selectSourceLocalFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectSourceLocalFile.Location = new System.Drawing.Point(215, 116);
            this.selectSourceLocalFile.Name = "selectSourceLocalFile";
            this.selectSourceLocalFile.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.selectSourceLocalFile.Size = new System.Drawing.Size(143, 35);
            this.selectSourceLocalFile.TabIndex = 26;
            this.selectSourceLocalFile.Text = "Select Source";
            this.selectSourceLocalFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectSourceLocalFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectSourceLocalFile.UseVisualStyleBackColor = false;
            this.selectSourceLocalFile.Visible = false;
            this.selectSourceLocalFile.Click += new System.EventHandler(this.SelectSourceLocalFile_Click);
            // 
            // SVNconf
            // 
            this.SVNconf.Controls.Add(this.metroPasswordTextBox);
            this.SVNconf.Controls.Add(this.metroUsernameTextBox);
            this.SVNconf.Controls.Add(this.metroSourceSVNTextBox);
            this.SVNconf.Controls.Add(this.url);
            this.SVNconf.Controls.Add(this.Password);
            this.SVNconf.Controls.Add(this.UserName);
            this.SVNconf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SVNconf.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SVNconf.ForeColor = System.Drawing.Color.Gainsboro;
            this.SVNconf.Location = new System.Drawing.Point(199, 14);
            this.SVNconf.Name = "SVNconf";
            this.SVNconf.Size = new System.Drawing.Size(477, 88);
            this.SVNconf.TabIndex = 23;
            this.SVNconf.TabStop = false;
            this.SVNconf.Text = "SVN";
            this.SVNconf.Visible = false;
            // 
            // metroPasswordTextBox
            // 
            // 
            // 
            // 
            this.metroPasswordTextBox.CustomButton.Image = null;
            this.metroPasswordTextBox.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.metroPasswordTextBox.CustomButton.Name = "";
            this.metroPasswordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroPasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPasswordTextBox.CustomButton.TabIndex = 1;
            this.metroPasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPasswordTextBox.CustomButton.UseSelectable = true;
            this.metroPasswordTextBox.CustomButton.Visible = false;
            this.metroPasswordTextBox.Lines = new string[0];
            this.metroPasswordTextBox.Location = new System.Drawing.Point(326, 53);
            this.metroPasswordTextBox.MaxLength = 32767;
            this.metroPasswordTextBox.Name = "metroPasswordTextBox";
            this.metroPasswordTextBox.PasswordChar = '●';
            this.metroPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroPasswordTextBox.SelectedText = "";
            this.metroPasswordTextBox.SelectionLength = 0;
            this.metroPasswordTextBox.SelectionStart = 0;
            this.metroPasswordTextBox.ShortcutsEnabled = true;
            this.metroPasswordTextBox.Size = new System.Drawing.Size(141, 23);
            this.metroPasswordTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPasswordTextBox.TabIndex = 36;
            this.metroPasswordTextBox.UseSelectable = true;
            this.metroPasswordTextBox.UseSystemPasswordChar = true;
            this.metroPasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroPasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroUsernameTextBox
            // 
            // 
            // 
            // 
            this.metroUsernameTextBox.CustomButton.Image = null;
            this.metroUsernameTextBox.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.metroUsernameTextBox.CustomButton.Name = "";
            this.metroUsernameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroUsernameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroUsernameTextBox.CustomButton.TabIndex = 1;
            this.metroUsernameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroUsernameTextBox.CustomButton.UseSelectable = true;
            this.metroUsernameTextBox.CustomButton.Visible = false;
            this.metroUsernameTextBox.Lines = new string[0];
            this.metroUsernameTextBox.Location = new System.Drawing.Point(76, 53);
            this.metroUsernameTextBox.MaxLength = 32767;
            this.metroUsernameTextBox.Name = "metroUsernameTextBox";
            this.metroUsernameTextBox.PasswordChar = '\0';
            this.metroUsernameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroUsernameTextBox.SelectedText = "";
            this.metroUsernameTextBox.SelectionLength = 0;
            this.metroUsernameTextBox.SelectionStart = 0;
            this.metroUsernameTextBox.ShortcutsEnabled = true;
            this.metroUsernameTextBox.Size = new System.Drawing.Size(141, 23);
            this.metroUsernameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroUsernameTextBox.TabIndex = 35;
            this.metroUsernameTextBox.UseSelectable = true;
            this.metroUsernameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroUsernameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroSourceSVNTextBox
            // 
            // 
            // 
            // 
            this.metroSourceSVNTextBox.CustomButton.Image = null;
            this.metroSourceSVNTextBox.CustomButton.Location = new System.Drawing.Point(369, 1);
            this.metroSourceSVNTextBox.CustomButton.Name = "";
            this.metroSourceSVNTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroSourceSVNTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroSourceSVNTextBox.CustomButton.TabIndex = 1;
            this.metroSourceSVNTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroSourceSVNTextBox.CustomButton.UseSelectable = true;
            this.metroSourceSVNTextBox.CustomButton.Visible = false;
            this.metroSourceSVNTextBox.Lines = new string[0];
            this.metroSourceSVNTextBox.Location = new System.Drawing.Point(76, 15);
            this.metroSourceSVNTextBox.MaxLength = 32767;
            this.metroSourceSVNTextBox.Name = "metroSourceSVNTextBox";
            this.metroSourceSVNTextBox.PasswordChar = '\0';
            this.metroSourceSVNTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroSourceSVNTextBox.SelectedText = "";
            this.metroSourceSVNTextBox.SelectionLength = 0;
            this.metroSourceSVNTextBox.SelectionStart = 0;
            this.metroSourceSVNTextBox.ShortcutsEnabled = true;
            this.metroSourceSVNTextBox.Size = new System.Drawing.Size(391, 23);
            this.metroSourceSVNTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroSourceSVNTextBox.TabIndex = 34;
            this.metroSourceSVNTextBox.UseSelectable = true;
            this.metroSourceSVNTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroSourceSVNTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroSourceSVNTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.Source_Validating);
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.url.ForeColor = System.Drawing.Color.Gainsboro;
            this.url.Location = new System.Drawing.Point(44, 17);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(26, 13);
            this.url.TabIndex = 12;
            this.url.Text = "URL";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.ForeColor = System.Drawing.Color.Gainsboro;
            this.Password.Location = new System.Drawing.Point(267, 57);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 10;
            this.Password.Text = "Password";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.ForeColor = System.Drawing.Color.Gainsboro;
            this.UserName.Location = new System.Drawing.Point(11, 57);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(59, 13);
            this.UserName.TabIndex = 8;
            this.UserName.Text = "User Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localFiles);
            this.groupBox1.Controls.Add(this.svn);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox1.Location = new System.Drawing.Point(46, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 137);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // localFiles
            // 
            this.localFiles.AutoSize = true;
            this.localFiles.ForeColor = System.Drawing.Color.DimGray;
            this.localFiles.Location = new System.Drawing.Point(19, 109);
            this.localFiles.Name = "localFiles";
            this.localFiles.Size = new System.Drawing.Size(71, 17);
            this.localFiles.TabIndex = 1;
            this.localFiles.TabStop = true;
            this.localFiles.Text = "Local files";
            this.localFiles.UseVisualStyleBackColor = true;
            this.localFiles.CheckedChanged += new System.EventHandler(this.LocalFiles_CheckedChanged);
            // 
            // svn
            // 
            this.svn.AutoSize = true;
            this.svn.ForeColor = System.Drawing.Color.DimGray;
            this.svn.Location = new System.Drawing.Point(40, 28);
            this.svn.Name = "svn";
            this.svn.Size = new System.Drawing.Size(44, 17);
            this.svn.TabIndex = 0;
            this.svn.TabStop = true;
            this.svn.Text = "SVN";
            this.svn.UseVisualStyleBackColor = true;
            this.svn.CheckedChanged += new System.EventHandler(this.Svn_CheckedChanged);
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelProjectName.Location = new System.Drawing.Point(376, 67);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(94, 19);
            this.metroLabelProjectName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelProjectName.TabIndex = 20;
            this.metroLabelProjectName.Text = "metroLabel1";
            this.metroLabelProjectName.Visible = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(419, 29);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Current Project";
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 23;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(523, 26);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.PromptText = "Select Project";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(189, 29);
            this.metroProjectListComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProjectListComboBox.TabIndex = 35;
            this.metroProjectListComboBox.UseSelectable = true;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            this.metroProjectListComboBox.Click += new System.EventHandler(this.MetroProjectListComboBox_Click);
            this.metroProjectListComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MetroProjectListComboBox_Validating);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(476, 67);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(136, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 36;
            this.metroLabel3.Text = "Please Select Project: ";
            this.metroLabel3.Visible = false;
            // 
            // errorProviderSelectProject
            // 
            this.errorProviderSelectProject.ContainerControl = this;
            // 
            // metroButtonFinish
            // 
            this.metroButtonFinish.Location = new System.Drawing.Point(813, 378);
            this.metroButtonFinish.Name = "metroButtonFinish";
            this.metroButtonFinish.Size = new System.Drawing.Size(75, 23);
            this.metroButtonFinish.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonFinish.TabIndex = 37;
            this.metroButtonFinish.Text = "Close";
            this.metroButtonFinish.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButtonFinish.UseSelectable = true;
            this.metroButtonFinish.Click += new System.EventHandler(this.metroButtonFinish_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroTextBox1);
            this.groupBox2.Controls.Add(this.metroTextBox2);
            this.groupBox2.Controls.Add(this.metroTextBox3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(199, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 88);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SVN";
            this.groupBox2.Visible = false;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(326, 53);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '●';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(141, 23);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.TabIndex = 36;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.UseSystemPasswordChar = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(76, 53);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(141, 23);
            this.metroTextBox2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.TabIndex = 35;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(369, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(76, 15);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(391, 23);
            this.metroTextBox3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.TabIndex = 34;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox3.Validating += new System.ComponentModel.CancelEventHandler(this.Source_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(44, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(267, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "User Name";
            // 
            // CopyAndClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(908, 424);
            this.Controls.Add(this.metroButtonFinish);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.panel4);
            this.Name = "CopyAndClassificationForm";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.Text = "Copy And Classification Form";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.CopyAndClassificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDestination)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.SVNconf.ResumeLayout(false);
            this.SVNconf.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSelectProject)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderSource;
        private System.Windows.Forms.ErrorProvider errorProviderDestination;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton selectSourceLocalFile;
        private System.Windows.Forms.GroupBox SVNconf;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton localFiles;
        private System.Windows.Forms.RadioButton svn;
        public MetroFramework.Controls.MetroTextBox UserNameTextBox1 { get => metroUsernameTextBox; set => metroUsernameTextBox = value; }
        public MetroFramework.Controls.MetroTextBox PasswordTestBox1 { get => metroPasswordTextBox; set => metroPasswordTextBox = value; }
        public MetroFramework.Controls.MetroTextBox MetroSourceSVNTextBox { get => metroSourceSVNTextBox; set => metroSourceSVNTextBox = value; }
        public MetroFramework.Controls.MetroTextBox SourceLocalFile { get => sourceLocalFile; set => sourceLocalFile = value; }
        public MetroFramework.Controls.MetroTextBox Destination { get => destination; set => destination = value; }
        private FontAwesome.Sharp.IconButton selectDestination;
        private FontAwesome.Sharp.IconButton buttonGetFiles;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroTextBox metroSourceSVNTextBox;
        private MetroFramework.Controls.MetroTextBox metroUsernameTextBox;
        private MetroFramework.Controls.MetroTextBox metroPasswordTextBox;
        private MetroFramework.Controls.MetroTextBox sourceLocalFile;
        private MetroFramework.Controls.MetroTextBox destination;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroProjectListComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private ErrorProvider errorProviderSelectProject;
        private MetroFramework.Controls.MetroButton metroButtonFinish;
        private GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}

