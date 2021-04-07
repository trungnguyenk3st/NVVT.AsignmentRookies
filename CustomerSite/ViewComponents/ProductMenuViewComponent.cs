using CustomerSite.Services.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    public class ProductMenuViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;

        public ProductMenuViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await _productApiClient.GetProducts();

            return View(product);
        }
    }
}
