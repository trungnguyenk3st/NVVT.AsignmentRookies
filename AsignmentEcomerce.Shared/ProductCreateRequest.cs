using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Shared
{
    public class ProductCreateRequest
    {
        public int IDProduct { get; set; }
        public string NameProduct { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }

        public int IDCategory { get; set; }
    
        

    }
}
