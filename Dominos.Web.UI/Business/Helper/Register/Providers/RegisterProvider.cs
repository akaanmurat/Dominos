using Dominos.Common.Classes;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Input;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Login;
using System;

namespace Dominos.Web.UI.Business.Helper.Register.Providers
{
    public class RegisterProvider : BaseRegisterProvider, IProvider<RegisterViewModel>
    {
        public void Execute(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            try
            {
                var url = $"{Config.DominosApiUrl}{Config.CustomerServices.Register}";

                var result = HttpHelper.Post<ResponseEntity<CustomerOutputDTO>, RegisterInputDTO>(
                                       new RegisterInputDTO
                                       {
                                           Email = model.Email,
                                           Name = model.Name,
                                           Password = model.Password,
                                           Surname = model.Surname,
                                           PhoneNumber = model.PhoneNumber
                                       },
                                       url)?.Result;

                if (result != null)
                {
                    Session.Set(SessionKey.Customer, result);
                    Cookie.Set(CookieKey.CustomerId, result.CustomerId.ToString());
                    return;
                }
                ModelState.AddModelError("Validation", "Kullanıcı oluşturulamadı!");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Validation", "Kullanıcı oluşturulamadı!");
            }
        }
    }
}