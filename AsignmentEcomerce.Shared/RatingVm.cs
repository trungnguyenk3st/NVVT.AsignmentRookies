using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Shared
{
    public class RatingVm
    {
        public int IDRating { get; set; }
        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public int TotalStar { get; set; }
        public int IDProduct { get; set; }

        public string UserId { get; set; }
      
    }
}
