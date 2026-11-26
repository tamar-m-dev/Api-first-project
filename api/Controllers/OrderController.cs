using entiti;
using Microsoft.AspNetCore.Mvc;
using service;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Order order = await orderService.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }
        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order createOrder = await orderService.CreateOrder(order);
            if (createOrder == null)
                return BadRequest("the order could not be created");
            return CreatedAtAction(nameof(Get), new { id = createOrder.Id }, createOrder);
        }
    }
}
