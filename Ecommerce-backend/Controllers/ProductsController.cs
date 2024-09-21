using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce_backend.Data;
using Ecommerce_backend.Models;
namespace Ecommerce_backend.Controllers{

 
[ApiController]
[Route("/[controller]")]


public class ProductsController : ControllerBase

{

    private AppDbContext _context;
 
    public ProductsController(AppDbContext context)

    {

        _context = context;

    }
 
    // GET: api/products

    [HttpGet]

    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()

    {

        return await _context.Products.ToListAsync();

    }
 
    // GET: api/products/{id}

    [HttpGet("{id}")]

    public async Task<ActionResult<Product>> GetProduct(int id)

    {

        var product = await _context.Products.FindAsync(id);

        if (product == null)

        {

            return NotFound();

        }

        return product;

    }
 [HttpPost("batch")]
public async Task<ActionResult<IEnumerable<Product>>> CreateProducts(List<Product> products)
{
    _context.Products.AddRange(products);
    await _context.SaveChangesAsync();
    return Ok(products);
}
    // POST: api/products

    [HttpPost]
    

    public async Task<ActionResult<Product>> CreateProduct(Product product)

    {

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

    }
 
    // PUT: api/products/{id}

    [HttpPut("{id}")]
public async Task<IActionResult> UpdateProduct(int id, Product product)
{
    if (id != product.Id)
    {
        return BadRequest("Product ID mismatch.");
    }
 
    _context.Entry(product).State = EntityState.Modified;
 
    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!_context.Products.Any(e => e.Id == id))
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


    // DELETE: api/products/{id}

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteProduct(int id)

    {

        var product = await _context.Products.FindAsync(id);

        if (product == null)

        {

            return NotFound();

        }
 
        _context.Products.Remove(product);

        await _context.SaveChangesAsync();
 
        return NoContent();

    }

}

}