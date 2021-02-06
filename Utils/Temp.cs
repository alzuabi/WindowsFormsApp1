using MULTISYSDbContext.Models;
using MULTISYSUtilities;
using PullAndClassification.Forms;
using PullAndClassification.Utils;
using SharpSvn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.ComponentModel;
using Classification.Utils;

namespace Utils
{
    public class Temp
    {
        public  BackgroundWorker bgw = new BackgroundWorker();
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
        public static List<string> CopyAndClassify(
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
            var log = Log.GetInstance();

            //log.LogToFile("IN CopyAndClassify");
            List<string> summary = new List<string>();
            List<DataGridViewRow> selectedFiles = new List<DataGridViewRow>();
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
                    if (string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                        summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + destination);
                    else
                        summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + row.Cells["ClassificationPath"].Value.ToString());
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
                        if (string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                            summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + destination);
                        else
                            summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + row.Cells["ClassificationPath"].Value.ToString());
                    }
                    );

                }
                catch (Exception)
                {
                    return null;
                }
            }
            return summary;
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

            public List<LinkedControls> GetAdditionalControls(
                List<ProjectFileNameStructure> projectFileNameStructures,
                int beginX,
                int beginY,
                int SepDest,
                Form form)
            {
                int i = 0;
                List<LinkedControls> controls = new List<LinkedControls>();
                projectFileNameStructures.Where(t => t.CreateFolder).OrderBy(t => t.FolderOrder).ToList().ForEach(t =>
                    {
                        if (t.NameType.Equals(FNSTypes.fns_date.Id))
                        {

                            DateTimePicker dateTimePicker = new MetroDateTime
                            {
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250
                            };
                            form.Controls.Add(dateTimePicker);
                            controls.Add(new LinkedControls(t.Id, dateTimePicker));
                        }
                        else if (t.NameType.Equals(FNSTypes.fns_lot.Id))
                        {
                            MetroComboBox metroComboBox = new MetroComboBox
                            {
                                Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250
                            };
                            Session.context = new DatabaseContext();
                            Session.context.LOTs.Where(lot => lot.ProjectId == Session.CurrentProjectId).ToList().ForEach(lot => metroComboBox.Items.Add(new ComboboxItem()
                            {
                                Text = lot.Name,
                                Value = lot.Id
                            })
                            );
                            form.Controls.Add(metroComboBox);
                            controls.Add(new LinkedControls(t.Id,metroComboBox));
                        }
                        else if (t.NameType.Equals(FNSTypes.fns_date_index.Id))
                        {
                            LinkedControls linkedControls = new LinkedControls();
                            Tuple<int, Control> tuple;
                            DateTimePicker dateTimePicker = new MetroDateTime
                            {
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250
                            };
                            form.Controls.Add(dateTimePicker);
                            tuple = Tuple.Create<int, Control>(t.Id, dateTimePicker);
                            linkedControls.LinkedList.AddFirst(tuple);
                            MetroTextBox metroTextBox = new MetroTextBox
                            {
                                Text = "index",
                                Location = new Point(beginX + 380, beginY + (SepDest * i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 100
                            };
                            form.Controls.Add(metroTextBox);
                            tuple = Tuple.Create<int, Control>(t.Id, metroTextBox);
                            linkedControls.LinkedList.AddLast(tuple);
                            controls.Add(linkedControls);
                        }
                        else
                        {

                            MetroTextBox metroTextBox = new MetroTextBox
                            {
                                Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250
                            };
                            form.Controls.Add(metroTextBox);
                            controls.Add(new LinkedControls(t.Id,metroTextBox));
                        }
                        form.Controls.Add(new MetroLabel
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
        public class LinkedControls
        {
            private LinkedList<Tuple<int, Control>> linkedList = new LinkedList<Tuple<int, Control>>();

            public LinkedList<Tuple<int, Control>> LinkedList { get => linkedList; set => linkedList = value; }

            public LinkedControls(int id, Control control)
            {
                linkedList.AddLast(Tuple.Create(id, control));
            }
            public LinkedControls() { }
        }
    }
}
