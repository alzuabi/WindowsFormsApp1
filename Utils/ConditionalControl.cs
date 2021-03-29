using FontAwesome.Sharp;
using MetroFramework.Controls;
using MULTISYSUtilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utils.Temp;

namespace PullAndClassification.Utils
{
    public class ConditionalControl
    {
        public static string date = FNSTypes.fns_date.Id;
        public static string date_index = FNSTypes.fns_date_index.Id;
        public static string lot = FNSTypes.fns_lot.Id;
        public static string check = "tempCheckBox";
        public static string index = FNSTypes.fns_index.Id;
        public static string text_match = FNSTypes.fns_text_match.Id;
        public static string folder_icon = "createFolderIcon";
        public static string label = "label";
        public static string small_label = "smallLabel";
        public static string text = FNSTypes.fns_text.Id;



        public IDictionary<string, Func<int, int, int, int, object, string, int, LinkedControls>> conditionsGenerate = new Dictionary<string, Func<int, int, int, int, object, string, int, LinkedControls>>();
        public ConditionalControl()
        {
            conditionsGenerate[date] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                MetroDateTime metroDateTime = new()
                {
                    Location = new Point(startX, startY),
                    Theme = MetroFramework.MetroThemeStyle.Default,
                    Style = MetroFramework.MetroColorStyle.Blue,
                    Height = hight,
                    Width = width,
                    Name = name
                };
                return new LinkedControls(id, metroDateTime,date);
            };


            conditionsGenerate[lot] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                MetroComboBox metroComboBox = new()
                {
                    Text = (string)text,
                    Location = new Point(startX, startY),
                    Theme = MetroFramework.MetroThemeStyle.Default,
                    Style = MetroFramework.MetroColorStyle.Blue,
                    Height = hight,
                    Width = width,
                    Name = name
                };
                Session.GetDatabaseContext().LOTs.Where(lot => lot.ProjectId == Session.CurrentProjectId).ToList().ForEach(lot => metroComboBox.Items.Add(new ComboboxItem()
                {
                    Text = lot.Name,
                    Value = lot.Id
                })
                );
                metroComboBox.SelectedIndex = metroComboBox.Items.Count - 1;
                return new LinkedControls(id, metroComboBox,lot);
            };


            conditionsGenerate[check] = delegate (int startX, int startY, int width, int hight, object value, string name, int id)
            {
                MetroCheckBox metroCheckBox = new()
                {
                    Checked = bool.Parse(value.ToString()),
                    Location = new Point(startX, startY),
                    Theme = MetroFramework.MetroThemeStyle.Default,
                    Style = MetroFramework.MetroColorStyle.Blue,
                    Name = name,
                    Text = "temp"
                };
                return new LinkedControls(id, metroCheckBox, check);
            };


            conditionsGenerate[text] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
                {
                    Control metroTextBox = new MetroTextBox()
                    {
                        Text = (string)text,
                        Location = new Point(startX, startY),
                        Theme = MetroFramework.MetroThemeStyle.Default,
                        Style = MetroFramework.MetroColorStyle.Blue,
                        Height = hight,
                        Width = width,
                        Name = name
                    };
                    return new LinkedControls(id, metroTextBox, ConditionalControl.text);
                };


            conditionsGenerate[index] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                LinkedControls linkedControls = new();

               Tuple<int, Control,string> textControl = conditionsGenerate[ConditionalControl.text](startX, startY, width, hight, text, name, id).LinkedList.FirstOrDefault().Value;

               Tuple<int, Control, string> checkControl = conditionsGenerate[ConditionalControl.check](startX + width, startY, 20, 0, false, name, id).LinkedList.FirstOrDefault().Value;
               
                linkedControls.LinkedList.AddFirst(new LinkedListNode <Tuple<int, Control, string> > (textControl));
                linkedControls.LinkedList.AddLast(new LinkedListNode<Tuple<int, Control, string>>(checkControl));

                return linkedControls;
            };


            conditionsGenerate[date_index] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                LinkedControls linkedControls = new();
                Tuple<int, Control, string> dateControl = conditionsGenerate[date](startX, startY, width, hight, text, name, id).LinkedList.FirstOrDefault().Value;
                LinkedList<LinkedListNode<Tuple<int, Control, string>>> linkedList = conditionsGenerate[index](startX + width, startY, 50, hight, text, name, id).LinkedList;
                linkedControls.LinkedList.AddFirst(new LinkedListNode<Tuple<int, Control, string>>(dateControl));
                linkedList.Where(s => s is not null).ToList().ForEach(s => linkedControls.LinkedList.AddLast(s));
                
                return linkedControls;
            };

            conditionsGenerate[text_match] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                MetroTextBox metroTextBox = new()
                {
                    ReadOnly = true,
                    Location = new Point(startX, startY),
                    Theme = MetroFramework.MetroThemeStyle.Default,
                    Style = MetroFramework.MetroColorStyle.Blue,
                    Height = hight,
                    Width = width,
                    Name = name,
                    Text = Session.GetDatabaseContext().ProjectFileNameStructures
                    .Where(s => s.Id == id)
                    .Where(s => s.NameType == FNSTypes.fns_text_match.Id)
                    .Select(s => s.Description).FirstOrDefault()
                };
                textMach = metroTextBox.Text;
                return new LinkedControls(id, metroTextBox, text_match);
            };


            conditionsGenerate[folder_icon] = delegate (int startX, int startY, int width, int hight, object value, string name, int id)
            {
                IconButton iconButton = new()
                {
                    IconChar = IconChar.Folder,
                    Visible = (bool)value,
                    IconColor = Color.Black,
                    Location = new Point(startX, startY),
                    IconSize = 20,
                    Height = hight,
                    Width = width,
                    Name = name,
                    FlatStyle = FlatStyle.Flat,
                    Enabled = false,

                };
                return new LinkedControls(id, iconButton, folder_icon);
            };


            conditionsGenerate[label] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
             {
               MetroLabel metroLabel = new()
               {
                   Text = (string)text,
                   Location = new Point(startX, startY),
                   Theme = MetroFramework.MetroThemeStyle.Default,
                   Name = "Added_"
               };
               return new LinkedControls(id, metroLabel, label); 
            };


            conditionsGenerate[small_label] = delegate (int startX, int startY, int width, int hight, object text, string name, int id)
            {
                MetroLabel metroLabel = new()
                {
                    FontSize = MetroFramework.MetroLabelSize.Small,
                    Text = (string)text,
                    Location = new Point(startX, startY),
                    Theme = MetroFramework.MetroThemeStyle.Default,
                    Name = "Added_"
                };
                return new LinkedControls(id, metroLabel, small_label);
            };
        }

    }
}
