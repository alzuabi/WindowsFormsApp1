
namespace PullAndClassification
{
    partial class CheckDiscrepancyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFilesDifferances = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilesDifferances)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFilesDifferances
            // 
            this.dataGridViewFilesDifferances.AllowUserToAddRows = false;
            this.dataGridViewFilesDifferances.AllowUserToDeleteRows = false;
            this.dataGridViewFilesDifferances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFilesDifferances.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilesDifferances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFilesDifferances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFilesDifferances.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFilesDifferances.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridViewFilesDifferances.Location = new System.Drawing.Point(58, 135);
            this.dataGridViewFilesDifferances.Name = "dataGridViewFilesDifferances";
            this.dataGridViewFilesDifferances.ReadOnly = true;
            this.dataGridViewFilesDifferances.Size = new System.Drawing.Size(662, 234);
            this.dataGridViewFilesDifferances.TabIndex = 0;
            this.dataGridViewFilesDifferances.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewFilesDifferances_CellFormatting);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(525, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Current Project";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelProjectName.Location = new System.Drawing.Point(629, 94);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(94, 19);
            this.metroLabelProjectName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelProjectName.TabIndex = 23;
            this.metroLabelProjectName.Text = "metroLabel1";
            this.metroLabelProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 23;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(420, 26);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.PromptText = "Select Project";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(189, 29);
            this.metroProjectListComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProjectListComboBox.TabIndex = 37;
            this.metroProjectListComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProjectListComboBox.UseSelectable = true;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(316, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(98, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 36;
            this.metroLabel2.Text = "Current Project";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // CheckDiscrepancyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 499);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.dataGridViewFilesDifferances);
            this.Name = "CheckDiscrepancyForm";
            this.Text = "Check Discrepancy Form";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.CheckDiscrepancyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilesDifferances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFilesDifferances;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private MetroFramework.Controls.MetroComboBox metroProjectListComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}