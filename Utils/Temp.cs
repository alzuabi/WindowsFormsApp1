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
        public static string textMach;
        public Func<string, Control> getControl;
        public const string PREFEXFolder = "Reception";
        public const string LASTSVNURL = "last_svn_url";
        public const string LASTLOCALFILE = "last_local_file";
        public const string RVTEXT = ".rvt";

        public static string GetDateFromDateIndex(string date)
        {
            try
            {
                string res = "";
                ProjectFileNameStructure? projectFileNameStructures = Session.CurrentProject.ProjectFileNameStructures
                    .Where(s => s.NameType.Equals(FNSTypes.fns_date_index.Id))
                    .FirstOrDefault();

                if (projectFileNameStructures is not null)
                {
                    DateTimePicker dateTimePicker = new()
                    {
                        Value = DateTime.ParseExact(date, projectFileNameStructures.Description, null),
                        CustomFormat = projectFileNameStructures.Description,
                        Format = DateTimePickerFormat.Custom
                    };
                    res = dateTimePicker.Value.ToString();
                }
                return res;
            }
            catch
            {
                return "";
            }
            }

        public static string GetPart(string str, string sep, int i)
        {
            int idx = str.LastIndexOf(sep);
            string res = "";
            if (idx != -1)
            {
                if (i == 0)
                    res = str.Substring(0, idx);
                else if (i == 1)
                    res = str.Substring(idx + 1);
                else if (i == 2)
                    res = str.Substring(idx + 2);
            }
            return res;
        }

        public static string GetPart2(string str, char  sep, int i)
        {
            string res = "";
            string[] words = str.Split(sep);
                if (i == 1)
                    res = words[words.Length-1];
                else if (i == 2)
                    res = words[words.Length - 2];
                else if (i == 3)
                    res = words[words.Length - 3];

            return res;
        }


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
            return result;
        }
        public BackgroundWorker bgw = new();
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
            List<string> summary = new();
            List<DataGridViewRow> selectedFiles = new();
            PrepareSelectedFilesAndProgressBar(selectedFiles, selectedFilesForm);
            var classification = Classification.Service.Classification.GetInstance();
            SvnClient client = null;
            if (fromSvn)
            {
                client = new();
                client.Authentication.DefaultCredentials = new NetworkCredential(UserName, Password);
            }
            try
            {
                selectedFiles.ForEach(row =>
                {
                    if (!string.IsNullOrEmpty(row.Cells["ClassificationPath"].Value.ToString()))
                    {
                        if (classification.CopyAndClassification(client, row.Cells["_fullPath"].Value.ToString(), row.Cells["ClassificationPath"].Value.ToString(), destination, fromSvn))
                        {
                            Tuple<int, string>? _ProjectFileproperties = string.IsNullOrEmpty(row.Cells["_ProjectFileProperties"].Value.ToString()) ? null : (Tuple<int, string>)row.Cells["_ProjectFileProperties"].Value;
                            List<int> projectFileId = SaveProjectFile(_ProjectFileproperties, Path.Combine(row.Cells["_fullPath"].Value.ToString()));
                            SaveProjectFileProperties(projectFileId, row.Cells["_propertyParts"].Value as List<PropertyParts>);
                            selectedFilesForm.ClassificationProgressBar.PerformStep();
                            summary.Add("The file " + row.Cells["_fullPath"].Value.ToString() + " has been copied  to " + row.Cells["ClassificationPath"].Value.ToString());
                        }
                    }
                }
                );
            }
            catch { return null; }
            return summary;
        }

        private static void PrepareSelectedFilesAndProgressBar(List<DataGridViewRow> selectedFiles, SelectFileForm selectedFilesForm)
        {
            selectedFiles.AddRange(selectedFilesForm?.GetSelectedFiles(selectedFilesForm?.FilesDataGridView));
            selectedFilesForm.ClassificationProgressBar.Visible = true;
            selectedFilesForm.ClassificationProgressBar.Minimum = 1;
            selectedFilesForm.ClassificationProgressBar.Maximum = 100;
            int count = selectedFiles.Where(s => !string.IsNullOrEmpty(s.Cells["ClassificationPath"].Value.ToString())).ToList().Count;
            selectedFilesForm.ClassificationProgressBar.Step = 100 / count;
        }

        public static List<int> SaveProjectFile(Tuple<int, string> projectFileproperties, string file)
        {
            using var db = Session.GetDatabaseContext();
            ProjectFile projectFile = new()
            {
                ProjectId = projectFileproperties.Item1,
                File = FormatPath(Path.Combine(
                    projectFileproperties.Item2, Path.GetFileName(file))
                )
            };

            List<int> ProjectFilesIds = db.ProjectFiles.AsEnumerable()
                .Where(s => Path.GetFullPath(s.File).Equals(Path.GetFullPath(projectFile.File)))
                .Where(s => s.ProjectId == projectFileproperties.Item1)
                .Select(s => s.Id)
                .ToList();
            if (ProjectFilesIds.Count == 0)
            {
                db.ProjectFiles.Add(projectFile);
                db.SaveChanges();
                return new List<int> { projectFile.Id };
            }
            else
                return ProjectFilesIds;
        }
        public static void SaveProjectFileProperties(List<int> projectFileIds, List<PropertyParts> listPropertyParts)
        {
            using var db = Session.GetDatabaseContext();
            foreach (int projectFileId in projectFileIds)
            {
                List<ProjectFileProperty> projectFileProperties = db.ProjectFileProperties.AsEnumerable().Where(s => s.ProjectFileId == projectFileId).ToList();
                if (projectFileProperties.Count == 0)
                {
                    List<ProjectFileProperty> projectFileProperties1 = new();
                    foreach (PropertyParts propertyParts in listPropertyParts)
                    {
                        ProjectFileProperty projectFileProperty = new()
                        {
                            ProjectFileId = projectFileId,
                            CreateFolder = propertyParts.CreateFolder,
                            FolderOrder = propertyParts.FolderOrder,
                            Name = propertyParts.NameType,
                            Value = propertyParts.Name,
                            SortingNumber = db.ProjectFileNameStructures.Where(t => t.Id == propertyParts.FNSId).Select(t => t.SortingNumber).FirstOrDefault()
                        };
                        ProjectFileProperty? ex = projectFileProperties1.FirstOrDefault(s => s.Name == propertyParts.NameType);
                        if (ex is not null)
                            projectFileProperties1.FirstOrDefault(s => s.Name == propertyParts.NameType).Value += '_' + propertyParts.Name;
                        else
                            projectFileProperties1.Add(projectFileProperty);
                    }
                    db.ProjectFileProperties.AddRange(projectFileProperties1);
                }
                else
                {

                    foreach (ProjectFileProperty prop in projectFileProperties)
                    {
                        prop.Value = "";
                        foreach (PropertyParts propertyParts in listPropertyParts)
                        {
                            if (prop.Name.Equals(propertyParts.NameType))
                            {
                                if (propertyParts.NameType.Equals(FNSTypes.fns_date_index.Id)|| propertyParts.NameType.Equals(FNSTypes.fns_index.Id))
                                {
                                    prop.Value += propertyParts.Name + '_';
                                    prop.CreateFolder = propertyParts.CreateFolder;
                                    prop.FolderOrder = propertyParts.FolderOrder;
                                    prop.Name = propertyParts.NameType;
                                    prop.SortingNumber = db.ProjectFileNameStructures.Where(t => t.Id == propertyParts.FNSId).Select(t => t.SortingNumber).FirstOrDefault();
                                }
                                else 
                                {
                                    prop.Value = propertyParts.Name;
                                    prop.CreateFolder = propertyParts.CreateFolder;
                                    prop.FolderOrder = propertyParts.FolderOrder;
                                    prop.Name = propertyParts.NameType;
                                    prop.SortingNumber = db.ProjectFileNameStructures.Where(t => t.Id == propertyParts.FNSId).Select(t => t.SortingNumber).FirstOrDefault();
                                }
                            }
                        }
                        prop.Value = prop.Value.TrimEnd('_');
                    }
                }
                db.SaveChanges();
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
            public static List<LinkedControls> RenderAndReturnListofLinkedControlsInForm(Form form) => 
                GetAdditionalControls(projectFileNameStructures: Session.CurrentProject.ProjectFileNameStructures.ToList(),
                    beginX: 600,
                    beginY: 20,
                    SepDest: 60,
                    form);

            public static List<LinkedControls> GetAdditionalControls(
                List<ProjectFileNameStructure> projectFileNameStructures,
                int beginX,
                int beginY,
                int SepDest,
                Form form)
            {
                ConditionalControl delegates = new();
                int i = 0;
                List<LinkedControls> controls = new();
                projectFileNameStructures./*Where(t => t.CreateFolder).*/OrderBy(t => t.FolderOrder).ToList().ForEach(t =>
                    {
                        LinkedControls linkedControls = delegates.conditionsGenerate[t.NameType](beginX + 200, beginY + (SepDest * ++i), 200, 20, "", "Added_", t.Id);
                        form.Controls.AddRange(linkedControls.getControls());
                        controls.Add(linkedControls);
                        
                        form.Controls.AddRange(
                            new List<Control>() {
                            delegates.conditionsGenerate[ConditionalControl.folder_icon](beginX + 150, beginY + (SepDest * i), 30, 30, t.CreateFolder, "Added_",t.Id).getControls().First(),
                            delegates.conditionsGenerate[ConditionalControl.label](beginX +60, beginY + (SepDest * i), 0, 0, t.Name, "Added_",t.Id).getControls().First(),
                            delegates.conditionsGenerate[ConditionalControl.small_label](beginX+60 , beginY + (SepDest * i)+20, 0, 0, t.NameType, "Added_",t.Id).getControls().First(),
                            }.ToArray()
                            );
                    });
                return controls;
            }

            public static List<LinkedControls> RenderAndReturnListofLinkedControlsInForm(CheckDiscrepancyForm checkDiscrepancyForm, int fileid) => GetAdditionalControls(
                       Session.GetDatabaseContext().ProjectFileProperties.Where(s => s.ProjectFileId == fileid).ToList(),
                       600,
                       20,
                       60,
                       checkDiscrepancyForm);

            public static List<LinkedControls> GetAdditionalControls(
            List<ProjectFileProperty> projectFileProperties,
            int beginX,
            int beginY,
            int SepDest,
            Form form)
            {

                int i = 0;
                int k = 0;
                ConditionalControl delegates = new();
                List<LinkedControls> controls = new();
                List<ProjectFileNameStructure> ProjectFNS = Session.GetDatabaseContext().ProjectFileNameStructures.Where(s => s.ProjectId == Session.CurrentProjectId).OrderBy(s => s.SortingNumber).ToList();
                projectFileProperties./*Where(t => t.CreateFolder).*/OrderBy(t => t.FolderOrder).ToList().ForEach(t =>
                {
                    LinkedControls linkedControls = delegates.conditionsGenerate[t.Name](beginX + 200, beginY + (SepDest * ++i), 200, 20, "", "Added_", t.Id);
                    form.Controls.AddRange(linkedControls.getControls());
                    controls.Add(linkedControls);
                       
                    form.Controls.AddRange(
                        new List<Control>() {
                            delegates.conditionsGenerate["createFolderIcon"](beginX + 150, beginY + (SepDest * i), 30, 30, t.CreateFolder, "Added_",t.Id).getControls().First(),
                            k<ProjectFNS.Count? delegates.conditionsGenerate["label"](beginX +80, beginY + (SepDest * i), 0, 0, ProjectFNS[k].Name, "Added_",t.Id).getControls().First() : null,
                            delegates.conditionsGenerate["smallLabel"](beginX+80 , beginY + (SepDest * i)+20, 0, 0, t.Name, "Added_",t.Id).getControls().First(),
                        }.ToArray()
                        );
                    k++;
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
            private LinkedList<LinkedListNode<Tuple<int, Control, string>>> linkedList = new();

            public LinkedList<LinkedListNode<Tuple<int, Control, string>>> LinkedList { get => linkedList; set => linkedList = value; }

            public LinkedControls(int id, Control control, string type)
            {
                linkedList.AddLast(new LinkedListNode<Tuple<int, Control, string>>(Tuple.Create(id, control,type)));
            }

            public Control getControl(LinkedListNode<Tuple<int, Control, string>>  tuple) => tuple.Value.Item2;

            public Control[] getControls() => linkedList.Where(s => s is not null).Select(s => s.Value.Item2).ToArray();
            public LinkedControls() { }
        }
        public static DialogResult SummaryMessageBox(string message, string caption, MessageBoxIcon messageType, MessageBoxButtons messageBox = MessageBoxButtons.OK)
        {
            return MessageBox.Show(new Form { Size = new Size(600, 800) }, message, caption, messageBox, messageType);
        }

        public static void RefreshComboBox(ComboBox metroComboBox)
        {
            metroComboBox.Items.Clear();
            Session.GetDatabaseContext().Projects.ToList().ForEach(project => metroComboBox.Items.Add(
            new ComboboxItem()
            {
                Text = Path.Combine(project.Name),
                Value = project.Id
            })
        );
        }

        public static void SetLast(string kye, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            using var db = Session.GetDatabaseContext();
            var res = db.UserSettings.FirstOrDefault(s => s.Name.Equals(kye));
            if (res is not null)
                res.Value = value;
            else
                db.UserSettings.Add(new UserSetting
                {
                    Name = kye,
                    Value = value
                }
                );
            db.SaveChanges();
        }
        public static string? GetLast(string key)
        {
            using var db = Session.GetDatabaseContext();
            return db.UserSettings.FirstOrDefault(s => s.Name.Equals(key))?.Value;
        }

    }



}
