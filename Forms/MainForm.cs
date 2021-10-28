using BusinessLogics.BindingModels;
using BusinessLogics.BusinessLogic;
using BusinessLogics.Enums;
using BusinessLogics.ViewModels;
using PavComponents;
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
            propertyNames.Enqueue("WaiterFullName");
            propertyNames.Enqueue("Info");
            propertyNames.Enqueue("Sum");
            propertyNames.Enqueue("Id");
            
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

        private void создатьПростойДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] bills = new string[5];
            var myList = billLogic.Read(new BillBindingModel
            {
                Type = "Акционный счёт"
            }) ;
            for (int i = 0; i < myList.Count; i++)
            {
                bills[i] = myList[i].WaiterFullName + " : " + myList[i].Info;
            }
            /*           foreach (var book in myList)
                       {
                           
                           bills.Add(book.WaiterFullName + " : " + book.Info);
                       }*/
            using (var d = new SaveFileDialog() { Filter = "xlsx|*.xlsx" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    excelText1.CreateExcel(d.FileName,
                    "Акционные счета", bills);
                }
            }

        }

        private void создатьДоктСНастраиваемойТаблицейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var d = new SaveFileDialog() { Filter = "docx|*.docx", FileName = "Bills" })
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var bills_data = billLogic.Read(null);

                    foreach (var element in bills_data)
                    {
                        if (element.Sum.Equals("0"))
                        {
                            element.Sum = "По акции";
                        }
                    }

                    bool result = word_Custom_Table_Component1.CreateDoc(d.FileName, "Счета", new int[] { 20, 20, 20, 20 }, new List<WordTableColumn>
                    {
                        new WordTableColumn {Header = "ID", Width = 40, PropertyName = "Id"},
                    new WordTableColumn {Header = "Тип заказа", Width = 100, PropertyName = "Type"},
                    new WordTableColumn {Header = "Описание", Width = 180, PropertyName = "Info"},
                    new WordTableColumn {Header = "ФИО офицанта", Width = 100, PropertyName = "WaiterFullName"},
                    new WordTableColumn {Header = "Стоимость", Width = 80, PropertyName = "Sum"}
                    }, bills_data);
                    if (result == true)
                    {
                        MessageBox.Show("Отчёт создан", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void созданиеДоктаСДиаграммойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var listData = billLogic.Read(null);
                for (int i = 0; i < listData.Count; i++)
                {
                    if (!listData[i].Sum.Equals("0"))
                    {
                        listData.RemoveAt(i);
                        i--;
                    }
                }
            }

            var listGenres = genreLogic.Read(null);
            Dictionary<string, double> books = new Dictionary<string, double>();
            Dictionary<string, double> _books = new Dictionary<string, double>();
            foreach (var element in listGenres)
            {
                books.Add(element.GenreName, 0);
            }
            foreach (var element in listData)
            {
                if (books.ContainsKey(element.BookGenre))
                {
                    books[element.BookGenre]++;
                }
            }
            foreach (var element in books)
            {
                if (books[element.Key] != 0)
                {
                    _books.Add(element.Key, element.Value);
                }
            }
            List<double> series = new List<double>();
            List<string> xseries = new List<string>();
            foreach (var element in _books)
            {
                series.Add(element.Value);
                xseries.Add(element.Key);
            }
            chartComponent1.CreateDocument(new ChartParameters()
            {
                Path = fbd.SelectedPath + FileName + ".pdf",
                Title = "Бесплатные книги",
                ChartName = "Диаграмма книг",
                ChartLegendLocation = ChartLegendLocation.Right,
                Series = series.ToArray(),
                XSeries = xseries.ToArray()
            });
            MessageBox.Show("Отчёт создан", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

        /// <summary>
        /// Срабатывает при нажатии на клавишу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }

}
