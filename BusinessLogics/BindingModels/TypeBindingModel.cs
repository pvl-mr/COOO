using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.BindingModels
{
    public class TypeBindingModel
    {
        /// <summary>
        /// ID типа заказа
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Тип заказа
        /// </summary>
        public string TypeName { get; set; }
    }
}
