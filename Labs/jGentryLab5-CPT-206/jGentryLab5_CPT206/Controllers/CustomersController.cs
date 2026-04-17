using Microsoft.AspNetCore.Mvc; // [Route], [ApiController]
using jGentryLab5_CPT206.Repositories; // ICustomerRespository
using Cpt206.SqlServer; // Customer

namespace jGentryLab5_CPT206.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRespository repo;

        public CustomersController(ICustomerRespository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IEnumerable<Customer>> GetCustomers(string? country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return await repo.RetrieveAllAsync();
            }
            else
            {
                return (await repo.RetrieveAllAsync())
                    .Where(customer => customer.Country == country);
            }
        }

        // GET: api/customers/[id]
        [HttpGet("{id}", Name = nameof(GetCustomer))] // named route
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            Customer? c = await repo.RetrieveAsync(id);
            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }
            return Ok(c); // 200 OK with customer in body
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            Customer? addedCustomer = await repo.CreateAsync(customer);

            if (addedCustomer == null)
            {
                return BadRequest("Repository failed to create the customer");
            }
            else
            {
                return CreatedAtRoute(
                    routeName: nameof(GetCustomer),
                    routeValues: new { id = addedCustomer.CustomerId.ToLower() },
                    value: addedCustomer);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(string id, [FromBody] Customer c)
        {
            id = id.ToUpper();
            c.CustomerId = c.CustomerId.ToUpper();

            if (c == null || c.CustomerId != id)
            {
                return BadRequest(); // 400 Bad request
            }

            Customer? existing = await repo.RetrieveAsync(id);

            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            await repo.UpdateAsync(id, c);

            return new NoContentResult(); // 204 No content
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            Customer? existing = await repo.RetrieveAsync(id);
            if (existing == null)
            {
                return NotFound(); // 404 Resource not found
            }
            bool? deleted = await repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult(); // 204 No content
            }
            else
            {
                return BadRequest(
                    $"Customer {id} was found but failed to delete.");
            }
        }
    }
}
