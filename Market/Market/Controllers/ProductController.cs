using Market.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        MarketContext context;

        public ProductController(MarketContext _context)
        {
            context = _context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.Product.ToListAsync();
            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is invalid.");
            }

            context.Product.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await context.Product.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductName = updatedProduct.ProductName;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;

            await context.SaveChangesAsync();

            return Ok("Product updated successfully.");
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            context.Product.Remove(product);
            await context.SaveChangesAsync();

            return Ok("Product deleted successfully.");
        }





    }
}
