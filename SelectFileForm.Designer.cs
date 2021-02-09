
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Classification = new FontAwesome.Sharp.IconButton();
            this.metroUpdateProjectButton = new MetroFramework.Controls.MetroButton();
            this.filesDataGridView = new MetroFramework.Controls.MetroGrid();
            this.classificationProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonCheck = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Classification
            // 
            this.Classification.BackColor = System.Drawing.Color.Transparent;
            this.Classification.FlatAppearance.BorderSize = 0;
            this.Classification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.Classification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Classification.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Classification.ForeColor = System.Drawing.Color.Gainsboro;
            this.Classification.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.Classification.IconColor = System.Drawing.Color.Gainsboro;
            this.Classification.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Classification.IconSize = 30;
            this.Classification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Classification.Location = new System.Drawing.Point(275, 404);
            this.Classification.Name = "Classification";
            this.Classification.Size = new System.Drawing.Size(120, 53);
            this.Classification.TabIndex = 3;
            this.Classification.Text = "Classification";
            this.Classification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Classification.UseVisualStyleBackColor = false;
            this.Classification.Click += new System.EventHandler(this.Classification_Click);
            // 
            // metroUpdateProjectButton
            // 
            this.metroUpdateProjectButton.Location = new System.Drawing.Point(959, 16);
            this.metroUpdateProjectButton.Name = "metroUpdateProjectButton";
            this.metroUpdateProjectButton.Size = new System.Drawing.Size(105, 35);
            this.metroUpdateProjectButton.TabIndex = 18;
            this.metroUpdateProjectButton.Text = "Update";
            this.metroUpdateProjectButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroUpdateProjectButton.UseSelectable = true;
            this.metroUpdateProjectButton.Click += new System.EventHandler(this.MetroUpdateProjectButton_Click);
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowUserToAddRows = false;
            this.filesDataGridView.AllowUserToDeleteRows = false;
            this.filesDataGridView.AllowUserToResizeRows = false;
            this.filesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.filesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.filesDataGridView.EnableHeadersVisualStyles = false;
            this.filesDataGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.filesDataGridView.Location = new System.Drawing.Point(46, 67);
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.ReadOnly = true;
            this.filesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.filesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filesDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.filesDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesDataGridView.Size = new System.Drawing.Size(662, 292);
            this.filesDataGridView.Style = MetroFramework.MetroColorStyle.Blue;
            this.filesDataGridView.TabIndex = 19;
            this.filesDataGridView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.filesDataGridView.UseStyleColors = true;
            this.filesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesDataGridView_ModifyCellClick);
            this.filesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FilesDataGridView_CellFormatting);
            // 
            // classificationProgressBar
            // 
            this.classificationProgressBar.Location = new System.Drawing.Point(46, 378);
            this.classificationProgressBar.Name = "classificationProgressBar";
            this.classificationProgressBar.Size = new System.Drawing.Size(662, 10);
            this.classificationProgressBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.classificationProgressBar.TabIndex = 20;
            this.classificationProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.classificationProgressBar.Visible = false;
            // 
            // metroLabelProjectName
            // 
            this.metroLabelProjectName.AutoSize = true;
            this.metroLabelProjectName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelProjectName.Location = new System.Drawing.Point(600, 32);
            this.metroLabelProjectName.Name = "metroLabelProjectName";
            this.metroLabelProjectName.Size = new System.Drawing.Size(94, 19);
            this.metroLabelProjectName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabelProjectName.TabIndex = 21;
            this.metroLabelProjectName.Text = "metroLabel1";
            this.metroLabelProjectName.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(496, 32);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(98, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Current Project";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButtonCheck
            // 
            this.metroButtonCheck.Location = new System.Drawing.Point(322, 476);
            this.metroButtonCheck.Name = "metroButtonCheck";
            this.metroButtonCheck.Size = new System.Drawing.Size(75, 23);
            this.metroButtonCheck.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonCheck.TabIndex = 23;
            this.metroButtonCheck.Text = "Check";
            this.metroButtonCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButtonCheck.UseSelectable = true;
            this.metroButtonCheck.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // SelectFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 532);
            this.Controls.Add(this.metroButtonCheck);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabelProjectName);
            this.Controls.Add(this.classificationProgressBar);
            this.Controls.Add(this.filesDataGridView);
            this.Controls.Add(this.metroUpdateProjectButton);
            this.Controls.Add(this.Classification);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectFileForm";
            this.Opacity = 0.95D;
            this.Text = "Select And Update Form";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SelectFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton Classification;
        private MetroFramework.Controls.MetroButton metroUpdateProjectButton;
        private MetroFramework.Controls.MetroGrid filesDataGridView;
        private MetroFramework.Controls.MetroProgressBar classificationProgressBar;
        private MetroFramework.Controls.MetroLabel metroLabelProjectName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButtonCheck;

        public MetroFramework.Controls.MetroGrid FilesDataGridView { get => filesDataGridView; set => filesDataGridView = value; }
        public MetroFramework.Controls.MetroProgressBar ClassificationProgressBar { get => classificationProgressBar; set => classificationProgressBar = value; }
    }
}