using Dominos.Common.Configuration;
using Dominos.Web.UI.Business.Helper.Basket.Providers;
using Dominos.Web.UI.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dominos.Web.UI.Business.Helper.Basket
{
    public class BasketInstance
    {
        public BasketInstance(Controller controller,
                              ModelStateDictionary modelState,
                              BasketSubmits submit,
                              DominosConfig config = null,
                              SessionHelper session = null,
                              CookieHelper cookie = null)
        {
            switch (submit)
            {
                case BasketSubmits.List:
                    Provider = new BasketProvider();
                    break;
                case BasketSubmits.Delete:
                    break;
                case BasketSubmits.Increase:
                    break;
                case BasketSubmits.Decrease:
                    break;
            }

            (Provider as BaseProvider).Controller = controller;
            (Provider as BaseProvider).ModelState = modelState;
            (Provider as BaseProvider).Config = config;
            (Provider as BaseProvider).Session = session;
            (Provider as BaseProvider).Cookie = cookie;
        }

        public IProvider<BasketViewModel> Provider { get; set; }
    }
}