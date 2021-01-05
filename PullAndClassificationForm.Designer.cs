
namespace WindowsFormsApp1
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
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.sourceSVN = new System.Windows.Forms.TextBox();
            this.selectDestination = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            this.buttonCopyAndClassification = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localFiles = new System.Windows.Forms.RadioButton();
            this.svn = new System.Windows.Forms.RadioButton();
            this.selectSourceLocalFile = new System.Windows.Forms.Button();
            this.sourceLocalFile = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.Label();
            this.UserNameTextBox1 = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.PasswordTestBox1 = new System.Windows.Forms.TextBox();
            this.SVNconf = new System.Windows.Forms.GroupBox();
            this.url = new System.Windows.Forms.Label();
            this.pushToSvn = new System.Windows.Forms.Button();
            this.PasswordTestBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserNameTextBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDestSVN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SVNconf.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(206, 205);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(201, 37);
            this.buttonSelectFiles.TabIndex = 0;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.SelectFiles_Click);
            // 
            // sourceSVN
            // 
            this.sourceSVN.Location = new System.Drawing.Point(108, 19);
            this.sourceSVN.Name = "sourceSVN";
            this.sourceSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceSVN.Size = new System.Drawing.Size(359, 20);
            this.sourceSVN.TabIndex = 1;
            this.sourceSVN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // selectDestination
            // 
            this.selectDestination.Location = new System.Drawing.Point(537, 268);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(121, 32);
            this.selectDestination.TabIndex = 2;
            this.selectDestination.Text = "Select Destination";
            this.selectDestination.UseVisualStyleBackColor = true;
            this.selectDestination.Click += new System.EventHandler(this.Select_Destination_Click);
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(53, 275);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(478, 20);
            this.destination.TabIndex = 3;
            this.destination.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonCopyAndClassification
            // 
            this.buttonCopyAndClassification.Location = new System.Drawing.Point(53, 316);
            this.buttonCopyAndClassification.Name = "buttonCopyAndClassification";
            this.buttonCopyAndClassification.Size = new System.Drawing.Size(605, 37);
            this.buttonCopyAndClassification.TabIndex = 4;
            this.buttonCopyAndClassification.Text = "Copy and Classification";
            this.buttonCopyAndClassification.UseVisualStyleBackColor = true;
            this.buttonCopyAndClassification.Click += new System.EventHandler(this.Copy_and_Classification_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localFiles);
            this.groupBox1.Controls.Add(this.svn);
            this.groupBox1.Location = new System.Drawing.Point(562, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 143);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // localFiles
            // 
            this.localFiles.AutoSize = true;
            this.localFiles.Location = new System.Drawing.Point(18, 106);
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
            this.svn.Location = new System.Drawing.Point(18, 26);
            this.svn.Name = "svn";
            this.svn.Size = new System.Drawing.Size(44, 17);
            this.svn.TabIndex = 0;
            this.svn.TabStop = true;
            this.svn.Text = "SVN";
            this.svn.UseVisualStyleBackColor = true;
            this.svn.CheckedChanged += new System.EventHandler(this.Svn_CheckedChanged);
            // 
            // selectSourceLocalFile
            // 
            this.selectSourceLocalFile.Location = new System.Drawing.Point(422, 160);
            this.selectSourceLocalFile.Name = "selectSourceLocalFile";
            this.selectSourceLocalFile.Size = new System.Drawing.Size(121, 20);
            this.selectSourceLocalFile.TabIndex = 6;
            this.selectSourceLocalFile.Text = "Select Source";
            this.selectSourceLocalFile.UseVisualStyleBackColor = true;
            this.selectSourceLocalFile.Visible = false;
            this.selectSourceLocalFile.Click += new System.EventHandler(this.SelectSourceLocalFile_Click);
            // 
            // sourceLocalFile
            // 
            this.sourceLocalFile.Location = new System.Drawing.Point(48, 162);
            this.sourceLocalFile.Name = "sourceLocalFile";
            this.sourceLocalFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceLocalFile.Size = new System.Drawing.Size(359, 20);
            this.sourceLocalFile.TabIndex = 7;
            this.sourceLocalFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sourceLocalFile.Visible = false;
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(105, 48);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(59, 13);
            this.UserName.TabIndex = 8;
            this.UserName.Text = "User Name";
            // 
            // UserNameTextBox1
            // 
            this.UserNameTextBox1.Location = new System.Drawing.Point(170, 45);
            this.UserNameTextBox1.Name = "UserNameTextBox1";
            this.UserNameTextBox1.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox1.TabIndex = 9;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(308, 48);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 10;
            this.Password.Text = "Password";
            // 
            // PasswordTestBox1
            // 
            this.PasswordTestBox1.Location = new System.Drawing.Point(367, 45);
            this.PasswordTestBox1.Name = "PasswordTestBox1";
            this.PasswordTestBox1.Size = new System.Drawing.Size(100, 20);
            this.PasswordTestBox1.TabIndex = 11;
            this.PasswordTestBox1.UseSystemPasswordChar = true;
            // 
            // SVNconf
            // 
            this.SVNconf.Controls.Add(this.url);
            this.SVNconf.Controls.Add(this.PasswordTestBox1);
            this.SVNconf.Controls.Add(this.sourceSVN);
            this.SVNconf.Controls.Add(this.Password);
            this.SVNconf.Controls.Add(this.UserName);
            this.SVNconf.Controls.Add(this.UserNameTextBox1);
            this.SVNconf.Location = new System.Drawing.Point(36, 54);
            this.SVNconf.Name = "SVNconf";
            this.SVNconf.Size = new System.Drawing.Size(520, 100);
            this.SVNconf.TabIndex = 12;
            this.SVNconf.TabStop = false;
            this.SVNconf.Text = "SVN";
            this.SVNconf.Visible = false;
            // 
            // url
            // 
            this.url.AutoSize = true;
            this.url.Location = new System.Drawing.Point(76, 22);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(26, 13);
            this.url.TabIndex = 12;
            this.url.Text = "URL";
            // 
            // pushToSvn
            // 
            this.pushToSvn.Location = new System.Drawing.Point(422, 438);
            this.pushToSvn.Name = "pushToSvn";
            this.pushToSvn.Size = new System.Drawing.Size(236, 46);
            this.pushToSvn.TabIndex = 13;
            this.pushToSvn.Text = "Push to SVN";
            this.pushToSvn.UseVisualStyleBackColor = true;
            this.pushToSvn.Click += new System.EventHandler(this.PushToSvn_Click);
            // 
            // PasswordTestBox2
            // 
            this.PasswordTestBox2.Location = new System.Drawing.Point(306, 464);
            this.PasswordTestBox2.Name = "PasswordTestBox2";
            this.PasswordTestBox2.Size = new System.Drawing.Size(100, 20);
            this.PasswordTestBox2.TabIndex = 14;
            this.PasswordTestBox2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // UserNameTextBox2
            // 
            this.UserNameTextBox2.Location = new System.Drawing.Point(115, 464);
            this.UserNameTextBox2.Name = "UserNameTextBox2";
            this.UserNameTextBox2.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 467);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "User Name";
            // 
            // textBoxDestSVN
            // 
            this.textBoxDestSVN.Location = new System.Drawing.Point(91, 438);
            this.textBoxDestSVN.Name = "textBoxDestSVN";
            this.textBoxDestSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDestSVN.Size = new System.Drawing.Size(316, 20);
            this.textBoxDestSVN.TabIndex = 15;
            this.textBoxDestSVN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "URL";
            // 
            // PandCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDestSVN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSelectFiles);
            this.Controls.Add(this.UserNameTextBox2);
            this.Controls.Add(this.PasswordTestBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pushToSvn);
            this.Controls.Add(this.SVNconf);
            this.Controls.Add(this.sourceLocalFile);
            this.Controls.Add(this.selectSourceLocalFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCopyAndClassification);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.selectDestination);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PandCForm";
            this.Text = "Pull And Classification";
            this.Load += new System.EventHandler(this.PandCForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SVNconf.ResumeLayout(false);
            this.SVNconf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.TextBox sourceSVN;
        private System.Windows.Forms.Button selectDestination;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button buttonCopyAndClassification;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton localFiles;
        private System.Windows.Forms.RadioButton svn;
        private System.Windows.Forms.Button selectSourceLocalFile;
        private System.Windows.Forms.TextBox sourceLocalFile;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox UserNameTextBox1;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox PasswordTestBox1;
        private System.Windows.Forms.GroupBox SVNconf;
        private System.Windows.Forms.Label url;
        private System.Windows.Forms.Button pushToSvn;
        private System.Windows.Forms.TextBox PasswordTestBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserNameTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDestSVN;
        private System.Windows.Forms.Label label1;
    }
}

