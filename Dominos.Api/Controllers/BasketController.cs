using System.Threading.Tasks;
using Dominos.Business.BasketService;
using Dominos.Common.DTO.Input;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        private readonly IBasketService _basketService;

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetCustomerBasket(int? customerId, string basketKey)
        {
            return HttpEntity(await _basketService.GetCustomerBasket(customerId, basketKey));
        }

        [HttpPost]
        [Route("add-product-basket")]
        public async Task<IActionResult> AddProductToBasket(EditProductToBasketInputDTO input)
        {
            return HttpEntity(await _basketService.AddProductToBasket(input));
        }

        [HttpPost]
        [Route("decrease-product-basket")]
        public async Task<IActionResult> DecreaseProductFromBasket(EditProductToBasketInputDTO input)
        {
            return HttpEntity(await _basketService.DecreaseProductFromBasket(input));
        }

        [HttpPost]
        [Route("delete-product-basket")]
        public async Task<IActionResult> DeleteProductFromBasket(EditProductToBasketInputDTO input)
        {
            return HttpEntity(await _basketService.DeleteProductFromBasket(input));
        }
    }
}