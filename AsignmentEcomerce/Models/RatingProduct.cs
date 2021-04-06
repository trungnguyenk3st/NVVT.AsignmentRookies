using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Models
{
    public class RatingProduct
    {
        [Key]
        public int IDRating { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string Comment { get; set; }

     
        [ForeignKey("Product")]
        public int IDProduct { get; set; }
     
        public Product Product { get; set; }


    }
}
