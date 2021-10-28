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
    public partial class ExcelChart : Component
    {
        public ExcelChart()
        {
            InitializeComponent();
        }

        public ExcelChart(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateExcel(LineChartConfig config)
        {
            if (string.IsNullOrEmpty(config.FilePath))
                throw new ArgumentException("Файл не задан");

            if (string.IsNullOrEmpty(config.Header))
                throw new ArgumentException("Название документа не задано");

            if (string.IsNullOrEmpty(config.ChartTitle))
                throw new ArgumentException("Название диаграммы не задано");

            if (config.SeriesNames == null || config.SeriesNames.Count == 0)
                throw new ArgumentException("Названия серий не заданы");

            if (config.Values == null || config.Values.Count == 0)
                throw new ArgumentException("Значения серий не заданы");

            if (config.SeriesNames.Count != config.Values.Count)
                throw new ArgumentException("Количество названий для серий не совпадает с количеством серий");

            var xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[1];
            xlWorkSheet.Cells[1, 1] = config.Header;

            // Создаем диаграмму
            Excel.ChartObjects chartObjs = (Excel.ChartObjects)xlWorkSheet.ChartObjects();
            Excel.ChartObject chartObj = chartObjs.Add(5, 50, 300, 300);
            Excel.Chart xlChart = chartObj.Chart;
            xlChart.ChartType = Excel.XlChartType.xlLine;

            // Прописываем данные в Excel и сохраняем Range'ы
            Excel.Range[] valuesRange = new Excel.Range[config.Values.Count];
            int leftTopI = 2, leftTopJ = 1;
            for (int i = 0; i < config.Values.Count; i++)
            {
                for (int j = 0; j < config.Values[i].Count; j++)
                {
                    xlWorkSheet.Cells[leftTopI + i, leftTopJ + j] = config.Values[i][j];
                }
                valuesRange[i] = xlWorkSheet.Range
                    [xlWorkSheet.Cells[leftTopI + i, leftTopJ],
                    xlWorkSheet.Cells[leftTopI + i, leftTopJ + config.Values[i].Count - 1]];
            }
            // Задаем данные 
            Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)xlChart.SeriesCollection();
            for (int i = 0; i < config.SeriesNames.Count; i++)
            {
                Excel.Series series = seriesCollection.NewSeries();
                series.Name = config.SeriesNames[i];
                series.Values = valuesRange[i];
            }
            //Задаем заголовок
            xlChart.HasTitle = true;
            xlChart.ChartTitle.Text = config.ChartTitle;
            // Задаем легенду
            xlChart.HasLegend = true;
            switch (config.LegendPosition)
            {
                case LegendPosition.Left:
                    xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionLeft;
                    break;
                case LegendPosition.Top:
                    xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionTop;
                    break;
                case LegendPosition.Right:
                    xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                    break;
                case LegendPosition.Botton:
                    xlChart.Legend.Position = Excel.XlLegendPosition.xlLegendPositionBottom;
                    break;
            }

            xlApp.Application.ActiveWorkbook.SaveAs(config.FilePath);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Seccesed!");
        }
    }
}
