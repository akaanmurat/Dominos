using System.Threading.Tasks;
using Dominos.Business.CustomerService;
using Dominos.Common.DTO.Input;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        private readonly ICustomerService _customerService;

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCustomer(int customerId)
        {
            return HttpEntity(await _customerService.GetCustomerById(customerId));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInputDTO input)
        {
            return HttpEntity(await _customerService.Login(input));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterInputDTO input)
        {
            return HttpEntity(await _customerService.Register(input));
        }
    }
}