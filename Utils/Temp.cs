using MULTISYSDbContext.Models;
using PullAndClassification.Forms;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Utils
{
    public class Temp
    {
        public string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
        public static void CloneDirectory(string root, string dest)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                }
                CloneDirectory(directory, Path.Combine(dest, dirName));
            }

            foreach (var file in Directory.GetFiles(root))
            {
                try
                {
                    File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
                }
                catch { }
            }
        }
        public static void CopyAndClassify(
            bool checkBoxClassification,
            SelectFileForm selectedFilesForm,
            string destination,
            bool fromSvn,
            string UserName,
            string Password,
            string sourceSVN,
            string sourceLocalFile
            )
        {
            List<DataGridViewRow> selectedFiles = new List<DataGridViewRow>();

            if (checkBoxClassification)
            {
                if (fromSvn)
                {
                    SvnClient client = new SvnClient();
                    client.Authentication.DefaultCredentials = new NetworkCredential(UserName, Password);
                    var classification = Classification.Service.Classification.GetInstance();
                    selectedFiles.AddRange(selectedFilesForm.GetSelectedFiles(selectedFilesForm.FilesDataGridView));
                    selectedFilesForm.ClassificationProgressBar.Visible = true;
                    selectedFilesForm.ClassificationProgressBar.Minimum = 1;
                    selectedFilesForm.ClassificationProgressBar.Maximum = 100;
                    selectedFilesForm.ClassificationProgressBar.Step = 100 / selectedFiles.Count;

                    selectedFiles.ForEach(row =>
                    {
                        classification.CopyAndClassification(client, row.Cells["_fullPath"].Value.ToString(), row.Cells["ClassificationPath"].Value.ToString(), destination, fromSvn);
                        selectedFilesForm.ClassificationProgressBar.PerformStep();
                    }
                    );
                }
                else
                {
                    var classification = Classification.Service.Classification.GetInstance();
                    selectedFiles.AddRange(selectedFilesForm.GetSelectedFiles(selectedFilesForm.FilesDataGridView));
                    selectedFilesForm.ClassificationProgressBar.Visible = true;
                    selectedFilesForm.ClassificationProgressBar.Minimum = 1;
                    selectedFilesForm.ClassificationProgressBar.Maximum = 100;
                    selectedFilesForm.ClassificationProgressBar.Step = 100 / selectedFiles.Count;
                    try
                    {
                        selectedFiles.ForEach(row =>
                        {
                            classification.CopyAndClassification(null, row.Cells["_fullPath"].Value.ToString(), row.Cells["ClassificationPath"].Value.ToString(), destination, false);
                            selectedFilesForm.ClassificationProgressBar.PerformStep();
                        }
                        );

                    }
                    catch (Exception)
                    {
                    }
                }

            }
        }
        public class FileStructure
        {
            public FileStructure(
                string projectName,
                string lot,
                DateTime date,
                int index
                )
            {
                ProjectName = projectName;
                Lot = lot;
                Date = date;
                Index = index;
            }

            public FileStructure()
            {
            }

            private string separator;

            public string Separator { get => separator; set => separator = value; }
            public string ProjectName { get => projectName; set => projectName = value; }
            public string Lot { get => lot; set => lot = value; }
            public DateTime Date { get => date; set => date = value; }
            public int Index { get => index; set => index = value; }

            private string projectName;
            private string lot;
            private DateTime date;
            private int index;

            //public FileStructure GetFileStructure(string fullPath = "", string separator = "")
            //{
            //    return new FileStructure(
            //        RandomString(10),
            //        RandomString(3),
            //        RandomDay(),
            //        random.Next(0, 10)
            //        );
            //}
            //private static Random random = new Random();
            //public static string RandomString(int length)
            //{
            //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //    return new string(Enumerable.Repeat(chars, length)
            //      .Select(s => s[random.Next(s.Length)]).ToArray());
            //}
            //DateTime RandomDay()
            //{
            //    DateTime start = new DateTime(2019, 1, 1);
            //    int range = (DateTime.Today - start).Days;
            //    return start.AddDays(random.Next(range));
            //}
        }

        public class FileInfo
        {
            private string path;
            private string name;
            private long size;
            private bool selected = true;
            private bool validFileStrusture;
            private string pathToClassify;

            public string Path { get => path; set => path = value; }
            public string Name { get => name; set => name = value; }
            public long Size { get => size; set => size = value; }
            public bool Selected { get => selected; set => selected = value; }
            public bool ValidFileStrusture { get => validFileStrusture; set => validFileStrusture = value; }
            public string PathToClassify { get => pathToClassify; set => pathToClassify = value; }
        }
        public class PrepareControls
        {
            public List<MetroFramework.Controls.MetroTextBox> GetAdditionalControls(
                List<ProjectFileNameStructure> projectFileNameStructures,
                int beginX,
                int beginY,
                int SepDest,
                Form form)
            {
                int i = 0;
                MetroFramework.Controls.MetroTextBox metroTextBox;
                List<MetroFramework.Controls.MetroTextBox> controls = new List<MetroFramework.Controls.MetroTextBox>();
                projectFileNameStructures.Where(t => t.CreateFolder).ToList().ForEach(t =>
                  {
                      metroTextBox = new MetroFramework.Controls.MetroTextBox
                      {
                          Text = t.Name,
                          Location = new Point(beginX + 50, beginY + (SepDest * ++i)),
                          Theme = MetroFramework.MetroThemeStyle.Dark,
                          Style = MetroFramework.MetroColorStyle.Blue,
                          Height = 20,
                          Width = 250
                      };
                      form.Controls.Add(metroTextBox);
                      controls.Add(metroTextBox);

                      form.Controls.Add(new MetroFramework.Controls.MetroLabel
                      {

                          Text = t.Name,
                          Location = new Point(beginX, beginY + (SepDest * i)),
                          Theme = MetroFramework.MetroThemeStyle.Dark

                      });
                  });
                return controls;
            }

        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
