using App.Api.Data;
using App.Api.Data.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public AppDbContext Context { get; set; }

        public ProductController(AppDbContext dbContext)
        {
            //Context = new AppDbContext();
            //Context.Database.EnsureCreated();

            Context = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = Context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Context.Products.Add(product);
            Context.SaveChanges();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductEntity product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbProduct = Context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (dbProduct is null)
            {
                return NotFound();
            }
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Stock = product.Stock;

            Context.SaveChanges();
            return Ok(dbProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var dbProduct = Context.Products.FirstOrDefault(y => y.Id == id);
            if (dbProduct is null)
            {
                return NotFound();
            }
            Context.Products.Remove(dbProduct);
            return Ok();
        }


    }
}
