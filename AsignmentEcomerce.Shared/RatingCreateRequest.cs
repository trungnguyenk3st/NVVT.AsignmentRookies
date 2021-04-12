using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;

namespace AsignmentEcomerce.Shared
{
    public class RatingCreateRequest
    {
        

        public string Comment { get; set; }
        public int IDProduct { get; set; }
        [Range(1, 5, ErrorMessage = "Please enter valid integer Number")]
        public int TotalStar { get; set; }
     
       

    }
}
