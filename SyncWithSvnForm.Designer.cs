
namespace PullAndClassification.Forms
{
    partial class SyncWithSvnForm
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
            this.syncWithSvn = new FontAwesome.Sharp.IconButton();
            this.buttonSelectedFilesOk = new System.Windows.Forms.Button();
            this.iconCloneButton = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroDestinationTextBox = new MetroFramework.Controls.MetroTextBox();
            this.selectDestination = new FontAwesome.Sharp.IconButton();
            this.metroLabelRepoUrl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroUserNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.Push = new System.Windows.Forms.GroupBox();
            this.metroFromTextBox = new MetroFramework.Controls.MetroTextBox();
            this.buttonFrom = new FontAwesome.Sharp.IconButton();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1.SuspendLayout();
            this.Push.SuspendLayout();
            this.SuspendLayout();
            // 
            // syncWithSvn
            // 
            this.syncWithSvn.FlatAppearance.BorderSize = 0;
            this.syncWithSvn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.syncWithSvn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncWithSvn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.syncWithSvn.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.syncWithSvn.IconColor = System.Drawing.Color.Black;
            this.syncWithSvn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.syncWithSvn.IconSize = 30;
            this.syncWithSvn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncWithSvn.Location = new System.Drawing.Point(278, 63);
            this.syncWithSvn.Name = "syncWithSvn";
            this.syncWithSvn.Size = new System.Drawing.Size(80, 34);
            this.syncWithSvn.TabIndex = 26;
            this.syncWithSvn.Text = "Push";
            this.syncWithSvn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.syncWithSvn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.syncWithSvn.UseVisualStyleBackColor = true;
            this.syncWithSvn.Click += new System.EventHandler(this.PushToSvn_Click);
            // 
            // buttonSelectedFilesOk
            // 
            this.buttonSelectedFilesOk.FlatAppearance.BorderSize = 0;
            this.buttonSelectedFilesOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.buttonSelectedFilesOk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectedFilesOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSelectedFilesOk.Location = new System.Drawing.Point(594, 420);
            this.buttonSelectedFilesOk.Name = "buttonSelectedFilesOk";
            this.buttonSelectedFilesOk.Size = new System.Drawing.Size(61, 30);
            this.buttonSelectedFilesOk.TabIndex = 27;
            this.buttonSelectedFilesOk.Text = "Close";
            this.buttonSelectedFilesOk.UseVisualStyleBackColor = true;
            this.buttonSelectedFilesOk.Click += new System.EventHandler(this.ButtonSelectedFilesOk_Click);
            // 
            // iconCloneButton
            // 
            this.iconCloneButton.FlatAppearance.BorderSize = 0;
            this.iconCloneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.iconCloneButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconCloneButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconCloneButton.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.iconCloneButton.IconColor = System.Drawing.Color.Black;
            this.iconCloneButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCloneButton.IconSize = 30;
            this.iconCloneButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconCloneButton.Location = new System.Drawing.Point(277, 57);
            this.iconCloneButton.Name = "iconCloneButton";
            this.iconCloneButton.Size = new System.Drawing.Size(80, 34);
            this.iconCloneButton.TabIndex = 28;
            this.iconCloneButton.Text = "Clone";
            this.iconCloneButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconCloneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconCloneButton.UseVisualStyleBackColor = true;
            this.iconCloneButton.Click += new System.EventHandler(this.IconCloneButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroDestinationTextBox);
            this.groupBox1.Controls.Add(this.selectDestination);
            this.groupBox1.Controls.Add(this.iconCloneButton);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(40, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 105);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clone";
            // 
            // metroDestinationTextBox
            // 
            // 
            // 
            // 
            this.metroDestinationTextBox.CustomButton.Image = null;
            this.metroDestinationTextBox.CustomButton.Location = new System.Drawing.Point(465, 1);
            this.metroDestinationTextBox.CustomButton.Name = "";
            this.metroDestinationTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroDestinationTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroDestinationTextBox.CustomButton.TabIndex = 1;
            this.metroDestinationTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroDestinationTextBox.CustomButton.UseSelectable = true;
            this.metroDestinationTextBox.CustomButton.Visible = false;
            this.metroDestinationTextBox.Lines = new string[0];
            this.metroDestinationTextBox.Location = new System.Drawing.Point(111, 28);
            this.metroDestinationTextBox.MaxLength = 32767;
            this.metroDestinationTextBox.Name = "metroDestinationTextBox";
            this.metroDestinationTextBox.PasswordChar = '\0';
            this.metroDestinationTextBox.ReadOnly = true;
            this.metroDestinationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroDestinationTextBox.SelectedText = "";
            this.metroDestinationTextBox.SelectionLength = 0;
            this.metroDestinationTextBox.SelectionStart = 0;
            this.metroDestinationTextBox.ShortcutsEnabled = true;
            this.metroDestinationTextBox.Size = new System.Drawing.Size(487, 23);
            this.metroDestinationTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroDestinationTextBox.TabIndex = 35;
            this.metroDestinationTextBox.UseSelectable = true;
            this.metroDestinationTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroDestinationTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // selectDestination
            // 
            this.selectDestination.BackColor = System.Drawing.Color.Transparent;
            this.selectDestination.Enabled = false;
            this.selectDestination.FlatAppearance.BorderSize = 0;
            this.selectDestination.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.selectDestination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDestination.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDestination.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.selectDestination.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.selectDestination.IconColor = System.Drawing.Color.Black;
            this.selectDestination.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.selectDestination.IconSize = 30;
            this.selectDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectDestination.Location = new System.Drawing.Point(11, 22);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(68, 34);
            this.selectDestination.TabIndex = 32;
            this.selectDestination.Text = "To";
            this.selectDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectDestination.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectDestination.UseVisualStyleBackColor = false;
            this.selectDestination.Click += new System.EventHandler(this.SelectDestination_Click);
            // 
            // metroLabelRepoUrl
            // 
            this.metroLabelRepoUrl.AutoSize = true;
            this.metroLabelRepoUrl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelRepoUrl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.metroLabelRepoUrl.Location = new System.Drawing.Point(386, 156);
            this.metroLabelRepoUrl.Name = "metroLabelRepoUrl";
            this.metroLabelRepoUrl.Size = new System.Drawing.Size(0, 0);
            this.metroLabelRepoUrl.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelRepoUrl.TabIndex = 39;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(378, 115);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "Password";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(61, 111);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(75, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 37;
            this.metroLabel2.Text = "User Name";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroLabel1.Location = new System.Drawing.Point(287, 156);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(67, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 36;
            this.metroLabel1.Text = "Repo URL";
            // 
            // metroPasswordTextBox
            // 
            // 
            // 
            // 
            this.metroPasswordTextBox.CustomButton.Image = null;
            this.metroPasswordTextBox.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.metroPasswordTextBox.CustomButton.Name = "";
            this.metroPasswordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroPasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPasswordTextBox.CustomButton.TabIndex = 1;
            this.metroPasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPasswordTextBox.CustomButton.UseSelectable = true;
            this.metroPasswordTextBox.CustomButton.Visible = false;
            this.metroPasswordTextBox.Lines = new string[0];
            this.metroPasswordTextBox.Location = new System.Drawing.Point(453, 111);
            this.metroPasswordTextBox.MaxLength = 32767;
            this.metroPasswordTextBox.Name = "metroPasswordTextBox";
            this.metroPasswordTextBox.PasswordChar = '●';
            this.metroPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroPasswordTextBox.SelectedText = "";
            this.metroPasswordTextBox.SelectionLength = 0;
            this.metroPasswordTextBox.SelectionStart = 0;
            this.metroPasswordTextBox.ShortcutsEnabled = true;
            this.metroPasswordTextBox.Size = new System.Drawing.Size(202, 23);
            this.metroPasswordTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPasswordTextBox.TabIndex = 34;
            this.metroPasswordTextBox.UseSelectable = true;
            this.metroPasswordTextBox.UseSystemPasswordChar = true;
            this.metroPasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroPasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroUserNameTextBox
            // 
            // 
            // 
            // 
            this.metroUserNameTextBox.CustomButton.Image = null;
            this.metroUserNameTextBox.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.metroUserNameTextBox.CustomButton.Name = "";
            this.metroUserNameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroUserNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroUserNameTextBox.CustomButton.TabIndex = 1;
            this.metroUserNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroUserNameTextBox.CustomButton.UseSelectable = true;
            this.metroUserNameTextBox.CustomButton.Visible = false;
            this.metroUserNameTextBox.Lines = new string[0];
            this.metroUserNameTextBox.Location = new System.Drawing.Point(150, 111);
            this.metroUserNameTextBox.MaxLength = 32767;
            this.metroUserNameTextBox.Name = "metroUserNameTextBox";
            this.metroUserNameTextBox.PasswordChar = '\0';
            this.metroUserNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroUserNameTextBox.SelectedText = "";
            this.metroUserNameTextBox.SelectionLength = 0;
            this.metroUserNameTextBox.SelectionStart = 0;
            this.metroUserNameTextBox.ShortcutsEnabled = true;
            this.metroUserNameTextBox.Size = new System.Drawing.Size(202, 23);
            this.metroUserNameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroUserNameTextBox.TabIndex = 33;
            this.metroUserNameTextBox.UseSelectable = true;
            this.metroUserNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroUserNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Push
            // 
            this.Push.Controls.Add(this.metroFromTextBox);
            this.Push.Controls.Add(this.syncWithSvn);
            this.Push.Controls.Add(this.buttonFrom);
            this.Push.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Push.ForeColor = System.Drawing.Color.Black;
            this.Push.Location = new System.Drawing.Point(39, 306);
            this.Push.Name = "Push";
            this.Push.Size = new System.Drawing.Size(616, 108);
            this.Push.TabIndex = 30;
            this.Push.TabStop = false;
            this.Push.Text = "Push";
            // 
            // metroFromTextBox
            // 
            // 
            // 
            // 
            this.metroFromTextBox.CustomButton.Image = null;
            this.metroFromTextBox.CustomButton.Location = new System.Drawing.Point(465, 1);
            this.metroFromTextBox.CustomButton.Name = "";
            this.metroFromTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroFromTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroFromTextBox.CustomButton.TabIndex = 1;
            this.metroFromTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroFromTextBox.CustomButton.UseSelectable = true;
            this.metroFromTextBox.CustomButton.Visible = false;
            this.metroFromTextBox.Lines = new string[0];
            this.metroFromTextBox.Location = new System.Drawing.Point(112, 26);
            this.metroFromTextBox.MaxLength = 32767;
            this.metroFromTextBox.Name = "metroFromTextBox";
            this.metroFromTextBox.PasswordChar = '\0';
            this.metroFromTextBox.ReadOnly = true;
            this.metroFromTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroFromTextBox.SelectedText = "";
            this.metroFromTextBox.SelectionLength = 0;
            this.metroFromTextBox.SelectionStart = 0;
            this.metroFromTextBox.ShortcutsEnabled = true;
            this.metroFromTextBox.Size = new System.Drawing.Size(487, 23);
            this.metroFromTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroFromTextBox.TabIndex = 39;
            this.metroFromTextBox.UseSelectable = true;
            this.metroFromTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroFromTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonFrom
            // 
            this.buttonFrom.BackColor = System.Drawing.Color.Transparent;
            this.buttonFrom.Enabled = false;
            this.buttonFrom.FlatAppearance.BorderSize = 0;
            this.buttonFrom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonFrom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.buttonFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFrom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFrom.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.buttonFrom.IconColor = System.Drawing.Color.Black;
            this.buttonFrom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonFrom.IconSize = 30;
            this.buttonFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFrom.Location = new System.Drawing.Point(12, 22);
            this.buttonFrom.Name = "buttonFrom";
            this.buttonFrom.Size = new System.Drawing.Size(86, 33);
            this.buttonFrom.TabIndex = 25;
            this.buttonFrom.Text = "From";
            this.buttonFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFrom.UseVisualStyleBackColor = false;
            this.buttonFrom.Click += new System.EventHandler(this.ButtonFrom_Click);
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelProjectName.Location = new System.Drawing.Point(369, 30);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(94, 19);
            this.metroLabelProjectName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelProjectName.TabIndex = 31;
            this.metroLabelProjectName.Text = "metroLabel1";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(265, 30);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(98, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 32;
            this.metroLabel4.Text = "Current Project";
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 23;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(264, 62);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.PromptText = "Select Project";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(202, 29);
            this.metroProjectListComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProjectListComboBox.TabIndex = 40;
            this.metroProjectListComboBox.UseSelectable = true;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            this.metroProjectListComboBox.Click += new System.EventHandler(this.MetroProjectListComboBox_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(40, 293);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.metroProgressBar1.Size = new System.Drawing.Size(530, 10);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Teal;
            this.metroProgressBar1.TabIndex = 41;
            this.metroProgressBar1.Visible = false;
            // 
            // metroLabel6
            // 
            metroLabel6.AutoSize = true;
            metroLabel6.BackColor = System.Drawing.Color.Transparent;
            metroLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            metroLabel6.Location = new System.Drawing.Point(576, 285);
            metroLabel6.Name = "metroLabel6";
            metroLabel6.Size = new System.Drawing.Size(0, 0);
            metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel6.TabIndex = 43;
            // 
            // SyncWithSvnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 464);
            this.Controls.Add(metroLabel6);
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelRepoUrl);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.Push);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSelectedFilesOk);
            this.Controls.Add(this.metroPasswordTextBox);
            this.Controls.Add(this.metroUserNameTextBox);
            this.Name = "SyncWithSvnForm";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.Text = "Sync SVN Form";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.PullAndPushForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.Push.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton syncWithSvn;
        private System.Windows.Forms.Button buttonSelectedFilesOk;
        private FontAwesome.Sharp.IconButton iconCloneButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton selectDestination;
        private System.Windows.Forms.GroupBox Push;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroDestinationTextBox;
        private MetroFramework.Controls.MetroTextBox metroPasswordTextBox;
        private MetroFramework.Controls.MetroTextBox metroUserNameTextBox;
        private MetroFramework.Controls.MetroLabel metroLabelRepoUrl;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox metroFromTextBox;
        private FontAwesome.Sharp.IconButton buttonFrom;
        private MetroFramework.Controls.MetroComboBox metroProjectListComboBox;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        public static MetroFramework.Controls.MetroLabel metroLabel6;
    }
}