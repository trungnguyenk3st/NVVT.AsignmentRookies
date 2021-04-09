using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Shared
{
     public class ProductVm
    {
        public int IDProduct { get; set; }
        public string NameProduct { get; set; }
  
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string NameCategory { get; set; }
    }
}
