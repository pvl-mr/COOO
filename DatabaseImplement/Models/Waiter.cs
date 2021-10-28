using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Waiter
    {
        /// <summary>
        /// ID счета
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО официаета
        /// </summary>
        [Required]
        public string WaiterFullName { get; set; }

        /// <summary>
        /// В каких счетах присутствует этот официант
        /// </summary>
        [ForeignKey("WaiterId")]
        public virtual List<Bill> Bill { get; set; }
    }
}
