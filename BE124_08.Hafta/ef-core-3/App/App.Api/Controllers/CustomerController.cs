using App.Api.Data;
using App.Api.Data.Entities;
using App.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CustomerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _dbContext.Customers.Include(x => x.Orders).ToListAsync();

            // Include metodu (Dahil etme), birleştirme işi yapar

            return Ok(customers);   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var customer = await _dbContext.Customers.Include(x => x.Orders).FirstOrDefaultAsync(x => x.Id == id);

            if (customer is null)
            {
                return NotFound(); // early return
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerEntity customer)
        {
            _dbContext.Customers.Add(customer);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CustomerEntity customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(customer).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetOrders([FromRoute] int id)
        {
            var customerOrders = await _dbContext.Orders
                .Where(x => x.CustomerId == id)
                .Select(x => new CustomerOrderModel
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.Name,
                    OrderNumber = x.OrderNumber,
                    OrderDate = x.OrderDate
                }).ToListAsync();

            return Ok(customerOrders);
        }
    }
}
