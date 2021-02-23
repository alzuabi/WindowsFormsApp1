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
using Newtonsoft.Json;
using PullAndClassification;

namespace Utils
{
    public class Temp
    {
        public static PropertyParts ConvertFromProjectFilePropertyToPropertyParts(ProjectFileProperty projectFileProperty)
        {
            return new PropertyParts()
            {
                CreateFolder = projectFileProperty.CreateFolder,
                FolderOrder = projectFileProperty.FolderOrder,
                Name = projectFileProperty.Value,
                NameType = projectFileProperty.Name,
                FNSId = projectFileProperty.Id
            };
        }
        public static string FormatPath(string path)
        {
            string result = path.Replace("/", "\\");
            //result = result.TrimStart("\\");
            return result;
        }
        public BackgroundWorker bgw = new BackgroundWorker();
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
            SelectFileForm? selectedFilesForm,
            string destination,
            bool fromSvn,
            string UserName,
            string Password,
            string sourceSVN,
            string sourceLocalFile
            )
        {
            var log = Log.GetInstance();
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
                selectedFilesForm.ClassificationProgressBar.Step = 100 / selectedFiles.Where(s => !string.IsNullOrEmpty(s.Cells["ClassificationPath"].Value.ToString())).ToList().Count;
                try
                {
                    using (var db = Session.GetDatabaseContext())
                    {
                        var rowsToDelete = db.ProjectFiles.AsEnumerable()
                                    .Where(r => r.ProjectId == Session.CurrentProjectId)
                                    .ToList();
                        foreach (var row in rowsToDelete)
                            db.ProjectFiles.Remove(row);
                        db.SaveChanges();
                    }
                    selectedFiles.ForEach(row =>
                    {
                        if (!string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                        {
                            classification.CopyAndClassification(client, row.Cells["_fullPath"].Value.ToString(), row.Cells["ClassificationPath"].Value.ToString(), destination, fromSvn);
                            Tuple<int, string> _ProjectFileproperties = (Tuple<int, string>)row.Cells["_ProjectFileProperties"].Value;

                            int projectFileId = SaveProjectFile(_ProjectFileproperties,  row.Cells["_fullPath"].Value.ToString());
                            SaveProjectFileProperties(projectFileId, row.Cells["_propertyParts"].Value as List<PropertyParts>/*, row.Cells["_fullPath"].Value.ToString()*/);
                            selectedFilesForm.ClassificationProgressBar.PerformStep();
                            //if (string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                            //    summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + destination);
                            //else
                            summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + row.Cells["ClassificationPath"].Value.ToString());
                        }
                    }
                    );
                }
                catch { }
            }
            else
            {
                var classification = Classification.Service.Classification.GetInstance();
                selectedFiles.AddRange(selectedFilesForm?.GetSelectedFiles(selectedFilesForm?.FilesDataGridView));
                selectedFilesForm.ClassificationProgressBar.Visible = true;
                selectedFilesForm.ClassificationProgressBar.Minimum = 1;
                selectedFilesForm.ClassificationProgressBar.Maximum = 100;
                selectedFilesForm.ClassificationProgressBar.Step = 100 / selectedFiles.Where(s => !string.IsNullOrEmpty(s.Cells["ClassificationPath"].Value.ToString())).ToList().Count;
                try
                {
                    using (var db = Session.GetDatabaseContext())
                    {
                        var rowsToDelete = db.ProjectFiles.AsEnumerable()
                                    .Where(r => r.ProjectId == Session.CurrentProjectId)
                                    .ToList();
                        foreach (var row in rowsToDelete)
                            db.ProjectFiles.Remove(row);
                        db.SaveChanges();
                    }
                    selectedFiles.ForEach(row =>
                    {

                        if (!string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                        {
                            classification.CopyAndClassification(null, row.Cells["_fullPath"].Value.ToString(), row.Cells["ClassificationPath"].Value.ToString(), destination, false);

                            Tuple<int, string>? _ProjectFileproperties = string.IsNullOrEmpty(row.Cells["_ProjectFileProperties"].Value.ToString()) ? null : (Tuple<int, string>)row.Cells["_ProjectFileProperties"].Value;


                            int projectFileId = SaveProjectFile(_ProjectFileproperties,  row.Cells["_fullPath"].Value.ToString());
                            SaveProjectFileProperties(projectFileId, row.Cells["_propertyParts"].Value as List<PropertyParts>/*, row.Cells["_fullPath"].Value.ToString()*/);
                            selectedFilesForm.ClassificationProgressBar.PerformStep();
                            //if (string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                            //    summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + destination);
                            //else
                            summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + row.Cells["ClassificationPath"].Value.ToString());
                        }
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

        //internal static void updateSettings(Project currentProject, Form form)
        //{
        //    Session.CurrentProject = Session.GetDatabaseContext().Projects.Where(p => p.Id == Session.CurrentProjectId).FirstOrDefault();
        //    metroLabelProjectName.Text = Session.CurrentProject.Name;
        //    UserSetting.setCurrentProjectId(Session.GetDatabaseContext(), Session.CurrentProjectId);
        //    metroProjectListComboBox.SelectedIndex = metroProjectListComboBox.FindStringExact(Session.CurrentProject.Name);
        //}

        public static int SaveProjectFile(Tuple<int, string> projectFileproperties, string file)
        {
            using var db = Session.GetDatabaseContext();
            ProjectFile projectFile = new ProjectFile()
            {
                ProjectId = projectFileproperties.Item1,

                
                File = FormatPath(Path.Combine(projectFileproperties.Item2, Path.GetFileName(file)))

            };
            db.ProjectFiles.Add(projectFile);
            db.SaveChanges();
            return projectFile.Id;
        }
        public static void SaveProjectFileProperties(int projectFileId, List<PropertyParts> propertyParts)
        {
            using var db = Session.GetDatabaseContext();
            foreach (PropertyParts propertyParts1 in propertyParts)
            {
                ProjectFileProperty projectFileProperty = new ProjectFileProperty()
                {
                    ProjectFileId = projectFileId,
                    CreateFolder = propertyParts1.CreateFolder,
                    FolderOrder = propertyParts1.FolderOrder,
                    Name = propertyParts1.NameType,
                    Value = propertyParts1.Name,
                    SortingNumber = db.ProjectFileNameStructures.Where(t => t.Id == propertyParts1.FNSId).Select(t => t.SortingNumber).FirstOrDefault()
                };
                db.ProjectFileProperties.Add(projectFileProperty);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { }
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
            private List<PropertyParts> propertyParts;
            private Tuple<int, string> projectFileProperties;

            public string Path { get => path; set => path = value; }
            public string Name { get => name; set => name = value; }
            public long Size { get => size; set => size = value; }
            public bool Selected { get => selected; set => selected = value; }
            public bool ValidFileStrusture { get => validFileStrusture; set => validFileStrusture = value; }
            public string PathToClassify { get => pathToClassify; set => pathToClassify = value; }
            public List<PropertyParts> PropertyParts { get => propertyParts; set => propertyParts = value; }
            public Tuple<int, string> ProjectFileProperties { get => projectFileProperties; set => projectFileProperties = value; }
        }
        public static class PrepareControls
        {
            public static List<LinkedControls> RenderAndReturnListofLinkedControlsInForm(Form form) => GetAdditionalControls(
                       Session.CurrentProject.ProjectFileNameStructures.ToList(),
                       778,
                       20,
                       60,
                       form);

            public static List<LinkedControls> GetAdditionalControls(
                List<ProjectFileNameStructure> projectFileNameStructures,
                int beginX,
                int beginY,
                int SepDest,
                Form form)
            {
                int i = 0;
                List<LinkedControls> controls = new List<LinkedControls>();
                projectFileNameStructures./*Where(t => t.CreateFolder).*/OrderBy(t => t.FolderOrder).ToList().ForEach(t =>
                    {
                        if (t.NameType.Equals(FNSTypes.fns_date.Id))
                        {

                            DateTimePicker dateTimePicker = new MetroDateTime
                            {
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"
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
                                Width = 250,
                                Name = "Added_"


                            };
                            Session.GetDatabaseContext().LOTs.Where(lot => lot.ProjectId == Session.CurrentProjectId).ToList().ForEach(lot => metroComboBox.Items.Add(new ComboboxItem()
                            {
                                Text = lot.Name,
                                Value = lot.Id
                            })
                            );
                            metroComboBox.SelectedIndex = metroComboBox.Items.Count - 1;
                            form.Controls.Add(metroComboBox);
                            controls.Add(new LinkedControls(t.Id, metroComboBox));
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
                                Width = 250,
                                Name = "Added_"
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
                                Width = 100,
                                Name = "Added_"
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
                                ReadOnly = t.NameType.Equals(FNSTypes.fns_text_match.Id),
                                Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"
                            };
                            form.Controls.Add(metroTextBox);
                            controls.Add(new LinkedControls(t.Id, metroTextBox));
                        }
                        form.Controls.Add(new MetroLabel
                        {

                            Text = t.Name,
                            Location = new Point(beginX, beginY + (SepDest * i)),
                            Theme = MetroFramework.MetroThemeStyle.Dark,
                            Name = "Added_"

                        });
                    });
                return controls;
            }

            public static List<LinkedControls> RenderAndReturnListofLinkedControlsInForm2(CheckDiscrepancyForm checkDiscrepancyForm, int fileid)
   => GetAdditionalControls2(
                       Session.GetDatabaseContext().ProjectFileProperties.Where(s=>s.ProjectFileId==fileid).ToList(),
                       778,
                       20,
                       60,
                       checkDiscrepancyForm);

                public static List<LinkedControls> GetAdditionalControls2(
                List<ProjectFileProperty> projectFileProperties,
                int beginX,
                int beginY,
                int SepDest,
                Form form)
                {
                    int i = 0;
                    List<LinkedControls> controls = new List<LinkedControls>();
                projectFileProperties./*Where(t => t.CreateFolder).*/OrderBy(t => t.FolderOrder).ToList().ForEach(t =>
                    {
                        if (t.Name.Equals(FNSTypes.fns_date.Id))
                        {

                            DateTimePicker dateTimePicker = new MetroDateTime
                            {
                                //Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"
                            };
                            form.Controls.Add(dateTimePicker);
                            controls.Add(new LinkedControls(t.Id, dateTimePicker));
                        }
                        else if (t.Name.Equals(FNSTypes.fns_lot.Id))
                        {
                            MetroComboBox metroComboBox = new MetroComboBox
                            {
                                Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"


                            };
                            Session.GetDatabaseContext().LOTs.Where(lot => lot.ProjectId == Session.CurrentProjectId).ToList().ForEach(lot => metroComboBox.Items.Add(new ComboboxItem()
                            {
                                Text = lot.Name,
                                Value = lot.Id
                            })
                            );
                            metroComboBox.SelectedIndex = metroComboBox.FindStringExact(t.Value);
                            metroComboBox.SelectedText = metroComboBox.SelectedItem.ToString();
                            form.Controls.Add(metroComboBox);
                            controls.Add(new LinkedControls(t.Id, metroComboBox));
                        }
                        else if (t.Name.Equals(FNSTypes.fns_date_index.Id))
                        {
                            LinkedControls linkedControls = new LinkedControls();
                            Tuple<int, Control> tuple;
                            DateTimePicker dateTimePicker = new MetroDateTime
                            {
                                Text = t.Value.Split('_')[0],
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"
                            };
                            form.Controls.Add(dateTimePicker);
                            tuple = Tuple.Create<int, Control>(t.Id, dateTimePicker);
                            linkedControls.LinkedList.AddFirst(tuple);
                            MetroTextBox metroTextBox = new MetroTextBox
                            {
                                Text = t.Value.Split('_')[1],
                                Location = new Point(beginX + 380, beginY + (SepDest * i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 100,
                                Name = "Added_"
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
                                ReadOnly = t.Name.Equals(FNSTypes.fns_text_match.Id),
                                Text = t.Name,
                                Location = new Point(beginX + 100, beginY + (SepDest * ++i)),
                                Theme = MetroFramework.MetroThemeStyle.Dark,
                                Style = MetroFramework.MetroColorStyle.Blue,
                                Height = 20,
                                Width = 250,
                                Name = "Added_"
                            };
                            form.Controls.Add(metroTextBox);
                            controls.Add(new LinkedControls(t.Id, metroTextBox));
                        }
                        form.Controls.Add(new MetroLabel
                        {

                            Text = t.Name,
                            Location = new Point(beginX, beginY + (SepDest * i)),
                            Theme = MetroFramework.MetroThemeStyle.Dark,
                            Name = "Added_"

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
        public static void SummaryMessageBox(string message, string caption, MessageBoxIcon messageType)
        {
            MessageBox.Show(new Form { Size = new Size(600, 800) }, message, caption, MessageBoxButtons.OK, messageType);
        }
    }
    public class Tempjoin
    {
        public string Id { get; set; }
        public bool inDatabase { get; set; }

        public bool inFileSystem { get; set; }

        public List<ProjectFileProperty> PropertyParts { get; set; }


    }

}
