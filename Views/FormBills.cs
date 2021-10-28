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

namespace Views
{
    public partial class FormBills : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly BillLogic billLogic;

        public FormBills(BillLogic billLogic)
        {
            InitializeComponent();
            this.billLogic = billLogic;
            Queue<string> propertyNames = new Queue<string>();
            propertyNames.Enqueue("Type");
            propertyNames.Enqueue("Sum");
            propertyNames.Enqueue("Id");
            propertyNames.Enqueue("WaiterFullName");
            treeView.SetTreeСonfiguration(propertyNames);
            treeView.AddItems(new BillViewModel()
                {
                Id = 0,
                    Type = OrderType.takeaway_food,
                    WaiterFullName = "Fikk",
                    Info = "rjkngr",
                    Sum = 999,
                });
            treeView.AddItems(new BillViewModel()
            {
                Id = 1,
                Type = OrderType.main_dish,
                WaiterFullName = "Fikk",
                Info = "rjkngr",
                Sum = 999,
            });
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

/*            List<BillViewModel> list_of_bills = billLogic.Read(null);                 

             foreach (var bill in list)
            {
                treeView.AddItems(bill);
            }*/

        }

        private void FormBills_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        {
                            CreateBill(null, null);
                            break;
                        }
                   /* case Keys.U:
                        {
                            UpdateBook(null, null);
                            break;
                        }
                    case Keys.D:
                        {
                            DeleteBook(null, null);
                            break;
                        }
                    case Keys.S:
                        {
                            CreateSimpleDocument(null, null);
                            break;
                        }
                    case Keys.T:
                        {
                            CreateDocumentTable(null, null);
                            break;
                        }
                    case Keys.C:
                        {
                            CreateDocumentChart(null, null);
                            break;
                        }*/
                }
            }
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

        /// <summary>
        /// Срабатывает при нажатии на клавишу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }

}
