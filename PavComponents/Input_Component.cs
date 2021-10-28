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
    /// <summary>
    /// Класс для работы с контролом TextBox и CheckBox
    /// </summary>
    public partial class Input_Component : UserControl
    {
        public Input_Component()
        {
            InitializeComponent();
        }
        /// <summary>
        /// При изменении состояния CkeckBox'а меняется возможность редактирования textBox'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            textBox.ReadOnly = checkBox.Checked;
        }

        /// <summary>
        /// Свойства для получения и установки значения в TextBox
        /// </summary>
        public double? TextBox_Text
        {
            get
            {
                if (checkBox.Checked)
                {
                    return null;
                }

                if (!checkBox.Checked && textBox.Text == String.Empty)
                {
                    throw new Exception("Строка пуста!");
                }

                try
                {
                    Convert.ToDouble(textBox.Text);
                }
                catch
                {
                    throw new Exception("Это не вещественное число!");
                }

                return Convert.ToDouble(textBox.Text);
            }

            set
            {
                if (value == null)
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                    textBox.Text = value.ToString();
                }
            }
        }
    }
}