using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTOs;
using StorageApi.Models;

namespace StorageApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly StorageContext _context;

        public ProductController(StorageContext context)
        {
            _context = context;
        }

        // GET: api/products/stats
        [HttpGet("stats")]
        public async Task<ActionResult<ProductStatsDto>> GetProductsStats()
        {
            var products = await _context.Products.ToListAsync();

            if (!products.Any())
            {
                return Ok(new ProductStatsDto(0, 0, 0m));
            }

            var totaltAmountOfProducts = products.Count;
            var totaltStorageValue = products.Sum(p => p.Price * p.Count);
            var averagePrice = (decimal)products.Average(p => p.Price);

            var stats = new ProductStatsDto(
                totaltAmountOfProducts,
                totaltStorageValue,
                averagePrice
            );

            return Ok(stats);
        }

        // GET: api/products?category=&name=
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProducts(string? category, string? name)
        {

            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category.ToLower() == category.Trim().ToLower());
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.ToLower() == name.Trim().ToLower());
            }


            return Ok(await query
                .Select(p => new ProductsDto(
                 p.Id,
                 p.Name,
                 p.Price,
                 p.Category,
                 p.Shelf,
                 p.Count,
                 p.Description
                 ))
                .FirstOrDefaultAsync());
        }


        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProduct(int id)
        {
            var products = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductsDto(
                 p.Id,
                 p.Name,
                 p.Price,
                 p.Category,
                 p.Shelf,
                 p.Count,
                 p.Description
                 ))
                .FirstOrDefaultAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }


        // PUT: api/products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePutProductDto>> PutProduct(int id, UpdatePutProductDto product)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }

            var existingProduct = await _context.Products
                .Include(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Shelf = product.Shelf;
            existingProduct.Count = product.Count;
            existingProduct.Description = product.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict(new
                    {
                        Message = "Product was updated by another user",
                        Error = ex.Message
                    });
                }
            }

            return NoContent();
        }


        // POST: api/products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateProductDto>> PostProduct(CreateProductDto createProduct)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = new Products
            {
                Name = createProduct.Name,
                Price = createProduct.Price,
                Category = createProduct.Category,
                Shelf = createProduct.Shelf,
                Count = createProduct.Count,
                Description = createProduct.Description
            };

            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), products);
        }


        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
