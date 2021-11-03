using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models
{
    /// <summary>
    /// Счет в кафе
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// ID счета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        /// <summary>
        /// ФИО офицанта
        /// </summary>
        [Required]
        public string WaiterFullName { get; set; }

        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal Sum { get; set; }       
        /// <summary>
        /// Информация о заказе
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Тип заказа
        /// </summary>
        public virtual Type Type { get; set; }
    }
}
