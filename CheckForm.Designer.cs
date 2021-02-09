
namespace PullAndClassification
{
    partial class CheckForm
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
            this.dataGridViewFilesDifferances = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilesDifferances)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFilesDifferances
            // 
            this.dataGridViewFilesDifferances.AllowUserToAddRows = false;
            this.dataGridViewFilesDifferances.AllowUserToDeleteRows = false;
            this.dataGridViewFilesDifferances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilesDifferances.Location = new System.Drawing.Point(48, 73);
            this.dataGridViewFilesDifferances.Name = "dataGridViewFilesDifferances";
            this.dataGridViewFilesDifferances.ReadOnly = true;
            this.dataGridViewFilesDifferances.Size = new System.Drawing.Size(689, 150);
            this.dataGridViewFilesDifferances.TabIndex = 0;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewFilesDifferances);
            this.Name = "CheckForm";
            this.Text = "CheckForm";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilesDifferances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFilesDifferances;
    }
}