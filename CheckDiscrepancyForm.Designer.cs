
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
            this.dataGridViewFilesDifferances = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new System.Windows.Forms.ComboBox();
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewFilesDifferances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFilesDifferances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFilesDifferances.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFilesDifferances.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewFilesDifferances.Location = new System.Drawing.Point(27, 81);
            this.dataGridViewFilesDifferances.Name = "dataGridViewFilesDifferances";
            this.dataGridViewFilesDifferances.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFilesDifferances.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewFilesDifferances.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFilesDifferances.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewFilesDifferances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilesDifferances.Size = new System.Drawing.Size(623, 304);
            this.dataGridViewFilesDifferances.TabIndex = 0;
            this.dataGridViewFilesDifferances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFilesDifferances_ModifyCellClick);
            this.dataGridViewFilesDifferances.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewFilesDifferances_CellFormatting);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(603, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.TabIndex = 24;
            this.metroLabel1.Text = "Current Project";
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.Location = new System.Drawing.Point(459, 9);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(81, 19);
            this.metroLabelProjectName.TabIndex = 23;
            this.metroLabelProjectName.Text = "metroLabel1";
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 13;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(707, 9);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(155, 21);
            this.metroProjectListComboBox.TabIndex = 37;
            this.metroProjectListComboBox.SelectedIndexChanged += new System.EventHandler(this.MetroProjectListComboBox_SelectedIndexChanged);
            this.metroProjectListComboBox.Click += new System.EventHandler(this.MetroProjectListComboBox_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(355, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(98, 19);
            this.metroLabel2.TabIndex = 36;
            this.metroLabel2.Text = "Current Project";
            // 
            // metroUpdateProjectButton
            // 
            this.metroUpdateProjectButton.Location = new System.Drawing.Point(913, 9);
            this.metroUpdateProjectButton.Name = "metroUpdateProjectButton";
            this.metroUpdateProjectButton.Size = new System.Drawing.Size(81, 24);
            this.metroUpdateProjectButton.TabIndex = 38;
            this.metroUpdateProjectButton.Text = "Refresh";
            this.metroUpdateProjectButton.UseSelectable = true;
            this.metroUpdateProjectButton.Click += new System.EventHandler(this.MetroUpdateProjectButton_Click);
            // 
            // metroButtonFinish
            // 
            this.metroButtonFinish.Location = new System.Drawing.Point(1177, 414);
            this.metroButtonFinish.Name = "metroButtonFinish";
            this.metroButtonFinish.Size = new System.Drawing.Size(69, 26);
            this.metroButtonFinish.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonFinish.TabIndex = 39;
            this.metroButtonFinish.Text = "Close";
            this.metroButtonFinish.UseSelectable = true;
            this.metroButtonFinish.Click += new System.EventHandler(this.MetroButtonFinish_Click);
            // 
            // ClassificationButton
            // 
            this.ClassificationButton.BackColor = System.Drawing.Color.Transparent;
            this.ClassificationButton.FlatAppearance.BorderSize = 0;
            this.ClassificationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.ClassificationButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassificationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClassificationButton.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.ClassificationButton.IconColor = System.Drawing.Color.Black;
            this.ClassificationButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ClassificationButton.IconSize = 30;
            this.ClassificationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClassificationButton.Location = new System.Drawing.Point(1151, 50);
            this.ClassificationButton.Name = "ClassificationButton";
            this.ClassificationButton.Size = new System.Drawing.Size(104, 39);
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
            this.RemoveFromDB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveFromDB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RemoveFromDB.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.RemoveFromDB.IconColor = System.Drawing.Color.Black;
            this.RemoveFromDB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RemoveFromDB.IconSize = 30;
            this.RemoveFromDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveFromDB.Location = new System.Drawing.Point(1151, 110);
            this.RemoveFromDB.Name = "RemoveFromDB";
            this.RemoveFromDB.Size = new System.Drawing.Size(104, 35);
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
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1299, 462);
            this.Controls.Add(this.RemoveFromDB);
            this.Controls.Add(this.ClassificationButton);
            this.Controls.Add(this.metroButtonFinish);
            this.Controls.Add(this.metroUpdateProjectButton);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.dataGridViewFilesDifferances);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CheckDiscrepancyForm";
            this.Padding = new System.Windows.Forms.Padding(18, 78, 18, 19);
            this.Resizable = false;
            this.Text = "Check Discrepancy Form";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.CheckDiscrepancyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilesDifferances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFilesDifferances;
        private MetroFramework.Controls.MetroButton metroUpdateProjectButton;
        private MetroFramework.Controls.MetroButton metroButtonFinish;
        private FontAwesome.Sharp.IconButton ClassificationButton;
        private FontAwesome.Sharp.IconButton RemoveFromDB;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ComboBox metroProjectListComboBox;
    }
}