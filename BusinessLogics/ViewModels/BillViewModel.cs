using BusinessLogics.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessLogics.ViewModels
{
    public class BillViewModel
    {
        /// <summary>
        /// ID счета в кафе
        /// </summary>
        /// [DisplayName("Номер счета")]
        public int? Id { get; set; }
        /// <summary>
        /// Тип заказа
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// ID официанта
        /// </summary>
        public int WaiterId { get; set; }
        [DisplayName("ФИО официанта")]
        public string WaiterFullName { get; set; }
        /// <summary>
        /// Информация по счёту
        /// </summary>
        [DisplayName("Информация по счёту")]
        public string Info { get; set; }
        /// <summary>
        /// Сумма заказа
        /// </summary>
        [DisplayName("Сумма заказа")]
        public decimal? Sum { get; set; }
    }
}
