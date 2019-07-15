using Dominos.Common.Configuration;
using Dominos.Web.UI.Business.Helper.Login.Providers;
using Dominos.Web.UI.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dominos.Web.UI.Business.Helper.Login
{
    public class LoginInstance
    {
        public LoginInstance(Controller controller,
                             ModelStateDictionary modelState,
                             LoginSubmits submit,
                             DominosConfig config = null,
                             SessionHelper session = null,
                             CookieHelper cookie = null)
        {
            switch (submit)
            {
                case LoginSubmits.Login:
                    Provider = new LoginProvider();
                    break;
            }

            (Provider as BaseProvider).Controller = controller;
            (Provider as BaseProvider).ModelState = modelState;
            (Provider as BaseProvider).Config = config;
            (Provider as BaseProvider).Session = session;
            (Provider as BaseProvider).Cookie = cookie;
        }

        public IProvider<LoginViewModel> Provider { get; set; }
    }
}