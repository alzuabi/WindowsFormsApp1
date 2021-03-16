using MetroFramework.Forms;
using MULTISYSDbContext.Models;
using PullAndClassification.Forms;
using PullAndClassification.Utils;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using static Utils.Temp;

namespace PullAndClassification
{
    public partial class SelectProject : MetroForm
    {
        public SelectProject()
        {
            InitializeComponent();
            MaximizeBox = false;
            ShadowType = MetroFormShadowType.AeroShadow;
            Session.context = new DatabaseContext();
        }

        private void SelectProject_Load(object sender, EventArgs e) =>
            Session.context.Projects.ToList().ForEach(project => metroProjectListComboBox.Items.Add(
                new ComboboxItem() {
                    Text = project.Name,
                    Value = project.Id
                })
            );

        private void MetroSubmitSelectProjectButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Session.CurrentProjectId = ((ComboboxItem)metroProjectListComboBox.SelectedItem).Value;

                CopyAndClassificationForm copyAndClassificationForm = new CopyAndClassificationForm(/*Session.CurrentProjectId*/);
                copyAndClassificationForm.ShowDialog();
            }
           
            }

        private void CompoBoXSelectProject_Validatig(object sender, CancelEventArgs e)
        {
            if (metroProjectListComboBox.SelectedIndex==-1)
            {
                e.Cancel = true;
                metroProjectListComboBox.Focus();
                errorProviderSelectProject.SetError(metroProjectListComboBox, "You Should Select Project First");
            }
        }
    }
    
}
