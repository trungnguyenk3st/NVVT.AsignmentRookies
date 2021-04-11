using AsignmentEcomerce.Data;
using AsignmentEcomerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Services.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ApplicationDbContext _context;

        public RateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RatingProduct> CreateAsync(int IDProduct, string UserId, int TotalStar)
        {
            RatingProduct rate = new RatingProduct { IDProduct = IDProduct, ApplicationUserId = UserId, TotalStar = TotalStar };
            var result = await _context.RatingProducts.Where(r => r.ApplicationUserId == UserId && r.IDProduct == IDProduct).FirstOrDefaultAsync();
            if (result != null)
            {
                result.TotalStar = rate.TotalStar;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Add(rate);
                await _context.SaveChangesAsync();
            }
            return rate;
        }

        public Task<double> GetAvgStarAsync(int IDProduct)
        {
            return Task.FromResult(_context.RatingProducts.Where(r => r.IDProduct == IDProduct).Average(r => r.TotalStar));
        }
    }
}
