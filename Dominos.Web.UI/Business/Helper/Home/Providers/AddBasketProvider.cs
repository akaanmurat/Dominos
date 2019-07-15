using Dominos.Common.Classes;
using Dominos.Common.DTO.Input;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Home;

namespace Dominos.Web.UI.Business.Helper.Home.Providers
{
    public class AddBasketProvider : BaseHomeProvider, IProvider<HomeViewModel>
    {
        public void Execute(HomeViewModel model)
        {
            var url = $"{Config.DominosApiUrl}{Config.BasketServices.AddProductToBasket}";

            var result = HttpHelper.Post<ResponseEntity<bool>, EditProductToBasketInputDTO>(
                                   new EditProductToBasketInputDTO
                                   {
                                       CustomerId = CustomerId == default(int) ? default(int?) : CustomerId,
                                       BasketKey = CustomerId == null || CustomerId == default(int) ? BasketKey : null,
                                       ProductId = model.AddedProductId
                                   },
                                   url)?.Result;

            FillProductsToModel(model);
        }
    }
}