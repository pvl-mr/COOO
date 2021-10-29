using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PavComponents
{
    public partial class ComboboxControl : UserControl
    {
        public ComboboxControl()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                _comboBoxSelectedElementChange?.Invoke(sender, e);
            };
        }

        private int _selectedIndex;

        private event EventHandler _comboBoxSelectedElementChange;

        [Category("Спецификация"), Description("Порядковый номер выбранного элемента")]
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (value > -2 && value < comboBox.Items.Count)
                {
                    _selectedIndex = value;
                    comboBox.SelectedIndex = _selectedIndex;
                }
            }
        }

        [Category("Спецификация"), Description("Текст выбранной записи")]
        public string SelectedText
        {
            get { return comboBox.Text; }
        }

        [Category("Спецификация"), Description("Событие выбора элемента из списка")]
        public event EventHandler ComboBoxSelectedElementChange
        {
            add { _comboBoxSelectedElementChange += value; }
            remove { _comboBoxSelectedElementChange -= value; }
        }

        public string SelectedValue
        {
            get => comboBox.SelectedItem == null ? string.Empty : comboBox.SelectedItem.ToString();
            set => comboBox.SelectedItem = value;
        }

        public void AddToList(String str)
        {
            comboBox.Items.Add(str);
        }

        public void Clear()
        {
            comboBox.Items.Clear();
        }

    }
}

