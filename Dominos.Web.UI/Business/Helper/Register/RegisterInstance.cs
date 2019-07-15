using Dominos.Common.Configuration;
using Dominos.Web.UI.Business.Helper.Register.Providers;
using Dominos.Web.UI.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dominos.Web.UI.Business.Helper.Register
{
    public class RegisterInstance
    {
        public RegisterInstance(Controller controller,
                             ModelStateDictionary modelState,
                             RegisterSubmits submit,
                             DominosConfig config = null,
                             SessionHelper session = null,
                             CookieHelper cookie = null)
        {
            switch (submit)
            {
                case RegisterSubmits.Register:
                    Provider = new RegisterProvider();
                    break;
            }

            (Provider as BaseProvider).Controller = controller;
            (Provider as BaseProvider).ModelState = modelState;
            (Provider as BaseProvider).Config = config;
            (Provider as BaseProvider).Session = session;
            (Provider as BaseProvider).Cookie = cookie;
        }

        public IProvider<RegisterViewModel> Provider { get; set; }
    }
}