using App.Api.Data;
using App.Api.Data.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    { 
        public AppDbContext Context { get; set; }
        public SellerController(AppDbContext dbContext)
        {
            Context = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sellers = Context.Sellers.ToList();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var seller = Context.Sellers.FirstOrDefault(x => x.Id == id);

            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SellerEntity seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //seller.Id = 0;

            Context.Sellers.Add(seller);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] SellerEntity seller)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sellers = Context.Sellers.FirstOrDefault(x => x.Id == id);

            if (sellers is null)
            {
                return NotFound();
            }

            sellers.Name = seller.Name;
            sellers.Surname = seller.Surname;
            sellers.Point = seller.Point;

            Context.SaveChanges();

            return Ok(seller);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var sellers = Context.Sellers.FirstOrDefault(x => x.Id == id);

            if (sellers is null)
            {
                return NotFound();
            }

            Context.Sellers.Remove(sellers);
            Context.SaveChanges();
            return Ok();
        }
    }
}
