using BusinessLogics.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.BindingModels
{
    /// <summary>
    /// Счет в кафе
    /// </summary>
    public class BillBindingModel
    {
        /// <summary>
        /// ID счета в кафе
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Тип заказа
        /// </summary>
        public OrderType Type { get; set; }
        /// <summary>
        /// ID официанта
        /// </summary>
        public int WaiterId { get; set; }
        /// <summary>
        /// Информация по счёту
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal? Sum { get; set; }


    }
}
