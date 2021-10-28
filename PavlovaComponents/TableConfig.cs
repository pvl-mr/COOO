using System;
using System.Collections.Generic;
using System.Text;

namespace PavlovaComponents
{
    public class TableConfig<T>
    {
        public string FilePath { get; set; }
        public string Header { get; set; }
        public int[] Colspan { get; set; }
        public int[] ColWidth { get; set; }
        public string[] FirstRowHeaders { get; set; }
        public string[] SecondRowHeaders { get; set; }
        public string[] PropertiesForDisplay { get; set; }
        public List<T> Data { get; set; }
    }
}
