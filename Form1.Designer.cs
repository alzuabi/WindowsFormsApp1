
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
            this.selectSource = new System.Windows.Forms.Button();
            this.source = new System.Windows.Forms.TextBox();
            this.selectDestination = new System.Windows.Forms.Button();
            this.destination = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectSource
            // 
            this.selectSource.Location = new System.Drawing.Point(542, 141);
            this.selectSource.Name = "selectSource";
            this.selectSource.Size = new System.Drawing.Size(202, 20);
            this.selectSource.TabIndex = 0;
            this.selectSource.Text = "Select Source";
            this.selectSource.UseVisualStyleBackColor = true;
            this.selectSource.Click += new System.EventHandler(this.Select_Source_Click);
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(137, 141);
            this.source.Name = "source";
            this.source.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.source.Size = new System.Drawing.Size(359, 20);
            this.source.TabIndex = 1;
            this.source.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // selectDestination
            // 
            this.selectDestination.Location = new System.Drawing.Point(542, 205);
            this.selectDestination.Name = "selectDestination";
            this.selectDestination.Size = new System.Drawing.Size(202, 20);
            this.selectDestination.TabIndex = 2;
            this.selectDestination.Text = "Select Destination";
            this.selectDestination.UseVisualStyleBackColor = true;
            this.selectDestination.Click += new System.EventHandler(this.Select_Destination_Click);
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(137, 205);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(359, 20);
            this.destination.TabIndex = 3;
            this.destination.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(335, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pull and Classification";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Pull_and_Classification_Click);
            // 
            // PandCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.selectDestination);
            this.Controls.Add(this.source);
            this.Controls.Add(this.selectSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PandCForm";
            this.Text = "Pull And Classification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectSource;
        private System.Windows.Forms.TextBox source;
        private System.Windows.Forms.Button selectDestination;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button button1;
    }
}

