using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Context;
using WindowsFormsApp1.Entity;

using Classifacation.Service;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1
{
    public partial class PandCForm : Form
    {
        public PandCForm()
        {
            InitializeComponent();
        }

        private void Select_Source_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = FolderFileSelectDialog.GetFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                source.Text = openFileDialog.FileName;
            }
        }

        private void Select_Destination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = FolderFileSelectDialog.GetFolderDialog();
           
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destination.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Pull_and_Classification_Click(object sender, EventArgs e)
        {

            var classification = Classification.GetInstance();
            string s = source.Text;
            string d = destination.Text;
            try
            {
                classification.pullAndClassification(s, d);
            }
            catch (Exception ex) {

            
            }
        }
    }
}
