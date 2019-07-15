using Dominos.Common.Classes;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Input;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Login;

namespace Dominos.Web.UI.Business.Helper.Login.Providers
{
    public class LoginProvider : BaseLoginProvider, IProvider<LoginViewModel>
    {
        public void Execute(LoginViewModel model)
        {
            var url = $"{Config.DominosApiUrl}{Config.CustomerServices.Login}";

            var result = HttpHelper.Post<ResponseEntity<CustomerOutputDTO>, LoginInputDTO>(
                                   new LoginInputDTO
                                   {
                                       Email = model.Email,
                                       Password = model.Password
                                   },
                                   url)?.Result;

            if (result != null)
            {
                Session.Set(SessionKey.Customer, result);
                Cookie.Remove();
                Cookie.Set(CookieKey.CustomerId, result.CustomerId);
                Controller.RedirectToAction("Index", "Home");
                return;
            }

            ModelState.AddModelError("Email", "Kullanıcı bulanamadı!");
        }
    }
}