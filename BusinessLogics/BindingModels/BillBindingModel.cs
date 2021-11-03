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
        /// ФИО офицанта
        /// </summary>
        public string WaiterFullName { get; set; }
        /// <summary>
        /// ID типа
        /// </summary>
        public int TypeId { get; set; }
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
