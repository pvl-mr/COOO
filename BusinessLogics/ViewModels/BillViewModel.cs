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
        [DisplayName("Номер счета")]
        public int Id { get; set; }
        /// <summary>
        /// Тип заказа
        /// </summary>
        [DisplayName("ФИО офицанта")]
        public string WaiterFullName { get; set; }
        /// <summary>
        /// ID официанта
        /// </summary>
        public int TypeId { get; set; }
        [DisplayName("Тип заказа")]
        public string TypeName { get; set; }
        /// <summary>
        /// Информация по счёту
        /// </summary>
        [DisplayName("Информация по счёту")]
        public string Info { get; set; }
        /// <summary>
        /// Сумма заказа
        /// </summary>
        [DisplayName("Сумма заказа")]
        public string Sum { get; set; }
    }
}
