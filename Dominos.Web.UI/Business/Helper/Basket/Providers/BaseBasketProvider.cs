using Dominos.Common.Classes;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Basket;

namespace Dominos.Web.UI.Business.Helper.Basket.Providers
{
    public class BaseBasketProvider : BaseProvider
    {
        public void FillBasketList(BasketViewModel model)
        {
            var url = CustomerId == null ? $"{Config.DominosApiUrl}{Config.BasketServices.GetBasket}?basketKey={BasketKey}"
                                                    : $"{Config.DominosApiUrl}{Config.BasketServices.GetBasket}?customerId={CustomerId}";
            var basket = HttpHelper.Get<ResponseEntity<BasketOutputDTO>>(url)?.Result;

            model.BasketDetails = basket?.BasketDetails;
            model.DiscountPrice = basket?.DiscountPrice ?? default(double);
            model.TotalPrice = basket?.TotalPrice ?? default(double);
        }
    }
}