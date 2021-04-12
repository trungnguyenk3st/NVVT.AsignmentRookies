using AsignmentEcomerce.Shared;
using CustomerSite.Services.RatingProduct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class RatingProductViewComponent : ViewComponent
    {
        private readonly IRatingService _iratingService;

        public RatingProductViewComponent(IRatingService iratingService)
        {
            _iratingService = iratingService;
        }

        public IViewComponentResult Invoke(int IDProduct)
        {
            RatingVm ratingVm = new RatingVm();
            ratingVm.IDProduct = IDProduct;
            return View(ratingVm);
        }
    }
}
