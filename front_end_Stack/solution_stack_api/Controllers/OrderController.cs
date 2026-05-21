using Microsoft.AspNetCore.Mvc;
using solution_stack_shared.models;

namespace solution_stack_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        private static List<Order> orders = new List<Order> { };

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<Order> Get()
        {
            return orders;
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<Order> Get(string id)
        {
            var order = orders.FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost(Name = "CreateOrder")]
        public void Post([FromBody] OrderCreateDto order)
        {
            Order newOrder = new Order
            {
                ID = Guid.NewGuid().ToString(),
                Email = order.Email,
                Name = order.Name,
                Adress = order.Adress,
                Status = OrderStatus.New
            };
            orders.Add(newOrder);
        }

        [HttpPut("{id}", Name = "UpdateOrders")]
        public void Put([FromBody] OrderUpdateDto order)
        {
            var ID = Request.RouteValues["id"]?.ToString();
            var existingOrder = orders.FirstOrDefault(o => o.ID == ID);
            if (existingOrder != null)
            {
                existingOrder.Email = order.Email;
                existingOrder.Name = order.Name;
                existingOrder.Adress = order.Adress;
                existingOrder.Status = order.Status;
            }
        }

        [HttpDelete("{id}", Name = "DeleteOrderById")]
        public void Delete(string id)
        {
            var orderToRemove = orders.FirstOrDefault(o => o.ID == id);
            if (orderToRemove != null)
            {
                orders.Remove(orderToRemove);
            }
        }
    }
}
