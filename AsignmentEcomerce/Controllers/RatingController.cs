using AsignmentEcomerce.Data;
using AsignmentEcomerce.Models;
using AsignmentEcomerce.Services;
using AsignmentEcomerce.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsignmentEcomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        public RatingController(ApplicationDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        [HttpGet("user/{UserId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId)
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                IDRating = x.IDRating,
                TotalStar = x.TotalStar,
                Comment = x.Comment,
                Date = x.Date,
                UserId = x.ApplicationUserId,
                IDProduct = x.IDProduct
            }).Where(x => x.UserId == UserId).ToListAsync();
            return ratings;
        }

        [HttpGet("product/{ProductId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatingByProductId(int ProductId)
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                IDRating = x.IDRating,
                TotalStar = x.TotalStar,
                Comment = x.Comment,
                Date = x.Date,
                UserId = x.ApplicationUserId,
                IDProduct = x.IDProduct
            }).Where(x => x.IDProduct == ProductId).ToListAsync();
            return ratings;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RatingVm>> GetRatings()
        {
            var ratings = await _context.RatingProducts.Select(x => new RatingVm
            {
                IDRating = x.IDRating,
                TotalStar = x.TotalStar,
                Comment = x.Comment,
                Date = x.Date,
                UserId = x.ApplicationUserId,
                IDProduct = x.IDProduct
            }).ToListAsync();
            return ratings;
        }

        [HttpPost]
        public async Task<RatingVm> PostRating(RatingCreateRequest request)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.FindFirst("sub").Value;
            var rating = new RatingProduct
            {
                TotalStar = request.TotalStar,
                Comment = request.Comment,
                Date = DateTime.Now,
                ApplicationUserId = userId,
                IDProduct = request.IDProduct
            };

            _context.RatingProducts.Add(rating);
            await _context.SaveChangesAsync();

            var ratingVm = new RatingVm()
            {
                IDRating = rating.IDRating,
                TotalStar = rating.TotalStar,
                Comment = rating.Comment,
                Date = rating.Date,
                UserId = rating.ApplicationUserId,
                IDProduct = rating.IDProduct
            };

            return ratingVm;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<int> DeleteRating(int RatingId)
        {
            var rating = await _context.RatingProducts.FindAsync(RatingId);
            if (rating == null)
            {
                throw new Exception("Cannot find id");
            }
            _context.RatingProducts.Remove(rating);
            return await _context.SaveChangesAsync();
        }
    }
}
