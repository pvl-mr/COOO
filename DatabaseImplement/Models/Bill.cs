using BusinessLogics.Enums;
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
        /// ID официанта
        /// </summary>
        [Required]
        public int WaiterId { get; set; }

        /// <summary>
        /// Тип заказа
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal? Sum { get; set; }       
        /// <summary>
        /// Номер столика
        /// </summary>
        [Required]
        public int TableId { get; set; }

        /// <summary>
        /// Информация о заказе
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Офицант
        /// </summary>
        public virtual Waiter Waiter { get; set; }
    }
}
