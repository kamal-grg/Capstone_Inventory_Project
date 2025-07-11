using Microsoft.AspNetCore.Mvc;

using CustomerApp.API.Shared.Models;
using Microsoft.EntityFrameworkCore;
using CustomerApp.API.Data;
using CustomerApp.Shared.Models;
using AutoMapper;

namespace CustomerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(AppDbContext context, IMapper mapper, ILogger<CustomerController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            _logger.LogInformation("Getting list of customers");
            var customers = await _context.Customers.ToListAsync();
            var dto = _mapper.Map<List<CustomerDto>>(customers);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = _mapper.Map<Customer>(dto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            dto.Id = customer.Id;
            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto dto)
        {
            if (id != dto.Id)
            {
                _logger.LogWarning("Update failed: ID mismatch (URL={UrlId}, Body={BodyId})", id, dto.Id);

                return BadRequest("Mismatched customer ID.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    _logger.LogError("Customer not found with ID: {CustomerId}", id);
                    return NotFound();
                }

                _mapper.Map(dto, customer);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Customer updated successfully: {CustomerId}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error occurred while updating customer: {CustomerId}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
