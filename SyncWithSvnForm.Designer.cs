
namespace PullAndClassificationForm
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
            this.syncWithSvn = new System.Windows.Forms.Button();
            this.buttonFrom = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "URL";
            // 
            // textBoxDestSVN
            // 
            this.textBoxDestSVN.Location = new System.Drawing.Point(99, 118);
            this.textBoxDestSVN.Name = "textBoxDestSVN";
            this.textBoxDestSVN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDestSVN.Size = new System.Drawing.Size(316, 20);
            this.textBoxDestSVN.TabIndex = 22;
            this.textBoxDestSVN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "User Name";
            // 
            // UserNameTextBox2
            // 
            this.UserNameTextBox2.Location = new System.Drawing.Point(139, 144);
            this.UserNameTextBox2.Name = "UserNameTextBox2";
            this.UserNameTextBox2.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox2.TabIndex = 18;
            // 
            // PasswordTestBox2
            // 
            this.PasswordTestBox2.Location = new System.Drawing.Point(315, 144);
            this.PasswordTestBox2.Name = "PasswordTestBox2";
            this.PasswordTestBox2.Size = new System.Drawing.Size(100, 20);
            this.PasswordTestBox2.TabIndex = 21;
            this.PasswordTestBox2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Password";
            // 
            // syncWithSvn
            // 
            this.syncWithSvn.Location = new System.Drawing.Point(421, 118);
            this.syncWithSvn.Name = "syncWithSvn";
            this.syncWithSvn.Size = new System.Drawing.Size(236, 46);
            this.syncWithSvn.TabIndex = 20;
            this.syncWithSvn.Text = "Sync With SVN";
            this.syncWithSvn.UseVisualStyleBackColor = true;
            this.syncWithSvn.Click += new System.EventHandler(this.PushToSvn_Click);
            // 
            // buttonFrom
            // 
            this.buttonFrom.Location = new System.Drawing.Point(421, 66);
            this.buttonFrom.Name = "buttonFrom";
            this.buttonFrom.Size = new System.Drawing.Size(236, 23);
            this.buttonFrom.TabIndex = 23;
            this.buttonFrom.Text = "From";
            this.buttonFrom.UseVisualStyleBackColor = true;
            this.buttonFrom.Click += new System.EventHandler(this.ButtonFrom_Click);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(101, 66);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(314, 20);
            this.textBoxFrom.TabIndex = 24;
            this.textBoxFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SyncWithSvnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 237);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.buttonFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDestSVN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserNameTextBox2);
            this.Controls.Add(this.PasswordTestBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.syncWithSvn);
            this.Name = "SyncWithSvnForm";
            this.Text = "PullAndPush";
            this.Load += new System.EventHandler(this.PullAndPushForm_Load);
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
        private System.Windows.Forms.Button syncWithSvn;
        private System.Windows.Forms.Button buttonFrom;
        private System.Windows.Forms.TextBox textBoxFrom;
    }
}