
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
            this.selectSourceSVN = new System.Windows.Forms.Button();
            this.sourceSVN = new System.Windows.Forms.TextBox();
            this.selectDestination = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localFiles = new System.Windows.Forms.RadioButton();
            this.svn = new System.Windows.Forms.RadioButton();
            this.selectSourceLocalFile = new System.Windows.Forms.Button();
            this.sourceLocalFile = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectSourceSVN
            // 
            this.selectSourceSVN.Location = new System.Drawing.Point(422, 124);
            this.selectSourceSVN.Name = "selectSourceSVN";
            this.selectSourceSVN.Size = new System.Drawing.Size(121, 20);
            this.selectSourceSVN.TabIndex = 0;
            this.selectSourceSVN.Text = "Select Source";
            this.selectSourceSVN.UseVisualStyleBackColor = true;
            this.selectSourceSVN.Visible = false;
            this.selectSourceSVN.Click += new System.EventHandler(this.selectSourceSvn_Click);
            // 
            // sourceSVN
            // 
            this.sourceSVN.Location = new System.Drawing.Point(48, 125);
            this.sourceSVN.Name = "sourceSVN";
            this.sourceSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sourceSVN.Size = new System.Drawing.Size(359, 20);
            this.sourceSVN.TabIndex = 1;
            this.sourceSVN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sourceSVN.Visible = false;
            // 
            // selectDestination
            // 
            this.selectDestination.Location = new System.Drawing.Point(422, 205);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(121, 20);
            this.selectDestination.TabIndex = 2;
            this.selectDestination.Text = "Select Destination";
            this.selectDestination.UseVisualStyleBackColor = true;
            this.selectDestination.Click += new System.EventHandler(this.Select_Destination_Click);
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(48, 206);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(359, 20);
            this.destination.TabIndex = 3;
            this.destination.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pull and Classification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Pull_and_Classification_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localFiles);
            this.groupBox1.Controls.Add(this.svn);
            this.groupBox1.Location = new System.Drawing.Point(562, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 83);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // localFiles
            // 
            this.localFiles.AutoSize = true;
            this.localFiles.Location = new System.Drawing.Point(18, 62);
            this.localFiles.Name = "localFiles";
            this.localFiles.Size = new System.Drawing.Size(71, 17);
            this.localFiles.TabIndex = 1;
            this.localFiles.TabStop = true;
            this.localFiles.Text = "Local files";
            this.localFiles.UseVisualStyleBackColor = true;
            this.localFiles.CheckedChanged += new System.EventHandler(this.localFiles_CheckedChanged);
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
            this.svn.CheckedChanged += new System.EventHandler(this.svn_CheckedChanged);
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
            this.selectSourceLocalFile.Click += new System.EventHandler(this.selectSourceLocalFile_Click);
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
            // PandCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sourceLocalFile);
            this.Controls.Add(this.selectSourceLocalFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.selectDestination);
            this.Controls.Add(this.sourceSVN);
            this.Controls.Add(this.selectSourceSVN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PandCForm";
            this.Text = "Pull And Classification";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectSourceSVN;
        private System.Windows.Forms.TextBox sourceSVN;
        private System.Windows.Forms.Button selectDestination;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton localFiles;
        private System.Windows.Forms.RadioButton svn;
        private System.Windows.Forms.Button selectSourceLocalFile;
        private System.Windows.Forms.TextBox sourceLocalFile;
    }
}

