using System.Threading.Tasks;
using Dominos.Business.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private readonly IOrderService _orderService;

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            return HttpEntity(await _orderService.GetOrderList(customerId));
        }
    }
}