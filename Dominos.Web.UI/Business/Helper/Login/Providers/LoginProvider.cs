using Dominos.Common.Classes;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Input;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Login;
using System;

namespace Dominos.Web.UI.Business.Helper.Login.Providers
{
    public class LoginProvider : BaseLoginProvider, IProvider<LoginViewModel>
    {
        public void Execute(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var url = $"{Config.DominosApiUrl}{Config.CustomerServices.Login}";

            try
            {
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
                    Cookie.Set(CookieKey.CustomerId, result.CustomerId.ToString());
                    return;
                }

                ModelState.AddModelError("Validation", "Kullanıcı bulanamadı!");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Validation", "Kullanıcı bulanamadı!");
            }
        }
    }
}