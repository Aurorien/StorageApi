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

        //// GET: api/Products
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        //{
        //    return await _context.Products.ToListAsync();
        //}

        // GET: api/ProductsDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProducts()
        {
            return Ok(await _context.Products.Select(p => new ProductsDto(
                 p.Id,
                 p.Name,
                 p.Price,
                 p.Category,
                 p.Shelf,
                 p.Count,
                 p.Description
                 )).ToListAsync());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDto>> GetProducts(int id)
        {
            var products = await _context.Products.Where(p => p.Id == id).Select(p => new ProductsDto
            (
                p.Id,
                p.Name,
                p.Price,
                p.Category,
                p.Shelf,
                p.Count,
                p.Description
            )).ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdatePutProductDto>> PutProduct(int id, ProductsDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
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

            return CreatedAtAction("GetProducts", products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
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

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
