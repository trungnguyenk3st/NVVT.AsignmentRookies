using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsignmentEcomerce.Data;
using AsignmentEcomerce.Models;

namespace AsignmentEcomerce.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> List()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return Ok(await applicationDbContext.ToListAsync());
        }

        // GET: Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.IDProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: Products/Createwant to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Now;
                product.CreateDate = date;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(product);
        }

       

        // POST: Products/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Product product)
        {
            if (id != product.IDProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var date = DateTime.Now;
                    product.UpdateDate = date;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.IDProduct))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(product);
        }


        // POST: Products/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.IDProduct == id);
        }
    }
}
