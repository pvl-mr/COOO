using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogics.ViewModels
{
    public class TypeViewModel
    {
        /// <summary>
        /// ID типа заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название типа заказа
        /// </summary>
        [DisplayName("Тип заказа")]
        public string TypeName { get; set; }
    }
}
