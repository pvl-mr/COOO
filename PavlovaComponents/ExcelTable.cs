using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PavlovaComponents
{
    public partial class ExcelTable : Component
    {
        private PropertyInfo[] propperyForDisplay;

        public ExcelTable()
        {
            InitializeComponent();
        }

        public ExcelTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateExcel<T>(TableConfig<T> tableConfig)
        {
            CheckInputData(tableConfig);
            DefineProperty<T>(tableConfig.PropertiesForDisplay);

            var xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
            xlWorkSheet.Cells[1, 1] = tableConfig.Header;

            int leftTopI = 2, leftTopJ = 1;
            // Прописываем первые заголовки и мержим ячейки
            int currentCellJ = leftTopJ;
            int currentHeaderI = 0;
            for (int i = 0; i < tableConfig.Colspan.Length; i++)
            {
                Excel.Range range;
                if (tableConfig.Colspan[i] > 1)
                {
                    xlWorkSheet.Cells[leftTopI, currentCellJ] = tableConfig.FirstRowHeaders[currentHeaderI];
                    range = xlWorkSheet.Range[xlWorkSheet.Cells[leftTopI, currentCellJ], xlWorkSheet.Cells[leftTopI, currentCellJ + tableConfig.Colspan[i] - 1]];
                    currentHeaderI++;
                }
                else
                {
                    xlWorkSheet.Cells[leftTopI, currentCellJ] = tableConfig.SecondRowHeaders[currentCellJ - leftTopJ]; // Костыль
                    range = xlWorkSheet.Range[xlWorkSheet.Cells[leftTopI, currentCellJ], xlWorkSheet.Cells[leftTopI + 1, currentCellJ]];
                }
                range.Merge();
                range.HorizontalAlignment = HorizontalAlignment.Center;
                currentCellJ += tableConfig.Colspan[i];
            }
            for (int i = 0; i < tableConfig.SecondRowHeaders.Length; i++)
            {
                xlWorkSheet.Cells[leftTopI + 1, leftTopJ + i] = tableConfig.SecondRowHeaders[i];
            }
            // Прописываем 2е заголовки
            for (int i = 0; i < tableConfig.Data.Count; i++)
            {
                var data = tableConfig.Data[i];
                for (int j = 0; j < propperyForDisplay.Length; j++)
                {
                    xlWorkSheet.Cells[leftTopI + 2 + i, leftTopJ + j] = propperyForDisplay[j].GetValue(data);
                }
            }
            // Задаем ширину колонок
            for (int i = 0; i < tableConfig.ColWidth.Length; i++)
            {
                Excel.Range range = xlWorkSheet.Range[xlWorkSheet.Cells[leftTopI, leftTopJ + i], xlWorkSheet.Cells[leftTopI + 1, leftTopJ + i]];
                range.ColumnWidth = tableConfig.ColWidth[i];
            }
            // Устанавливаем границы
            Excel.Range allTableRange = xlWorkSheet.Range[xlWorkSheet.Cells[leftTopI, leftTopJ], xlWorkSheet.Cells[leftTopI + 1 + tableConfig.Data.Count, leftTopJ + tableConfig.SecondRowHeaders.Length - 1]]; ;
            SetAllBorders(allTableRange.Borders);

            xlApp.Application.ActiveWorkbook.SaveAs(tableConfig.FilePath);
            xlWorkBook.Close(true);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            MessageBox.Show("Saccesed!");
        }

        private void SetAllBorders(Excel.Borders borders)
        {
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
        }


        private void DefineProperty<T>(string[] propertyForDisplay)
        {
            propperyForDisplay = new PropertyInfo[propertyForDisplay.Length];
            var typeT = typeof(T);
            for (int i = 0; i < propertyForDisplay.Length; i++)
            {
                var propertyName = typeT.GetProperty(propertyForDisplay[i]);
                if (propertyName == null)
                    throw new ArgumentException($"Указанного в массиве propertyForDisplay свойства {propertyForDisplay[i]} нет в классе {typeT.Name}");
                propperyForDisplay[i] = propertyName;
            }
        }

        private void CheckInputData<T>(TableConfig<T> tableConfig)
        {
            if (string.IsNullOrEmpty(tableConfig.FilePath))
                throw new ArgumentException("Не указан путь к файлу");

            if (string.IsNullOrEmpty(tableConfig.Header))
                throw new ArgumentException("Не указан заголовок документа");

            if (tableConfig.Colspan == null || tableConfig.Colspan.Length == 0)
                throw new ArgumentException("Массив colspan пуст либо null");

            if (tableConfig.ColWidth == null || tableConfig.ColWidth.Length == 0)
                throw new ArgumentException("Массив colheights пуст либо null");

            if (tableConfig.FirstRowHeaders == null || tableConfig.FirstRowHeaders.Length == 0)
                throw new ArgumentException("Массив firstRowHeaders пуст либо null");

            if (tableConfig.SecondRowHeaders == null || tableConfig.SecondRowHeaders.Length == 0)
                throw new ArgumentException("Массив SecondColHeaders пуст либо null");

            if (tableConfig.PropertiesForDisplay == null || tableConfig.PropertiesForDisplay.Length == 0)
                throw new ArgumentException("Массив propertiesOrder пуст либо null");

            if (tableConfig.Data == null || tableConfig.Data.Count == 0)
                throw new ArgumentException("Список data пуст либо null");

            if (tableConfig.Colspan.Sum() != tableConfig.SecondRowHeaders.Length)
                throw new ArgumentException($"Невозможно построить таблицу, т.к. количество столбцов 1го заголовка ({tableConfig.Colspan.Sum()}) не совпадает с количеством столбцов 2го заголовка ({tableConfig.SecondRowHeaders.Length})");

            if (tableConfig.SecondRowHeaders.Length != tableConfig.PropertiesForDisplay.Length)
                throw new ArgumentException($"Невозможно построить таблицу, т.к. количество заголовков 2 строки ({tableConfig.SecondRowHeaders.Length}) не совпадает с количеством полей у данных ({tableConfig.PropertiesForDisplay.Length})");

        }
    }
}
