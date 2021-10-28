using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.BindingModels
{
    public class WaiterBindingModel
    {
        /// <summary>
        /// ID официанта
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// ФИО официанта
        /// </summary>
        public string WaiterFullName { get; set; }
    }
}
