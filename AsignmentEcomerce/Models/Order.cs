using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Models
{
    public class Order
    {
        [Key]
        public int IDorder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]

        [ForeignKey("ApplicationUsers")]
        public string ApplicationUserId { get; set; }
        public virtual User ApplicationUser { get; set; }







        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
