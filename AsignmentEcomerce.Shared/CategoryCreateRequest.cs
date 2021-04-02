using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Shared
{
    public class CategoryCreateRequest
    {
        [Required]
        public string NameCategory { get; set; }
    }
}
