
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Classification = new FontAwesome.Sharp.IconButton();
            this.metroUpdateProjectButton = new MetroFramework.Controls.MetroButton();
            this.filesDataGridView = new MetroFramework.Controls.MetroGrid();
            this.classificationProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButtonFinish = new MetroFramework.Controls.MetroButton();
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
            this.Classification.ForeColor = System.Drawing.Color.DimGray;
            this.Classification.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.Classification.IconColor = System.Drawing.Color.Black;
            this.Classification.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Classification.IconSize = 30;
            this.Classification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Classification.Location = new System.Drawing.Point(275, 421);
            this.Classification.Name = "Classification";
            this.Classification.Size = new System.Drawing.Size(120, 33);
            this.Classification.TabIndex = 3;
            this.Classification.Text = "Classification";
            this.Classification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Classification.UseVisualStyleBackColor = false;
            this.Classification.Click += new System.EventHandler(this.Classification_Click);
            // 
            // metroUpdateProjectButton
            // 
            this.metroUpdateProjectButton.Location = new System.Drawing.Point(867, 28);
            this.metroUpdateProjectButton.Name = "metroUpdateProjectButton";
            this.metroUpdateProjectButton.Size = new System.Drawing.Size(75, 23);
            this.metroUpdateProjectButton.TabIndex = 18;
            this.metroUpdateProjectButton.Text = "Update";
            this.metroUpdateProjectButton.UseSelectable = true;
            this.metroUpdateProjectButton.Click += new System.EventHandler(this.MetroUpdateProjectButton_Click);
            // 
            // filesDataGridView
            // 
            this.filesDataGridView.AllowUserToAddRows = false;
            this.filesDataGridView.AllowUserToDeleteRows = false;
            this.filesDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            this.filesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.filesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.filesDataGridView.EnableHeadersVisualStyles = false;
            this.filesDataGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.filesDataGridView.Location = new System.Drawing.Point(46, 67);
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.filesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filesDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.filesDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesDataGridView.Size = new System.Drawing.Size(515, 292);
            this.filesDataGridView.Style = MetroFramework.MetroColorStyle.Blue;
            this.filesDataGridView.TabIndex = 19;
            this.filesDataGridView.UseStyleColors = true;
            this.filesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesDataGridView_ModifyCellClick);
            this.filesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FilesDataGridView_CellFormatting);
            // 
            // classificationProgressBar
            // 
            this.classificationProgressBar.Location = new System.Drawing.Point(46, 378);
            this.classificationProgressBar.Name = "classificationProgressBar";
            this.classificationProgressBar.Size = new System.Drawing.Size(519, 5);
            this.classificationProgressBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.classificationProgressBar.TabIndex = 20;
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
            // 
            // metroButtonFinish
            // 
            this.metroButtonFinish.Location = new System.Drawing.Point(990, 421);
            this.metroButtonFinish.Name = "metroButtonFinish";
            this.metroButtonFinish.Size = new System.Drawing.Size(75, 23);
            this.metroButtonFinish.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonFinish.TabIndex = 24;
            this.metroButtonFinish.Text = "Close";
            this.metroButtonFinish.UseSelectable = true;
            this.metroButtonFinish.Click += new System.EventHandler(this.MetroButtonFinish_Click);
            // 
            // SelectFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 472);
            this.Controls.Add(this.metroButtonFinish);
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
            this.Theme = MetroFramework.MetroThemeStyle.Default;
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
        private MetroFramework.Controls.MetroButton metroButtonFinish;

        public MetroFramework.Controls.MetroGrid FilesDataGridView { get => filesDataGridView; set => filesDataGridView = value; }
        public MetroFramework.Controls.MetroProgressBar ClassificationProgressBar { get => classificationProgressBar; set => classificationProgressBar = value; }
    }
}