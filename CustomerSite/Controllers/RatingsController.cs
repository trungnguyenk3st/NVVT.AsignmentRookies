using AsignmentEcomerce.Shared;
using CustomerSite.Services.RatingProduct;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ILogger<RatingsController> _logger;
        private readonly IRatingService _ratingClient;
        public RatingsController(ILogger<RatingsController> logger, IRatingService ratingClient)
        {
            _logger = logger;
            _ratingClient = ratingClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(RatingCreateRequest rating)
        {
            string userToken = await HttpContext.GetTokenAsync("access_token");
            await _ratingClient.PostRating(userToken, rating);
            return RedirectToAction("Details", "Product", new { id = rating.IDProduct });
        }
        public async Task<IActionResult> ShowRatingByProduct(int id)
        {
            var result = await _ratingClient.GetRatingByProductId(id);
            return View(result);
        }
    }
}
