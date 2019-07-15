using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominos.Business.ProductService
{
    public interface IProductService
    {
        Task<ResponseEntity<List<ProductOutputDTO>>> GetPizzas();
    }
}