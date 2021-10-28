using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogic;
using BusinessLogics.Enums;
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
            var waiters = waiterLogic.Read(null);

            foreach (var orderType in types)
            {
                comboboxControl1.AddToList(orderType.ToString());
                
            }

            foreach(var waiter in waiters)
            {
                comboboxControlWaiter.AddToList(waiter.WaiterFullName);
            }
            if (id.HasValue)
            {
                try
                {
                    var view = billLogic.Read(new BillBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        comboboxControlWaiter.SelectedValue = view.WaiterFullName;
                        textBoxDescription.Text = view.Info;
                        comboboxControl1.SelectedValue = view.Type.ToString();
                        if (view.Sum.Equals("0"))
                        {
                            input_Component1.TextBox_Text = null;
                        }
                        else if (double.TryParse(view.Sum.ToString(), out double d))
                        {
                            input_Component1.TextBox_Text = Convert.ToDouble(view.Sum);
                        }
                    }
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
                int sum = 0;
                if (input_Component1.TextBox_Text == null)
                {
                    sum = 0;
                }
                else if (int.TryParse(input_Component1.TextBox_Text.ToString(), out int i))
                {
                    sum = Convert.ToInt32(input_Component1.TextBox_Text);
                }
                OrderType type;
                if (Enum.TryParse(comboboxControl1.SelectedText, out OrderType myStatus))
                {
                    type = myStatus;
                }
                /////////////пофиксить
                var waiter = waiterLogic.Read(new WaiterBindingModel() { WaiterFullName = comboboxControlWaiter.SelectedText });
                billLogic.CreateOrUpdate(new BillBindingModel
                {
                    Id = id,
                    WaiterId = waiter[0].Id,
                    Info = textBoxDescription.Text,
                    Type = myStatus,
                    Sum = sum
                });
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
        }
    }
}
