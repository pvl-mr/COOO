using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogic;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace Forms
{
    public partial class FormBill : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly BillLogic billLogic;

        private readonly TypeLogic typeLogic;
        private int? id;
        private BillViewModel elem;
        public BillViewModel Elem { set { elem = value; } }
        public int Id { set { id = value; } }
        

        public FormBill(BillLogic billLogic, TypeLogic waiterLogic)
        {
            InitializeComponent();
            this.billLogic = billLogic;
            this.typeLogic = waiterLogic;
        }

        private void FormBill_Load(object sender, EventArgs e)
        {    
            var types = typeLogic.Read(null);
            foreach (var type in types)
            {
                comboboxControlType.AddToList(type.TypeName);
            }
            
            if (elem != null)
            {
                try
                {
                 
                    comboboxControlType.SelectedValue = elem.TypeName;
                    textBoxDescription.Text = elem.Info;
                    input_Component1.TextBox_Text = Convert.ToDouble(elem.Sum.Replace('.', ','));
                    textBoxName.Text = elem.WaiterFullName;

                    if (elem.Sum.Equals("0.00"))
                    {
                        input_Component1.TextBox_Text = null;
                    }
                    else if (double.TryParse(elem.Sum.ToString(), out double d))
                    {
                        input_Component1.TextBox_Text = Convert.ToDouble(elem.Sum);
                    }
                    
                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboboxControlType.SelectedValue))
            {
                MessageBox.Show("Заполните тип", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {

                decimal sum = 0;
                if (input_Component1.TextBox_Text == null)
                {
                    sum = 0;
                }
                else if (decimal.TryParse(input_Component1.TextBox_Text.ToString(), out decimal i))
                {
                    sum = Convert.ToDecimal(input_Component1.TextBox_Text);
                }



                var waiter = typeLogic.Read(new TypeBindingModel() { TypeName = comboboxControlType.SelectedText });

                    billLogic.CreateOrUpdate(new BillBindingModel
                    {
                        Id = id,
                        TypeId = waiter[0].Id,
                        Info = textBoxDescription.Text,
                        WaiterFullName = textBoxName.Text,
                        Sum = sum
                    }) ;
                
                
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormType>();
            form.ShowDialog();
            comboboxControlType.Clear();
            var types = typeLogic.Read(null);
            foreach (var type in types)
            {
                comboboxControlType.AddToList(type.TypeName);
            }
        }

    }
}
