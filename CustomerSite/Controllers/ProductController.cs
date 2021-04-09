using CustomerSite.Services;
using CustomerSite.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;


        public ProductController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _productApiClient.GetProduct(id);
            return View(result);
        }

        public async Task<IActionResult> ShowByCategory(int id)
        {
            var result = await _productApiClient.GetProductByCategory(id);
            return View(result);
        }

      
    }
}
