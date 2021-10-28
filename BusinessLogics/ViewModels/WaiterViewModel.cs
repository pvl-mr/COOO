using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogics.ViewModels
{
    public class WaiterViewModel
    {
        /// <summary>
        /// ID официанта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО официанта
        /// </summary>
        [DisplayName("ФИО официанта")]
        public string WaiterFullName { get; set; }
    }
}
