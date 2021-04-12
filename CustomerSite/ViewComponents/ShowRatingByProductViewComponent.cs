using CustomerSite.Services.RatingProduct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class ShowRatingByProductViewComponent : ViewComponent
    {
        private readonly IRatingService _iratingService;

        public ShowRatingByProductViewComponent(IRatingService iratingService)
        {
            _iratingService = iratingService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var ratingVm = await _iratingService.GetRatingByProductId(id);

            return View(ratingVm);
        }
    }
}
