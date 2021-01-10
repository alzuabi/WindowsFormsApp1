
namespace PullAndClassification.Forms
{
    partial class PandCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PandCForm));
            this.errorProviderSource = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDestination = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.minimizeButton = new FontAwesome.Sharp.IconButton();
            this.maximizeButton = new FontAwesome.Sharp.IconButton();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonPullAndPush = new FontAwesome.Sharp.IconButton();
            this.checkBoxClassification = new System.Windows.Forms.CheckBox();
            this.buttonGetFiles = new FontAwesome.Sharp.IconButton();
            this.selectDestination = new FontAwesome.Sharp.IconButton();
            this.buttonSelectFiles = new FontAwesome.Sharp.IconButton();
            this.selectSourceLocalFile = new FontAwesome.Sharp.IconButton();
            this.SVNconf = new System.Windows.Forms.GroupBox();
            this.url = new System.Windows.Forms.Label();
            this.PasswordTestBox1 = new System.Windows.Forms.TextBox();
            this.sourceSVN = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.UserNameTextBox1 = new System.Windows.Forms.TextBox();
            this.sourceLocalFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localFiles = new System.Windows.Forms.RadioButton();
            this.svn = new System.Windows.Forms.RadioButton();
            this.buttonCopyAndClassification = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDestination)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SVNconf.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 510);
            this.panel1.TabIndex = 15;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(214, 250);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.minimizeButton);
            this.panel2.Controls.Add(this.maximizeButton);
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 80);
            this.panel2.TabIndex = 17;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.AutoSize = true;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.minimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.minimizeButton.IconColor = System.Drawing.Color.Gainsboro;
            this.minimizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimizeButton.IconSize = 25;
            this.minimizeButton.Location = new System.Drawing.Point(652, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(31, 31);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.AutoSize = true;
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.maximizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.maximizeButton.IconColor = System.Drawing.Color.Gainsboro;
            this.maximizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximizeButton.IconSize = 25;
            this.maximizeButton.Location = new System.Drawing.Point(690, 0);
            this.maximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(31, 31);
            this.maximizeButton.TabIndex = 2;
            this.maximizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.maximizeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.AutoSize = true;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.exitButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.exitButton.IconColor = System.Drawing.Color.Gainsboro;
            this.exitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitButton.IconSize = 25;
            this.exitButton.Location = new System.Drawing.Point(721, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(31, 31);
            this.exitButton.TabIndex = 1;
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get and Classification Files";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(214, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 9);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.buttonPullAndPush);
            this.panel4.Controls.Add(this.checkBoxClassification);
            this.panel4.Controls.Add(this.buttonGetFiles);
            this.panel4.Controls.Add(this.selectDestination);
            this.panel4.Controls.Add(this.buttonSelectFiles);
            this.panel4.Controls.Add(this.selectSourceLocalFile);
            this.panel4.Controls.Add(this.SVNconf);
            this.panel4.Controls.Add(this.sourceLocalFile);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.buttonCopyAndClassification);
            this.panel4.Controls.Add(this.destination);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(214, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(756, 421);
            this.panel4.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(170, 336);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(506, 1);
            this.panel5.TabIndex = 32;
            // 
            // buttonPullAndPush
            // 
            this.buttonPullAndPush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPullAndPush.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPullAndPush.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonPullAndPush.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.buttonPullAndPush.IconColor = System.Drawing.Color.Gainsboro;
            this.buttonPullAndPush.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonPullAndPush.IconSize = 32;
            this.buttonPullAndPush.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPullAndPush.Location = new System.Drawing.Point(321, 352);
            this.buttonPullAndPush.Name = "buttonPullAndPush";
            this.buttonPullAndPush.Size = new System.Drawing.Size(193, 57);
            this.buttonPullAndPush.TabIndex = 31;
            this.buttonPullAndPush.Text = "Go to Sync With SVN";
            this.buttonPullAndPush.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPullAndPush.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPullAndPush.UseVisualStyleBackColor = true;
            this.buttonPullAndPush.Click += new System.EventHandler(this.ButtonPullAndPush_Click);
            // 
            // checkBoxClassification
            // 
            this.checkBoxClassification.AutoSize = true;
            this.checkBoxClassification.Checked = true;
            this.checkBoxClassification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClassification.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxClassification.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxClassification.Location = new System.Drawing.Point(366, 290);
            this.checkBoxClassification.Name = "checkBoxClassification";
            this.checkBoxClassification.Size = new System.Drawing.Size(135, 21);
            this.checkBoxClassification.TabIndex = 30;
            this.checkBoxClassification.Text = "Do Classification";
            this.checkBoxClassification.UseVisualStyleBackColor = true;
            // 
            // buttonGetFiles
            // 
            this.buttonGetFiles.FlatAppearance.BorderSize = 0;
            this.buttonGetFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetFiles.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonGetFiles.IconChar = FontAwesome.Sharp.IconChar.Clone;
            this.buttonGetFiles.IconColor = System.Drawing.Color.Gainsboro;
            this.buttonGetFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonGetFiles.IconSize = 32;
            this.buttonGetFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetFiles.Location = new System.Drawing.Point(181, 271);
            this.buttonGetFiles.Name = "buttonGetFiles";
            this.buttonGetFiles.Size = new System.Drawing.Size(154, 53);
            this.buttonGetFiles.TabIndex = 29;
            this.buttonGetFiles.Text = "Get Files";
            this.buttonGetFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGetFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGetFiles.UseVisualStyleBackColor = true;
            this.buttonGetFiles.Click += new System.EventHandler(this.ButtonGetFiles_Click);
            // 
            // selectDestination
            // 
            this.selectDestination.FlatAppearance.BorderSize = 0;
            this.selectDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDestination.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDestination.ForeColor = System.Drawing.Color.Gainsboro;
            this.selectDestination.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.selectDestination.IconColor = System.Drawing.Color.Gainsboro;
            this.selectDestination.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.selectDestination.IconSize = 32;
            this.selectDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectDestination.Location = new System.Drawing.Point(181, 221);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(185, 44);
            this.selectDestination.TabIndex = 28;
            this.selectDestination.Text = "Select Destination";
            this.selectDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectDestination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectDestination.UseVisualStyleBackColor = true;
            this.selectDestination.Click += new System.EventHandler(this.Select_Destination_Click);
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.FlatAppearance.BorderSize = 0;
            this.buttonSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectFiles.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectFiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSelectFiles.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.buttonSelectFiles.IconColor = System.Drawing.Color.Gainsboro;
            this.buttonSelectFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonSelectFiles.IconSize = 32;
            this.buttonSelectFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectFiles.Location = new System.Drawing.Point(181, 164);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.buttonSelectFiles.Size = new System.Drawing.Size(137, 51);
            this.buttonSelectFiles.TabIndex = 27;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSelectFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.SelectFiles_Click);
            // 
            // selectSourceLocalFile
            // 
            this.selectSourceLocalFile.FlatAppearance.BorderSize = 0;
            this.selectSourceLocalFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectSourceLocalFile.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectSourceLocalFile.ForeColor = System.Drawing.Color.Gainsboro;
            this.selectSourceLocalFile.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            this.selectSourceLocalFile.IconColor = System.Drawing.Color.Gainsboro;
            this.selectSourceLocalFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.selectSourceLocalFile.IconSize = 32;
            this.selectSourceLocalFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectSourceLocalFile.Location = new System.Drawing.Point(181, 107);
            this.selectSourceLocalFile.Name = "selectSourceLocalFile";
            this.selectSourceLocalFile.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.selectSourceLocalFile.Size = new System.Drawing.Size(137, 51);
            this.selectSourceLocalFile.TabIndex = 26;
            this.selectSourceLocalFile.Text = "Select Source";
            this.selectSourceLocalFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectSourceLocalFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectSourceLocalFile.UseVisualStyleBackColor = true;
            this.selectSourceLocalFile.Visible = false;
            this.selectSourceLocalFile.Click += new System.EventHandler(this.SelectSourceLocalFile_Click);
            // 
            // SVNconf
            // 
            this.SVNconf.Controls.Add(this.url);
            this.SVNconf.Controls.Add(this.PasswordTestBox1);
            this.SVNconf.Controls.Add(this.sourceSVN);
            this.SVNconf.Controls.Add(this.Password);
            this.SVNconf.Controls.Add(this.UserName);
            this.SVNconf.Controls.Add(this.UserNameTextBox1);
            this.SVNconf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SVNconf.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SVNconf.ForeColor = System.Drawing.Color.Gainsboro;
            this.SVNconf.Location = new System.Drawing.Point(181, 7);
            this.SVNconf.Name = "SVNconf";
            this.SVNconf.Size = new System.Drawing.Size(520, 94);
            this.SVNconf.TabIndex = 23;
            this.SVNconf.TabStop = false;
            this.SVNconf.Text = "SVN";
            this.SVNconf.Visible = false;
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.url.Location = new System.Drawing.Point(17, 21);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(30, 17);
            this.url.TabIndex = 12;
            this.url.Text = "URL";
            // 
            // PasswordTestBox1
            // 
            this.PasswordTestBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTestBox1.Location = new System.Drawing.Point(361, 57);
            this.PasswordTestBox1.Name = "PasswordTestBox1";
            this.PasswordTestBox1.Size = new System.Drawing.Size(135, 16);
            this.PasswordTestBox1.TabIndex = 11;
            this.PasswordTestBox1.UseSystemPasswordChar = true;
            // 
            // sourceSVN
            // 
            this.sourceSVN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceSVN.Location = new System.Drawing.Point(53, 19);
            this.sourceSVN.Name = "sourceSVN";
            this.sourceSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceSVN.Size = new System.Drawing.Size(442, 16);
            this.sourceSVN.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(286, 59);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(69, 17);
            this.Password.TabIndex = 10;
            this.Password.Text = "Password";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(18, 56);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(77, 17);
            this.UserName.TabIndex = 8;
            this.UserName.Text = "User Name";
            // 
            // UserNameTextBox1
            // 
            this.UserNameTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameTextBox1.Location = new System.Drawing.Point(101, 54);
            this.UserNameTextBox1.Name = "UserNameTextBox1";
            this.UserNameTextBox1.Size = new System.Drawing.Size(141, 16);
            this.UserNameTextBox1.TabIndex = 9;
            // 
            // sourceLocalFile
            // 
            this.sourceLocalFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceLocalFile.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourceLocalFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sourceLocalFile.Location = new System.Drawing.Point(366, 124);
            this.sourceLocalFile.Name = "sourceLocalFile";
            this.sourceLocalFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceLocalFile.Size = new System.Drawing.Size(310, 16);
            this.sourceLocalFile.TabIndex = 22;
            this.sourceLocalFile.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localFiles);
            this.groupBox1.Controls.Add(this.svn);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Location = new System.Drawing.Point(16, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 151);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // localFiles
            // 
            this.localFiles.AutoSize = true;
            this.localFiles.Location = new System.Drawing.Point(18, 101);
            this.localFiles.Name = "localFiles";
            this.localFiles.Size = new System.Drawing.Size(88, 21);
            this.localFiles.TabIndex = 1;
            this.localFiles.TabStop = true;
            this.localFiles.Text = "Local files";
            this.localFiles.UseVisualStyleBackColor = true;
            this.localFiles.CheckedChanged += new System.EventHandler(this.LocalFiles_CheckedChanged);
            // 
            // svn
            // 
            this.svn.AutoSize = true;
            this.svn.ForeColor = System.Drawing.Color.Gainsboro;
            this.svn.Location = new System.Drawing.Point(18, 26);
            this.svn.Name = "svn";
            this.svn.Size = new System.Drawing.Size(51, 21);
            this.svn.TabIndex = 0;
            this.svn.TabStop = true;
            this.svn.Text = "SVN";
            this.svn.UseVisualStyleBackColor = true;
            this.svn.CheckedChanged += new System.EventHandler(this.Svn_CheckedChanged);
            // 
            // buttonCopyAndClassification
            // 
            this.buttonCopyAndClassification.Location = new System.Drawing.Point(34, 372);
            this.buttonCopyAndClassification.Name = "buttonCopyAndClassification";
            this.buttonCopyAndClassification.Size = new System.Drawing.Size(180, 37);
            this.buttonCopyAndClassification.TabIndex = 20;
            this.buttonCopyAndClassification.Text = "Copy and Classification";
            this.buttonCopyAndClassification.UseVisualStyleBackColor = true;
            this.buttonCopyAndClassification.Visible = false;
            // 
            // destination
            // 
            this.destination.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.destination.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destination.Location = new System.Drawing.Point(366, 234);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(310, 16);
            this.destination.TabIndex = 19;
            // 
            // PandCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(970, 510);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "PandCForm";
            this.Text = "Copy And Classification";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDestination)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.SVNconf.ResumeLayout(false);
            this.SVNconf.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderSource;
        private System.Windows.Forms.ErrorProvider errorProviderDestination;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton selectSourceLocalFile;
        private System.Windows.Forms.GroupBox SVNconf;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.TextBox PasswordTestBox1;
        private System.Windows.Forms.TextBox sourceSVN;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox UserNameTextBox1;
        private System.Windows.Forms.TextBox sourceLocalFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton localFiles;
        private System.Windows.Forms.RadioButton svn;
        private System.Windows.Forms.Button buttonCopyAndClassification;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton maximizeButton;
        private FontAwesome.Sharp.IconButton exitButton;
        private FontAwesome.Sharp.IconButton minimizeButton;
        private FontAwesome.Sharp.IconButton buttonSelectFiles;
        private FontAwesome.Sharp.IconButton selectDestination;
        private System.Windows.Forms.CheckBox checkBoxClassification;
        private FontAwesome.Sharp.IconButton buttonGetFiles;
        private FontAwesome.Sharp.IconButton buttonPullAndPush;
        private System.Windows.Forms.Panel panel5;
    }
}

