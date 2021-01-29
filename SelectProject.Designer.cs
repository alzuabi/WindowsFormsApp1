
namespace PullAndClassification
{
    partial class SelectProject
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectProject));
            this.metroLogoPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroProjectListComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroSubmitSelectProjectButton = new MetroFramework.Controls.MetroButton();
            this.errorProviderSelectProject = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSelectProject)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLogoPanel
            // 
            this.metroLogoPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroLogoPanel.BackgroundImage")));
            this.metroLogoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.metroLogoPanel.HorizontalScrollbarBarColor = true;
            this.metroLogoPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.metroLogoPanel.HorizontalScrollbarSize = 10;
            this.metroLogoPanel.Location = new System.Drawing.Point(219, 63);
            this.metroLogoPanel.Name = "metroLogoPanel";
            this.metroLogoPanel.Size = new System.Drawing.Size(273, 248);
            this.metroLogoPanel.TabIndex = 0;
            this.metroLogoPanel.VerticalScrollbarBarColor = true;
            this.metroLogoPanel.VerticalScrollbarHighlightOnWheel = false;
            this.metroLogoPanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(110, 370);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(136, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Please Select Project: ";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroProjectListComboBox
            // 
            this.metroProjectListComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroProjectListComboBox.FormattingEnabled = true;
            this.metroProjectListComboBox.ItemHeight = 23;
            this.metroProjectListComboBox.Location = new System.Drawing.Point(251, 367);
            this.metroProjectListComboBox.Name = "metroProjectListComboBox";
            this.metroProjectListComboBox.Size = new System.Drawing.Size(213, 29);
            this.metroProjectListComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProjectListComboBox.TabIndex = 3;
            this.metroProjectListComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProjectListComboBox.UseSelectable = true;
            this.metroProjectListComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.CompoBoXSelectProject_Validatig);
            // 
            // metroSubmitSelectProjectButton
            // 
            this.metroSubmitSelectProjectButton.Location = new System.Drawing.Point(538, 413);
            this.metroSubmitSelectProjectButton.Name = "metroSubmitSelectProjectButton";
            this.metroSubmitSelectProjectButton.Size = new System.Drawing.Size(112, 37);
            this.metroSubmitSelectProjectButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroSubmitSelectProjectButton.TabIndex = 4;
            this.metroSubmitSelectProjectButton.Text = "Submit";
            this.metroSubmitSelectProjectButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroSubmitSelectProjectButton.UseSelectable = true;
            this.metroSubmitSelectProjectButton.Click += new System.EventHandler(this.MetroSubmitSelectProjectButton_Click);
            // 
            // errorProviderSelectProject
            // 
            this.errorProviderSelectProject.ContainerControl = this;
            // 
            // SelectProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(709, 473);
            this.Controls.Add(this.metroSubmitSelectProjectButton);
            this.Controls.Add(this.metroProjectListComboBox);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLogoPanel);
            this.Name = "SelectProject";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.Text = "Select Project";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SelectProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderSelectProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroLogoPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroProjectListComboBox;
        private MetroFramework.Controls.MetroButton metroSubmitSelectProjectButton;
        private System.Windows.Forms.ErrorProvider errorProviderSelectProject;
    }
}