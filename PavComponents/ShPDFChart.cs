using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Wpf;

namespace PavComponents
{
    public partial class ShPDFChart : Component
    {
        private BaseFont _baseFont;

        public ShPDFChart()
        {
            InitializeComponent();
        }

        public ShPDFChart(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreatePDF(string filePath, string header, string chartName, LegendLocation location, Dictionary<string, int> data)
        {
            CheckInput(filePath, header, chartName, data);

            Document doc = CreateDocument(filePath);
            doc.Open();
            _baseFont = GetBaseFont();

            var head = new Paragraph(header, new iTextSharp.text.Font(_baseFont, 16, iTextSharp.text.Font.BOLD));
            head.Alignment = Element.ALIGN_CENTER;
            head.SpacingBefore = 100;
            doc.Add(head);

            var title = new Paragraph(chartName, new iTextSharp.text.Font(_baseFont, 14, iTextSharp.text.Font.NORMAL));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingBefore = 100;
            doc.Add(title);

            PieChart pieChart = new PieChart()
            {
                DisableAnimations = true,
                Width = 250,  // Размеры диаграммы, как я понимаю
                Height = 250,
                RenderSize = new System.Windows.Size(400, 400), // Размер области, как я понял
                LegendLocation = (LiveCharts.LegendLocation)location,
                Series = new SeriesCollection()
            };

            foreach (var item in data)
            {
                pieChart.Series.Add(new PieSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<double> { item.Value },
                    DataLabels = true,
                    FontSize = 16
                });
            }

            var viewbox = GetViewBoxWithChart(pieChart);
            var img = ControlToImage(viewbox);

            iTextSharp.text.Image pdfImg = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);
            pdfImg.Alignment = Element.ALIGN_CENTER;
            pdfImg.SpacingBefore = 100;
            doc.Add(pdfImg);
            doc.Close();
        }

        private Viewbox GetViewBoxWithChart(PieChart pieChart)
        {
            Viewbox viewbox = new Viewbox();
            viewbox.Child = pieChart;

            viewbox.Measure(pieChart.RenderSize);
            viewbox.Arrange(new Rect(new System.Windows.Point(0, 0), pieChart.RenderSize));
            pieChart.Update(true, true);

            viewbox.UpdateLayout();
            return viewbox;
        }


        public static Bitmap ControlToImage(System.Windows.FrameworkElement target)
        {
            if (target == null)
                return null;

            int dpi = 96; // Не работает
            double scale = dpi / 96;

            var renderTarget = new RenderTargetBitmap((int)(target.ActualWidth * scale), (int)(target.ActualHeight * scale), dpi, dpi, PixelFormats.Pbgra32);

            var drawingVisual = new DrawingVisual();
            var rect = new Rect(0, 0, (int)target.ActualWidth, (int)target.ActualHeight);

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                var sourceBrush = new VisualBrush(target);
                drawingContext.DrawRectangle(new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255)), null, rect);
                drawingContext.DrawRectangle(sourceBrush, null, rect);
            }
            renderTarget.Render(drawingVisual);

            //convert image format
            MemoryStream stream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTarget));
            encoder.Save(stream);

            return new Bitmap(stream);
        }

        private BaseFont GetBaseFont()
        {
            string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Fradm.TTF");
            BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            return fgBaseFont;
        }

        private Document CreateDocument(string filePath)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.OpenOrCreate));
            return doc;
        }

        private static void CheckInput(string filePath, string header, string chartName, Dictionary<string, int> data)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Не указан путь к файлу");

            if (string.IsNullOrEmpty(header))
                throw new ArgumentException("Не указан заголовок документа");

            if (string.IsNullOrEmpty(chartName))
                throw new ArgumentException("Не указан заголовок диаграммы");

            if (data == null || data.Count == 0)
                throw new ArgumentException("Данные для создания диаграммы не указаны");
        }

        public void CreatePDF(string fileName, string v1, string v2, object right, object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }
}