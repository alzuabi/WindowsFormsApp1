
using MetroFramework.Controls;
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
            this.selectSourceLocalFile = new System.Windows.Forms.Button();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.metroButton1 = new System.Windows.Forms.Button();
            this.metroLabelLoading = new MetroFramework.Controls.MetroLabel();
            this.destination = new MetroFramework.Controls.MetroTextBox();
            this.sourceLocalFile = new MetroFramework.Controls.MetroTextBox();
            this.metroProgressBar = new MetroFramework.Controls.MetroProgressBar();
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
            this.metroLabel1 = new System.Windows.Forms.Label();
            this.metroProjectListComboBox = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.errorProviderSelectProject = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroButtonFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDestination)).BeginInit();
            this.panel4.SuspendLayout();
            this.SVNconf.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSelectProject)).BeginInit();
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
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.selectSourceLocalFile);
            this.panel4.Controls.Add(this.iconButton1);
            this.panel4.Controls.Add(this.metroButton1);
            this.panel4.Controls.Add(this.metroLabelLoading);
            this.panel4.Controls.Add(this.destination);
            this.panel4.Controls.Add(this.sourceLocalFile);
            this.panel4.Controls.Add(this.metroProgressBar);
            this.panel4.Controls.Add(this.SVNconf);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Location = new System.Drawing.Point(88, 98);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(624, 303);
            this.panel4.TabIndex = 19;
            // 
            // selectSourceLocalFile
            // 
            this.selectSourceLocalFile.AutoSize = true;
            this.selectSourceLocalFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.selectSourceLocalFile.Font = new System.Drawing.Font("Tahoma", 8F);
            this.selectSourceLocalFile.Location = new System.Drawing.Point(161, 123);
            this.selectSourceLocalFile.Name = "selectSourceLocalFile";
            this.selectSourceLocalFile.Size = new System.Drawing.Size(82, 23);
            this.selectSourceLocalFile.TabIndex = 42;
            this.selectSourceLocalFile.Text = "Select Source";
            this.selectSourceLocalFile.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.AutoSize = true;
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.Enabled = false;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(152, 177);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(92, 36);
            this.iconButton1.TabIndex = 41;
            this.iconButton1.Text = "Destination";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.AllowDrop = true;
            this.metroButton1.AutoSize = true;
            this.metroButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroButton1.Location = new System.Drawing.Point(285, 269);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(70, 23);
            this.metroButton1.TabIndex = 38;
            this.metroButton1.Text = "Select Files";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabelLoading
            // 
            this.metroLabelLoading.AutoSize = true;
            this.metroLabelLoading.Location = new System.Drawing.Point(24, 232);
            this.metroLabelLoading.Name = "metroLabelLoading";
            this.metroLabelLoading.Size = new System.Drawing.Size(65, 19);
            this.metroLabelLoading.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelLoading.TabIndex = 40;
            this.metroLabelLoading.Text = "Loading...";
            this.metroLabelLoading.Visible = false;
            // 
            // destination
            // 
            // 
            // 
            // 
            this.destination.CustomButton.Image = null;
            this.destination.CustomButton.Location = new System.Drawing.Point(193, 1);
            this.destination.CustomButton.Name = "";
            this.destination.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.destination.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.destination.CustomButton.TabIndex = 1;
            this.destination.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.destination.CustomButton.UseSelectable = true;
            this.destination.CustomButton.Visible = false;
            this.destination.Lines = new string[0];
            this.destination.Location = new System.Drawing.Point(308, 189);
            this.destination.MaxLength = 32767;
            this.destination.Name = "destination";
            this.destination.PasswordChar = '\0';
            this.destination.ReadOnly = true;
            this.destination.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.destination.SelectedText = "";
            this.destination.SelectionLength = 0;
            this.destination.SelectionStart = 0;
            this.destination.ShortcutsEnabled = true;
            this.destination.Size = new System.Drawing.Size(215, 23);
            this.destination.Style = MetroFramework.MetroColorStyle.Blue;
            this.destination.TabIndex = 38;
            this.destination.UseSelectable = true;
            this.destination.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.destination.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.destination.Validating += new System.ComponentModel.CancelEventHandler(this.Destination_Validating);
            // 
            // sourceLocalFile
            // 
            this.sourceLocalFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            // 
            // 
            // 
            this.sourceLocalFile.CustomButton.Image = null;
            this.sourceLocalFile.CustomButton.Location = new System.Drawing.Point(193, 1);
            this.sourceLocalFile.CustomButton.Name = "";
            this.sourceLocalFile.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sourceLocalFile.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sourceLocalFile.CustomButton.TabIndex = 1;
            this.sourceLocalFile.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sourceLocalFile.CustomButton.UseSelectable = true;
            this.sourceLocalFile.CustomButton.Visible = false;
            this.sourceLocalFile.Lines = new string[0];
            this.sourceLocalFile.Location = new System.Drawing.Point(308, 123);
            this.sourceLocalFile.MaxLength = 32767;
            this.sourceLocalFile.Name = "sourceLocalFile";
            this.sourceLocalFile.PasswordChar = '\0';
            this.sourceLocalFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sourceLocalFile.SelectedText = "";
            this.sourceLocalFile.SelectionLength = 0;
            this.sourceLocalFile.SelectionStart = 0;
            this.sourceLocalFile.ShortcutsEnabled = true;
            this.sourceLocalFile.Size = new System.Drawing.Size(215, 23);
            this.sourceLocalFile.Style = MetroFramework.MetroColorStyle.Blue;
            this.sourceLocalFile.TabIndex = 37;
            this.sourceLocalFile.UseSelectable = true;
            this.sourceLocalFile.Visible = false;
            this.sourceLocalFile.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sourceLocalFile.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.sourceLocalFile.Validating += new System.ComponentModel.CancelEventHandler(this.Source_Validating);
            // 
            // metroProgressBar
            // 
            this.metroProgressBar.Location = new System.Drawing.Point(114, 240);
            this.metroProgressBar.Name = "metroProgressBar";
            this.metroProgressBar.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.metroProgressBar.Size = new System.Drawing.Size(477, 11);
            this.metroProgressBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressBar.TabIndex = 33;
            this.metroProgressBar.Visible = false;
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
            this.SVNconf.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SVNconf.Location = new System.Drawing.Point(114, 22);
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
            this.url.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.url.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.url.Location = new System.Drawing.Point(44, 17);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(22, 11);
            this.url.TabIndex = 12;
            this.url.Text = "URL";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Password.Location = new System.Drawing.Point(267, 57);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(45, 11);
            this.Password.TabIndex = 10;
            this.Password.Text = "Password";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UserName.Location = new System.Drawing.Point(11, 57);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(52, 11);
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
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 137);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // localFiles
            // 
            this.localFiles.AutoSize = true;
            this.localFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.localFiles.ForeColor = System.Drawing.Color.DimGray;
            this.localFiles.Location = new System.Drawing.Point(19, 109);
            this.localFiles.Name = "localFiles";
            this.localFiles.Size = new System.Drawing.Size(62, 15);
            this.localFiles.TabIndex = 1;
            this.localFiles.TabStop = true;
            this.localFiles.Text = "Local files";
            this.localFiles.UseVisualStyleBackColor = true;
            this.localFiles.CheckedChanged += new System.EventHandler(this.LocalFiles_CheckedChanged);
            // 
            // svn
            // 
            this.svn.AutoSize = true;
            this.svn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.svn.ForeColor = System.Drawing.Color.DimGray;
            this.svn.Location = new System.Drawing.Point(40, 28);
            this.svn.Name = "svn";
            this.svn.Size = new System.Drawing.Size(43, 15);
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
            this.metroLabelProjectName.Location = new System.Drawing.Point(276, 60);
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
            this.metroLabel1.Size = new System.Drawing.Size(81, 13);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "Current Project";
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 13;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(523, 26);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(189, 21);
            this.metroProjectListComboBox.TabIndex = 35;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            this.metroProjectListComboBox.Click += new System.EventHandler(this.MetroProjectListComboBox_Click);
            this.metroProjectListComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.MetroProjectListComboBox_Validating);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(376, 60);
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
            this.metroButtonFinish.BackColor = System.Drawing.Color.Transparent;
            this.metroButtonFinish.Location = new System.Drawing.Point(726, 403);
            this.metroButtonFinish.Name = "metroButtonFinish";
            this.metroButtonFinish.Size = new System.Drawing.Size(75, 23);
            this.metroButtonFinish.TabIndex = 37;
            this.metroButtonFinish.Text = "Close";
            this.metroButtonFinish.UseVisualStyleBackColor = false;
            this.metroButtonFinish.Click += new System.EventHandler(this.MetroButtonFinish_Click);
            // 
            // CopyAndClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(817, 437);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderSource;
        private System.Windows.Forms.ErrorProvider errorProviderDestination;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton localFiles;
        private System.Windows.Forms.RadioButton svn;
        public MetroFramework.Controls.MetroTextBox UserNameTextBox1 { get => metroUsernameTextBox; set => metroUsernameTextBox = value; }
        public MetroFramework.Controls.MetroTextBox PasswordTestBox1 { get => metroPasswordTextBox; set => metroPasswordTextBox = value; }
        public MetroFramework.Controls.MetroTextBox MetroSourceSVNTextBox { get => metroSourceSVNTextBox; set => metroSourceSVNTextBox = value; }
        public MetroFramework.Controls.MetroTextBox SourceLocalFile { get => sourceLocalFile; set => sourceLocalFile = value; }
        public MetroFramework.Controls.MetroTextBox Destination { get => destination; set => destination = value; }
        private MetroFramework.Controls.MetroProgressBar metroProgressBar;
        private MetroFramework.Controls.MetroTextBox sourceLocalFile;
        private MetroFramework.Controls.MetroTextBox destination;
        private MetroFramework.Controls.MetroLabel metroLabelLoading;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private Label metroLabel1;
        private ComboBox metroProjectListComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private ErrorProvider errorProviderSelectProject;
        private Button metroButtonFinish;
        private GroupBox SVNconf;
        private MetroTextBox metroPasswordTextBox;
        private MetroTextBox metroUsernameTextBox;
        private MetroTextBox metroSourceSVNTextBox;
        private Label url;
        private Label Password;
        private Label UserName;
        private Button metroButton1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Button selectSourceLocalFile;
    }
}

