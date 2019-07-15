using Dominos.Common.Configuration;
using Dominos.Web.UI.Business.Helper.Home.Providers;
using Dominos.Web.UI.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dominos.Web.UI.Business.Helper.Home
{
    public class HomeInstance
    {
        public HomeInstance(Controller controller, ModelStateDictionary modelState, HomeSubmits submit, DominosConfig config = null)
        {
            switch (submit)
            {
                case HomeSubmits.List:
                    Provider = new HomeProvider();
                    break;
            }

            (Provider as BaseProvider).Controller = controller;
            (Provider as BaseProvider).ModelState = modelState;
            (Provider as BaseProvider).Config = config;
        }

        public IProvider<HomeViewModel> Provider { get; set; }
    }
}