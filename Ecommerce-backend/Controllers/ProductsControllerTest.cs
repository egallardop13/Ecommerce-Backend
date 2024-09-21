using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce_backend.Data;
using Ecommerce_backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_backend.Controllers{

 
[ApiController]
[Route("[controller]")]


public class ProductsControllerTest : ControllerBase

{

        AppDbContext _context;
    
    public ProductsControllerTest(IConfiguration config)

    {

        _context = new AppDbContext(config);

    }
 
    // GET: api/products

    [HttpGet("TestConnection")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()

    {

        return await _context.Products.ToListAsync();

    }

    [HttpGet("Test")]
    public string Test()
    {
        return "Testing on production";
    }
}}