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
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl()
        {
            InitializeComponent();

        }

        public string patternToData { get; set; }

        private String _enteredDate;

        public String EnteredDate
        {
            get
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    if (!Regex.IsMatch(textBox.Text, patternToData))
                    {
                        _enteredDate = textBox.Text;
                        return _enteredDate;
                    }
                    else
                    {
                        throw new Exception("Введено не в правильном формате");
                    };
                }
                else
                    return null;
            }
            set
            {
                _enteredDate = textBox.Text;
            }
        }
        public void SetTooltip(string str)
        {
            toolTip.SetToolTip(textBox, str);
        }
    }
}
