using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Type
    {
        /// <summary>
        /// ID типа заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название типа заказа
        /// </summary>
        [Required]
        public string TypeName { get; set; }

        /// <summary>
        /// В каких счетах присутствует этот тип
        /// </summary>
        [ForeignKey("TypeId")]
        public virtual List<Bill> Bill { get; set; }
    }
}
