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
using WindowsFormsApp1.Service;

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
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.ShowDialog();
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
            string s = source.Text;
            string d = destination.Text;
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(s);
                string dir = Path.Combine(fileName.Split('-'));
                string dest = Path.Combine(d, dir);
                Directory.CreateDirectory(dest);
                dest = Path.Combine(dest, Path.GetFileName(s));

                if (File.Exists(dest))
                {
                    File.Delete(s);
                }
                else
                {
                    File.Move(s, dest);
                    using (var db = new TestContext())
                    {
                        var ev = new Event()
                        {
                            eventName = "test",
                            eventnDesc = Path.GetFileName(s),
                            eventDate = DateTime.Now
                        };
                        db.Events.Add(ev);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //WriteToFile(ex.Message);
            }
        }
    }
}
