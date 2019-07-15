using System.Threading.Tasks;
using Dominos.Business.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Dominos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private readonly IProductService _productService;

        [HttpGet]
        [Route("get-pizzas")]
        public async Task<IActionResult> GetPizzas()
        {
            return HttpEntity(await _productService.GetPizzas());
        }
    }
}