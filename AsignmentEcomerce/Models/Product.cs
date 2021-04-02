using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDProduct { get; set; }
        [Required]
        public string NameProduct { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public string Image { get; set; }
        public int IDCategory { get; set; }
        [ForeignKey("IDCategory")]
        public Category Category { get; set; }
    }
}
