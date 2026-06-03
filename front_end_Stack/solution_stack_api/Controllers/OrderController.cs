using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solution_stack_api.Data;
using solution_stack_shared.models;

namespace solution_stack_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly AppDbContext _context;

        public OrderController(ILogger<OrderController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _context.Orders.ToListAsync();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> Post([FromBody] OrderCreateDto order)
        {
            var newOrder = new Order
            {
                ID = Guid.NewGuid().ToString(),
                Email = order.Email,
                Name = order.Name,
                Address = order.Address,
                Status = OrderStatus.New
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("GetOrderById", new { id = newOrder.ID }, newOrder);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}", Name = "UpdateOrders")]
        public async Task<IActionResult> Put(string id, [FromBody] OrderUpdateDto order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Email = order.Email;
            existingOrder.Name = order.Name;
            existingOrder.Address = order.Address;
            existingOrder.Status = order.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}", Name = "DeleteOrderById")]
        public async Task<IActionResult> Delete(string id)
        {
            var orderToRemove = await _context.Orders.FindAsync(id);
            if (orderToRemove == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderToRemove);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
