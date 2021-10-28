using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PavlovaComponents
{
    public partial class ListBoxControl : UserControl
    {
        public ListBoxControl()
        {
            InitializeComponent();
        }
        public String _maketLine;
        public String MaketLine { set { _maketLine = value; } }

        /// <summary>
        /// Порядковый номер выбранного элемента
        /// </summary>
        [Category("Спецификация"), Description("Порядковый номер выбранного элемента")]
        public int SelectedIndex
        {
            get { return listBox.SelectedIndex; }
            set
            {
                if (value > -1 && value < listBox.Items.Count)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }
        string[] chars = new string[2];
        public void setSplitingChars(string inputLine)
        {
            string[] param = inputLine.Split(',');
            if (param.Length == 2)
                chars = param;
            else if (param.Length == 1)
            {
                chars[0] = param[0];
                chars[1] = param[0];
            }
            else
                return;

        }
        private string removeChars(string inputLine)
        {
            return inputLine.Replace(chars[0], null).Replace(chars[1], null);
        }

        public void AddToList<T>(T obj)
        {
            if (obj != null)
            {
                string[] line = _maketLine.Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    int start = line[i].IndexOf(chars[0]);
                    int end = line[i].IndexOf(chars[1]);

                    string param = line[i].Substring(start + 1, end - start - 1);
                    var elem = obj.GetType().GetProperty(param);
                    Console.WriteLine("PARAM " + param);
                    if (elem != null)
                    {
                        line[i] = line[i].Replace(param, null);
                        line[i] = line[i].Insert(start + 1, elem.GetValue(obj, null)?.ToString());
                    }
                }
                string result = string.Join(",", line);
                listBox.Items.Add(result);
            }
        }
        public T GetItem<T>() where T : class, new()
        {
            T restoreItem;
            if (listBox.SelectedIndex != -1 && _maketLine != null)
            {
                T itemT = Activator.CreateInstance<T>();
                string selectedItemString = listBox.SelectedItem.ToString();
                string regPropertyName = chars[0] + "[\\d]+" + chars[1];
                string[] lines = Regex.Split(_maketLine, regPropertyName);
                var properties = Regex.Matches(_maketLine, regPropertyName);
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    int lineLength = lines[i].Length;
                    string propertyName = removeChars(properties[i].Value);
                    int indexNextParam = selectedItemString.IndexOf(lines[i + 1]);
                    string propertyValue;
                    if (indexNextParam == 0)
                    {
                        propertyValue = selectedItemString.Substring(lineLength);
                    }
                    else
                    {
                        propertyValue = selectedItemString.Substring(lineLength, indexNextParam - lineLength);
                        selectedItemString = selectedItemString.Substring(indexNextParam);
                    }
                    propertyValue = removeChars(propertyValue);
                    var property = itemT.GetType().GetProperty(propertyName);
                    if (property != null && propertyValue != chars[0] + propertyName + chars[1])
                    {
                        var propertyInfo = property;
                        var propertyType = property?.PropertyType;
                        propertyInfo.SetValue(itemT, Convert.ChangeType(propertyValue, propertyType));
                    }
                }
                restoreItem = itemT;
            }
            else
            {
                restoreItem = default;
            }
            return restoreItem;
        }
    }
}
