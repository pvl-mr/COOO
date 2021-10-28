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
    public partial class MainForm : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly BillLogic billLogic;

        public MainForm(BillLogic billLogic)
        {
            InitializeComponent();
            this.billLogic = billLogic;
            
           
        }
        /// <summary>
        /// Срабатывает при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /*        private BillViewModel[] list =
                    {
                        new BillViewModel()
                        {
                            Id = 0,
                            Type = OrderType.takeaway_food,
                            WaiterFullName = "Fikk",
                            Info = "rjkngr",
                            Sum = 999,
                        },
                        new BillViewModel()
                        {
                            Id = 1,
                            Type = OrderType.takeaway_food,
                            WaiterFullName = "Fikk",
                            Info = "rjkngr",
                            Sum = 999,
                        }
                    };*/
        private void LoadData()
        {
            Queue<string> propertyNames = new Queue<string>();
            propertyNames.Enqueue("Type");
            propertyNames.Enqueue("Sum");
            propertyNames.Enqueue("Id");
            propertyNames.Enqueue("WaiterFullName");
            treeView.SetTreeСonfiguration(propertyNames);

            try
            {
                treeView.Clear();
                var list = billLogic.Read(null);
                foreach (var bill in list)
                {
                    treeView.AddItems(bill);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormBills_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        
        private void CreateBill(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBill>();
            form.ShowDialog();
            LoadData();
        }

        private void создатьНовыйСчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBill>();
            form.ShowDialog();
            LoadData();
        }

        private void редактироватьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBill>();
            form.Id = treeView.SelectedNodeIndex;
            form.ShowDialog();
            LoadData();
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = treeView.GetSelectedItem<BillViewModel>();
            if (selectedItem is null) return;

            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(selectedItem);
                try
                {
                    billLogic.Delete(new BillBindingModel() { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadData();
            }
        }

        /// <summary>
        /// Срабатывает при нажатии на клавишу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }

}
