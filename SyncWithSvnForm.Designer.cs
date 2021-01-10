
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDestSVN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UserNameTextBox2 = new System.Windows.Forms.TextBox();
            this.PasswordTestBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.buttonFrom = new FontAwesome.Sharp.IconButton();
            this.syncWithSvn = new FontAwesome.Sharp.IconButton();
            this.buttonSelectedFilesOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(226, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "URL";
            // 
            // textBoxDestSVN
            // 
            this.textBoxDestSVN.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestSVN.Location = new System.Drawing.Point(262, 124);
            this.textBoxDestSVN.Name = "textBoxDestSVN";
            this.textBoxDestSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDestSVN.Size = new System.Drawing.Size(367, 23);
            this.textBoxDestSVN.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(226, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "User Name";
            // 
            // UserNameTextBox2
            // 
            this.UserNameTextBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox2.Location = new System.Drawing.Point(309, 153);
            this.UserNameTextBox2.Name = "UserNameTextBox2";
            this.UserNameTextBox2.Size = new System.Drawing.Size(100, 23);
            this.UserNameTextBox2.TabIndex = 18;
            // 
            // PasswordTestBox2
            // 
            this.PasswordTestBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTestBox2.Location = new System.Drawing.Point(529, 153);
            this.PasswordTestBox2.Name = "PasswordTestBox2";
            this.PasswordTestBox2.Size = new System.Drawing.Size(100, 23);
            this.PasswordTestBox2.TabIndex = 21;
            this.PasswordTestBox2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(442, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Password";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFrom.Location = new System.Drawing.Point(229, 68);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.ReadOnly = true;
            this.textBoxFrom.Size = new System.Drawing.Size(400, 23);
            this.textBoxFrom.TabIndex = 24;
            // 
            // buttonFrom
            // 
            this.buttonFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.buttonFrom.FlatAppearance.BorderSize = 0;
            this.buttonFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFrom.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFrom.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonFrom.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.buttonFrom.IconColor = System.Drawing.Color.Gainsboro;
            this.buttonFrom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonFrom.IconSize = 32;
            this.buttonFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFrom.Location = new System.Drawing.Point(76, 52);
            this.buttonFrom.Name = "buttonFrom";
            this.buttonFrom.Size = new System.Drawing.Size(113, 55);
            this.buttonFrom.TabIndex = 25;
            this.buttonFrom.Text = "From";
            this.buttonFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFrom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFrom.UseVisualStyleBackColor = false;
            this.buttonFrom.Click += new System.EventHandler(this.ButtonFrom_Click);
            // 
            // syncWithSvn
            // 
            this.syncWithSvn.FlatAppearance.BorderSize = 0;
            this.syncWithSvn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.syncWithSvn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syncWithSvn.ForeColor = System.Drawing.Color.Gainsboro;
            this.syncWithSvn.IconChar = FontAwesome.Sharp.IconChar.FileUpload;
            this.syncWithSvn.IconColor = System.Drawing.Color.Gainsboro;
            this.syncWithSvn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.syncWithSvn.IconSize = 32;
            this.syncWithSvn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncWithSvn.Location = new System.Drawing.Point(76, 129);
            this.syncWithSvn.Name = "syncWithSvn";
            this.syncWithSvn.Size = new System.Drawing.Size(131, 41);
            this.syncWithSvn.TabIndex = 26;
            this.syncWithSvn.Text = "Sync SVN";
            this.syncWithSvn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.syncWithSvn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.syncWithSvn.UseVisualStyleBackColor = true;
            this.syncWithSvn.Click += new System.EventHandler(this.PushToSvn_Click);
            // 
            // buttonSelectedFilesOk
            // 
            this.buttonSelectedFilesOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectedFilesOk.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectedFilesOk.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSelectedFilesOk.Location = new System.Drawing.Point(487, 208);
            this.buttonSelectedFilesOk.Name = "buttonSelectedFilesOk";
            this.buttonSelectedFilesOk.Size = new System.Drawing.Size(142, 48);
            this.buttonSelectedFilesOk.TabIndex = 27;
            this.buttonSelectedFilesOk.Text = "OK";
            this.buttonSelectedFilesOk.UseVisualStyleBackColor = true;
            this.buttonSelectedFilesOk.Click += new System.EventHandler(this.buttonSelectedFilesOk_Click);
            // 
            // SyncWithSvnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(693, 268);
            this.Controls.Add(this.buttonSelectedFilesOk);
            this.Controls.Add(this.syncWithSvn);
            this.Controls.Add(this.buttonFrom);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDestSVN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserNameTextBox2);
            this.Controls.Add(this.PasswordTestBox2);
            this.Controls.Add(this.label2);
            this.Name = "SyncWithSvnForm";
            this.Text = "PullAndPush";
            this.Load += new System.EventHandler(this.PullAndPushForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDestSVN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserNameTextBox2;
        private System.Windows.Forms.TextBox PasswordTestBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrom;
        private FontAwesome.Sharp.IconButton buttonFrom;
        private FontAwesome.Sharp.IconButton syncWithSvn;
        private System.Windows.Forms.Button buttonSelectedFilesOk;
    }
}