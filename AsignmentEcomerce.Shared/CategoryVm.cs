using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Shared
{
    class CategoryVm
    {
        [Key]
        public int IDCategory { get; set; }
        [Required]
        public string NameCategory { get; set; }
    }
}
