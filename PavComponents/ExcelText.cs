using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PavComponents
{
    public partial class ExcelText : Component
    {
        public ExcelText()
        {
            InitializeComponent();
        }

        public ExcelText(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateExcel(string fileName, string title, string[] text)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Не указан путь к файлу");

            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Не указан заголовок документа");

            if (text == null || text.Length == 0)
                throw new ArgumentException("Массив с текстом пуст либо null");

            var xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1];
            xlWorkSheet.Cells[1, 1] = title;

            for (int i = 0; i < text.Length; i++)
            {
                xlWorkSheet.Cells[i + 3, 1] = text[i];
            }

            xlApp.Application.ActiveWorkbook.SaveAs(fileName);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlApp);

            
            MessageBox.Show("Saccesed!");

        }
    }
}
