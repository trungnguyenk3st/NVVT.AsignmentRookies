using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsignmentEcomerce.Data;
using AsignmentEcomerce.Models;
using AsignmentEcomerce.Shared;
using Microsoft.AspNetCore.Authorization;
using AsignmentEcomerce.Services;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Security.Claims;
using AsignmentEcomerce.Services.Repositories;

namespace AsignmentEcomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private readonly ILogger _logger;
        private readonly IRateRepository _rateRepository;
        private static readonly ActivitySource DemoSource = new ActivitySource("OTel.Demo");

        public ProductsController(ApplicationDbContext context, IStorageService storageService, ILogger<ProductsController> logger, IRateRepository rateRepository)
        {
            _context = context;
            _storageService = storageService;
            _logger = logger;
            _rateRepository = rateRepository;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                IDProduct = product.IDProduct,
                NameProduct = product.NameProduct,
                Description = product.Description,
                UnitPrice = product.UnitPrice
            };

            productVm.ImageUrl = _storageService.GetFileUrl(product.Image);
            _logger.LogInformation("get product");

            return productVm;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProducts()
        {
            var products = await _context.Products.Select(x =>
                new
                {
                    x.IDProduct,
                    x.NameProduct,
                    x.UnitPrice,
                    x.Description,
                    x.Image
                }).ToListAsync();

            var productVms = products.Select(x =>
                new ProductVm
                {
                    IDProduct = x.IDProduct,
                    NameProduct = x.NameProduct,
                    UnitPrice = x.UnitPrice,
                    Description = x.Description,
                    ImageUrl = _storageService.GetFileUrl(x.Image)
                }).ToList();

            _logger.LogInformation("get products");
            using (var activity = DemoSource.StartActivity("This is sample activity"))
            {
                _logger.LogInformation("Hello, World!");
            }

            return productVms;
        }

        [HttpGet("category/{CategoryId}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProductByCategory(int CategoryId)
        {
            return await _context.Products.Include(p => p.Category).Where(p => p.IDCategory == CategoryId)
                .Select(x => new ProductVm
                {
                    IDProduct = x.IDProduct,
                    NameProduct = x.NameProduct,
                    ImageUrl = x.Image,
                    Description = x.Description,

                    NameCategory = x.Category.NameCategory,
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                NameProduct = productCreateRequest.NameProduct,
                Description = productCreateRequest.Description,
                UnitPrice = productCreateRequest.UnitPrice,
                IDCategory = productCreateRequest.IDCategory
            };

            if (productCreateRequest.ImageUrl != null)
            {
                product.Image = await SaveFile(productCreateRequest.ImageUrl);
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.IDProduct }, null);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
