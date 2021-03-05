
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFilesDifferances = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroUpdateProjectButton = new MetroFramework.Controls.MetroButton();
            this.metroButtonFinish = new MetroFramework.Controls.MetroButton();
            this.ClassificationButton = new FontAwesome.Sharp.IconButton();
            this.RemoveFromDB = new FontAwesome.Sharp.IconButton();
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
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
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
            this.dataGridViewFilesDifferances.Location = new System.Drawing.Point(58, 86);
            this.dataGridViewFilesDifferances.Name = "dataGridViewFilesDifferances";
            this.dataGridViewFilesDifferances.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilesDifferances.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridViewFilesDifferances.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFilesDifferances.Size = new System.Drawing.Size(662, 283);
            this.dataGridViewFilesDifferances.TabIndex = 0;
            this.dataGridViewFilesDifferances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFilesDifferances_ModifyCellClick);
            this.dataGridViewFilesDifferances.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewFilesDifferances_CellFormatting);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(713, 29);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Current Project";
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelProjectName.Location = new System.Drawing.Point(817, 29);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(94, 19);
            this.metroLabelProjectName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelProjectName.TabIndex = 23;
            this.metroLabelProjectName.Text = "metroLabel1";
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
            this.metroProjectListComboBox.UseSelectable = true;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            this.metroProjectListComboBox.Click += new System.EventHandler(this.metroProjectListComboBox_Click);
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
            // 
            // metroUpdateProjectButton
            // 
            this.metroUpdateProjectButton.Location = new System.Drawing.Point(1010, 26);
            this.metroUpdateProjectButton.Name = "metroUpdateProjectButton";
            this.metroUpdateProjectButton.Size = new System.Drawing.Size(75, 23);
            this.metroUpdateProjectButton.TabIndex = 38;
            this.metroUpdateProjectButton.Text = "Update";
            this.metroUpdateProjectButton.UseSelectable = true;
            this.metroUpdateProjectButton.Click += new System.EventHandler(this.MetroUpdateProjectButton_Click);
            // 
            // metroButtonFinish
            // 
            this.metroButtonFinish.Location = new System.Drawing.Point(1299, 453);
            this.metroButtonFinish.Name = "metroButtonFinish";
            this.metroButtonFinish.Size = new System.Drawing.Size(75, 23);
            this.metroButtonFinish.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonFinish.TabIndex = 39;
            this.metroButtonFinish.Text = "Close";
            this.metroButtonFinish.UseSelectable = true;
            this.metroButtonFinish.Click += new System.EventHandler(this.metroButtonFinish_Click);
            // 
            // ClassificationButton
            // 
            this.ClassificationButton.BackColor = System.Drawing.Color.Transparent;
            this.ClassificationButton.FlatAppearance.BorderSize = 0;
            this.ClassificationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClassificationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClassificationButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassificationButton.ForeColor = System.Drawing.Color.DimGray;
            this.ClassificationButton.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.ClassificationButton.IconColor = System.Drawing.Color.Black;
            this.ClassificationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ClassificationButton.IconSize = 30;
            this.ClassificationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClassificationButton.Location = new System.Drawing.Point(1254, 86);
            this.ClassificationButton.Name = "ClassificationButton";
            this.ClassificationButton.Size = new System.Drawing.Size(120, 33);
            this.ClassificationButton.TabIndex = 40;
            this.ClassificationButton.Text = "Classification";
            this.ClassificationButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClassificationButton.UseVisualStyleBackColor = false;
            this.ClassificationButton.Visible = false;
            this.ClassificationButton.Click += new System.EventHandler(this.Classification_Click);
            // 
            // RemoveFromDB
            // 
            this.RemoveFromDB.BackColor = System.Drawing.Color.Transparent;
            this.RemoveFromDB.FlatAppearance.BorderSize = 0;
            this.RemoveFromDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.RemoveFromDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveFromDB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveFromDB.ForeColor = System.Drawing.Color.DimGray;
            this.RemoveFromDB.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.RemoveFromDB.IconColor = System.Drawing.Color.Black;
            this.RemoveFromDB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RemoveFromDB.IconSize = 30;
            this.RemoveFromDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveFromDB.Location = new System.Drawing.Point(1254, 134);
            this.RemoveFromDB.Name = "RemoveFromDB";
            this.RemoveFromDB.Size = new System.Drawing.Size(89, 33);
            this.RemoveFromDB.TabIndex = 41;
            this.RemoveFromDB.Text = "Delete";
            this.RemoveFromDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RemoveFromDB.UseVisualStyleBackColor = false;
            this.RemoveFromDB.Visible = false;
            this.RemoveFromDB.Click += new System.EventHandler(this.RemoveFromDB_Click);
            // 
            // CheckDiscrepancyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 499);
            this.Controls.Add(this.RemoveFromDB);
            this.Controls.Add(this.ClassificationButton);
            this.Controls.Add(this.metroButtonFinish);
            this.Controls.Add(this.metroUpdateProjectButton);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.dataGridViewFilesDifferances);
            this.Name = "CheckDiscrepancyForm";
            this.Text = "Check Discrepancy Form";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
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
        private MetroFramework.Controls.MetroButton metroUpdateProjectButton;
        private MetroFramework.Controls.MetroButton metroButtonFinish;
        private FontAwesome.Sharp.IconButton ClassificationButton;
        private FontAwesome.Sharp.IconButton RemoveFromDB;
    }
}