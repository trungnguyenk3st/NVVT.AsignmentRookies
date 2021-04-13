using CustomerSite.Extentions;
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
        public async Task<IActionResult> ProductList()
        {
            var result = await _productApiClient.GetProducts();
            return View(result);
        }
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {
                lstShoppingCart = new List<int>();
            }
            int flag = 0;
            foreach (int item in lstShoppingCart)
            {
                if (item == id)
                    flag++;
            }
            if (flag == 0)
                lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Details", "Product", new { id = id });
        }

        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart.Count > 0)
            {
                if (lstShoppingCart.Contains(id))
                {
                    lstShoppingCart.Remove(id);
                }
            }
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Details", "Product", new { id = id });
        }



    }
}
