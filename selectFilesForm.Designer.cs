
namespace PullAndClassificationForm
{
    partial class SelectFilesForm
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
            this.filesDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSelectedFilesOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowDrop = true;
            this.filesDataGridView.AllowUserToOrderColumns = true;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.Size = new System.Drawing.Size(800, 363);
            this.filesDataGridView.TabIndex = 0;
            // 
            // buttonSelectedFilesOk
            // 
            this.buttonSelectedFilesOk.Location = new System.Drawing.Point(435, 390);
            this.buttonSelectedFilesOk.Name = "buttonSelectedFilesOk";
            this.buttonSelectedFilesOk.Size = new System.Drawing.Size(142, 48);
            this.buttonSelectedFilesOk.TabIndex = 1;
            this.buttonSelectedFilesOk.Text = "OK";
            this.buttonSelectedFilesOk.UseVisualStyleBackColor = true;
            this.buttonSelectedFilesOk.Click += new System.EventHandler(this.buttonSelectedFilesOk_Click);
            // 
            // SelectFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.buttonSelectedFilesOk);
            this.Controls.Add(this.filesDataGridView);
            this.Name = "SelectFilesForm";
            this.Text = "Select Files";
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView filesDataGridView;
        private System.Windows.Forms.Button buttonSelectedFilesOk;
    }
    
}