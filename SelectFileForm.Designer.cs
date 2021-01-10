
namespace PullAndClassification.Forms
{
    partial class SelectFileForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.filesDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSelectedFilesOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.filesDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filesDataGridView.Name = "filesDataGridView";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.filesDataGridView.Size = new System.Drawing.Size(679, 417);
            this.filesDataGridView.TabIndex = 0;
            // 
            // buttonSelectedFilesOk
            // 
            this.buttonSelectedFilesOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectedFilesOk.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectedFilesOk.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSelectedFilesOk.Location = new System.Drawing.Point(514, 328);
            this.buttonSelectedFilesOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSelectedFilesOk.Name = "buttonSelectedFilesOk";
            this.buttonSelectedFilesOk.Size = new System.Drawing.Size(134, 63);
            this.buttonSelectedFilesOk.TabIndex = 2;
            this.buttonSelectedFilesOk.Text = "OK";
            this.buttonSelectedFilesOk.UseVisualStyleBackColor = true;
            this.buttonSelectedFilesOk.Click += new System.EventHandler(this.buttonSelectedFilesOk_Click);
            // 
            // SFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(679, 417);
            this.Controls.Add(this.buttonSelectedFilesOk);
            this.Controls.Add(this.filesDataGridView);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SFForm";
            this.Text = "SFForm";
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView filesDataGridView;
        private System.Windows.Forms.Button buttonSelectedFilesOk;
    }
}