using System;
using System.Collections.Generic;
using System.Text;

namespace PavlovaComponents
{
    public class LineChartConfig
    {
        public string FilePath { get; set; }
        public string Header { get; set; }
        public string ChartTitle { get; set; }

        public List<List<int>> Values { get; set; }
        public List<string> SeriesNames { get; set; }

        public LegendPosition LegendPosition { get; set; }
    }
}
