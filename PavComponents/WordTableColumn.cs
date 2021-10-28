using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavComponents
{
    /// <summary>
    /// Класс колонки таблицы
    /// </summary>
    public class WordTableColumn
    {
        /// <summary>
        /// Заголовок колонки
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Ширина колонки
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Название свойства объекта для колонки
        /// </summary>
        public string PropertyName { get; set; }
    }
}
