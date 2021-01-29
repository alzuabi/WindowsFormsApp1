﻿
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Classification = new FontAwesome.Sharp.IconButton();
            this.metroUpdateProjectButton = new MetroFramework.Controls.MetroButton();
            this.filesDataGridView = new MetroFramework.Controls.MetroGrid();
            this.classificationProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabelProjectName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
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
            this.Classification.Location = new System.Drawing.Point(275, 327);
            this.Classification.Name = "Classification";
            this.Classification.Size = new System.Drawing.Size(110, 49);
            this.Classification.TabIndex = 3;
            this.Classification.Text = "Classification";
            this.Classification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Classification.UseVisualStyleBackColor = false;
            this.Classification.Click += new System.EventHandler(this.Classification_Click);
            // 
            // metroUpdateProjectButton
            // 
            this.metroUpdateProjectButton.Location = new System.Drawing.Point(1109, 327);
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
            this.filesDataGridView.AllowUserToResizeRows = false;
            this.filesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.filesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.filesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.filesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.filesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.filesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.filesDataGridView.EnableHeadersVisualStyles = false;
            this.filesDataGridView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.filesDataGridView.Location = new System.Drawing.Point(46, 67);
            this.filesDataGridView.Name = "filesDataGridView";
            this.filesDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.filesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.filesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filesDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.filesDataGridView.Size = new System.Drawing.Size(635, 224);
            this.filesDataGridView.Style = MetroFramework.MetroColorStyle.Blue;
            this.filesDataGridView.TabIndex = 19;
            this.filesDataGridView.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.filesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesDataGridView_ModifyCellClick);
            this.filesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FilesDataGridView_CellFormatting);
            // 
            // classificationProgressBar
            // 
            this.classificationProgressBar.Location = new System.Drawing.Point(46, 306);
            this.classificationProgressBar.Name = "classificationProgressBar";
            this.classificationProgressBar.Size = new System.Drawing.Size(635, 5);
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
            // SelectFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 378);
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

        public MetroFramework.Controls.MetroGrid FilesDataGridView { get => filesDataGridView; set => filesDataGridView = value; }
        public MetroFramework.Controls.MetroProgressBar ClassificationProgressBar { get => classificationProgressBar; set => classificationProgressBar = value; }
    }
}