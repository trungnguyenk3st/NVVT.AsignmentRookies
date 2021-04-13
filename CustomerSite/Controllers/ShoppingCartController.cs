using CustomerSite.Extentions;
using CustomerSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        public ShoppingCartController(IProductApiClient productApiClient, IConfiguration configuration)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            var results = await _productApiClient.GetProductByArray(lstCartItems);
            return View(results);
        }


        public IActionResult AddToCart(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");


            if (lstCartItems is null)
            {
                lstCartItems = new List<int>();
                if (!lstCartItems.Contains(id))
                {
                    lstCartItems.Add(id);
                }
            }
            else
            {
                lstCartItems.Add(id);
            }
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("Index", "ShoppingCart", new { id = id });
        }
        public IActionResult BuyNow(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");


            if (lstCartItems is null)
            {
                lstCartItems = new List<int>();
                if (!lstCartItems.Contains(id))
                {
                    lstCartItems.Add(id);
                }
            }
            else
            {
                lstCartItems.Add(id);
            }
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);
            return RedirectToAction("Index", "ShoppingCart", new { id = id });
        }


        public IActionResult Remove(int id)
        {
            List<int> lstCartItems = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstCartItems.Count > 0)
            {
                if (lstCartItems.Contains(id))
                {
                    lstCartItems.Remove(id);
                }
            }
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);                                                
            return RedirectToAction("Index", "ShoppingCart", new { id = id });
        }
    }
}
