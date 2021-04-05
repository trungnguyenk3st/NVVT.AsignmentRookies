using AsignmentEcomerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsignmentEcomerce.Models;
using AsignmentEcomerce.Shared;

namespace AsignmentEcomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> GetCategory()
        {
            return await _context.Categorys
                .Select(x => new CategoryVm { IDCategory = x.IDCategory, NameCategory = x.NameCategory })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> GetBrand(int id)
        {
            var category = await _context.Categorys.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryVm = new CategoryVm
            {
                IDCategory = category.IDCategory,
                NameCategory = category.NameCategory
            };

            return categoryVm;
        }

        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> PutCategory(int id, CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categorys.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.NameCategory = categoryCreateRequest.NameCategory;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult<CategoryVm>> PostBrand(CategoryCreateRequest categoryCreateRequest)
        {
            var category = new Category
            {
                NameCategory = categoryCreateRequest.NameCategory
            };

            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.IDCategory }, new CategoryVm { IDCategory = category.IDCategory, NameCategory = category.NameCategory });
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Categorys.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Categorys.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
