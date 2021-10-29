using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogic;
using BusinessLogics.Enums;
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

        private readonly WaiterLogic waiterLogic;
        private int? id;
        private BillViewModel elem;
        public BillViewModel Elem { set { elem = value; } }
        public int Id { set { id = value; } }
        

        public FormBill(BillLogic billLogic, WaiterLogic waiterLogic)
        {
            InitializeComponent();
            this.billLogic = billLogic;
            this.waiterLogic = waiterLogic;
        }

        private void FormBill_Load(object sender, EventArgs e)
        {
            var types = Enum.GetValues(typeof(BusinessLogics.Enums.OrderType));
            

            foreach (var orderType in types)
            {
                comboBox1.Items.Add(orderType.ToString());

            }

            var waiters = waiterLogic.Read(null);
            foreach (var waiter in waiters)
            {
                comboboxControlWaiter.AddToList(waiter.WaiterFullName);
            }
            
            if (elem != null)
            {
                try
                {
                   /* var view = billLogic.Read(new BillBindingModel { Id = id })?[0];*/
                    
                    comboboxControlWaiter.SelectedValue = elem.WaiterFullName;
                    textBoxDescription.Text = elem.Info;
                    input_Component1.TextBox_Text = Convert.ToDouble(elem.Sum.Replace('.', ','));
                    comboBox1.SelectedItem = elem.Type;

                    if (elem.Sum.Equals("0.00"))
                    {
                        input_Component1.TextBox_Text = null;
                    }
                    else if (double.TryParse(elem.Sum.ToString(), out double d))
                    {
                        input_Component1.TextBox_Text = Convert.ToDouble(elem.Sum);
                    }
                    
                   /* if (view != null)
                    {
                        comboboxControlWaiter.SelectedValue = view.WaiterFullName;
                        textBoxDescription.Text = view.Info;
                        comboBox1.SelectedValue = view.Type.ToString();

                        if (view.Sum.Equals("0"))
                        {
                            input_Component1.TextBox_Text = null;
                        }
                        else if (double.TryParse(view.Sum.ToString(), out double d))
                        {
                            input_Component1.TextBox_Text = Convert.ToDouble(view.Sum);
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData()
        {
            try
            {

            }
            catch
            {

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboboxControlWaiter.SelectedValue))
            {
                MessageBox.Show("Заполните офицанта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
/*                decimal sum = 0;
                if (input_Component1.TextBox_Text == null)
                {
                    sum = 0;
                } else
                {
                    sum = (decimal)input_Component1.TextBox_Text;
                }*/
               /* decimal sum = 0;
                if (input_Component1.TextBox_Text == null)
                {
                    sum = 0;
                }
                else if (decimal.TryParse(input_Component1.TextBox_Text.ToString(), out decimal i))
                {
                    sum = Convert.ToDecimal(input_Component1.TextBox_Text);
                }*/
                
                var waiter = waiterLogic.Read(new WaiterBindingModel() { WaiterFullName = comboboxControlWaiter.SelectedText });

                    billLogic.CreateOrUpdate(new BillBindingModel
                    {
                        Id = id,
                        WaiterId = waiter[0].Id,
                        Info = textBoxDescription.Text,
                        Type = (OrderType)comboBox1.SelectedItem,
                        Sum = null
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
            var form = Container.Resolve<FormWaiter>();
            form.ShowDialog();
            comboboxControlWaiter.Clear();
            var waiters = waiterLogic.Read(null);
            foreach (var waiter in waiters)
            {
                comboboxControlWaiter.AddToList(waiter.WaiterFullName);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
