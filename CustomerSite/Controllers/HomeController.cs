using AsignmentEcomerce.Shared;
using CustomerSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //
            var client = new HttpClient();
            //
            var resp = await client.GetAsync("https://localhost:44342/api/category");
            if (!resp.IsSuccessStatusCode) return null;
            var data = await resp.Content.ReadAsStringAsync();
            //
            var cate = JsonSerializer.Deserialize<List<CategoryVm>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            ViewBag.Data = cate;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }







        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            //var acessToken = await HttpContext.GetTokenAsync("access_token");
            //var requestId = await HttpContext.GetTokenAsync("id_token");

            //return View();
            var client = new HttpClient();
            //
            var resp = await client.GetAsync("https://localhost:44342/api/products");
            if (!resp.IsSuccessStatusCode) return null;
            var data = await resp.Content.ReadAsStringAsync();
            //
            var products = JsonSerializer.Deserialize<List<ProductVm>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            ViewBag.Data = products;
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     
    }
}
