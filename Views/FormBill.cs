using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace Views
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

            
            foreach (var orderType in types)
            {
                comboboxControl1.AddToList(orderType.ToString());
            }
            if (id.HasValue)
            {
                try
                {
                    var view = billLogic.Read(new BillBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxWaiter.Text = view.WaiterFullName;
                        textBoxDescription.Text = view.Info;
                        comboboxControl1.SelectedValue = view.Type.ToString();
                        if (view.Cost.Equals("0"))
                        {
                            userControlTextBox2.Value = null;
                        }
                        else if (double.TryParse(view.Cost, out double d))
                        {
                            userControlTextBox2.Value = Convert.ToDouble(view.Cost);
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
    }
}
