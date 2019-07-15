using Dominos.Common.Configuration;
using Dominos.Web.UI.Business.Helper.Home.Providers;
using Dominos.Web.UI.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dominos.Web.UI.Business.Helper.Home
{
    public class HomeInstance
    {
        public HomeInstance(Controller controller,
                             ModelStateDictionary modelState,
                             HomeSubmits submit,
                             DominosConfig config = null,
                             SessionHelper session = null,
                             CookieHelper cookie = null)
        {
            switch (submit)
            {
                case HomeSubmits.List:
                    Provider = new HomeListProvider();
                    break;
                case HomeSubmits.AddBasket:
                    Provider = new AddBasketProvider();
                    break;
            }

            (Provider as BaseProvider).Controller = controller;
            (Provider as BaseProvider).ModelState = modelState;
            (Provider as BaseProvider).Config = config;
            (Provider as BaseProvider).Session = session;
            (Provider as BaseProvider).Cookie = cookie;
        }

        public IProvider<HomeViewModel> Provider { get; set; }
    }
}