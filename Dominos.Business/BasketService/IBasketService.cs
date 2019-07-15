using Dominos.Common.Classes;
using Dominos.Common.DTO.Input;
using Dominos.Common.DTO.Output;
using System.Threading.Tasks;

namespace Dominos.Business.BasketService
{
    public interface IBasketService
    {
        Task<ResponseEntity<BasketOutputDTO>> GetCustomerBasket(int? customerId, string basketKey);
        Task<ResponseEntity<bool>> AddProductToBasket(EditProductToBasketInputDTO input);
        Task<ResponseEntity<bool>> DecreaseProductFromBasket(EditProductToBasketInputDTO input);
        Task<ResponseEntity<bool>> DeleteProductFromBasket(EditProductToBasketInputDTO input);
    }
}