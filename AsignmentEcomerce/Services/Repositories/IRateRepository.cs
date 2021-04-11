using AsignmentEcomerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Services.Repositories
{
    public interface IRateRepository
    {
        Task<RatingProduct> CreateAsync(int IDProduct, string UserId, int TotalStar);

        Task<double> GetAvgStarAsync(int IDProduct);
    }
}
