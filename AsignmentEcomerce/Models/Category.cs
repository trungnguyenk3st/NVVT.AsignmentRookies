using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Models
{
    public class Category
    {
        public Category()
        {
            this.Product = new HashSet<Products>();
        }
        [Key]
        public int IDCategory { get; set; }
        [Required]
        public string NameCategory { get; set; }
        public ICollection<Products> Product { get; set; }
    }
}
