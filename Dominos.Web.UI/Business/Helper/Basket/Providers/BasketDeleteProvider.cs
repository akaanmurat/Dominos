using Dominos.Common.Classes;
using Dominos.Common.DTO.Input;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Basket;

namespace Dominos.Web.UI.Business.Helper.Basket.Providers
{
    public class BasketDeleteProvider : BaseBasketProvider, IProvider<BasketViewModel>
    {
        public void Execute(BasketViewModel model)
        {
            var url = $"{Config.DominosApiUrl}{Config.BasketServices.DeleteProductFromBasket}";

            var result = HttpHelper.Post<ResponseEntity<bool>, EditProductToBasketInputDTO>(
                                   new EditProductToBasketInputDTO
                                   {
                                       CustomerId = CustomerId,
                                       BasketKey = CustomerId == null || CustomerId == default(int) ? BasketKey : null,
                                       ProductId = model.AddedProductId
                                   },
                                   url)?.Result;
        }
    }
}