using Dominos.Common.Configuration;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Output;
using Dominos.Web.UI.Business;
using Dominos.Web.UI.Business.Helper.Login;
using Dominos.Web.UI.Business.Helper.Register;
using Dominos.Web.UI.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dominos.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(IOptions<DominosConfig> dominosConfig,
                                SessionHelper session,
                                CookieHelper cookie)
        {
            _dominosConfig = dominosConfig.Value;
            _session = session;
            _cookie = cookie;
        }

        private readonly DominosConfig _dominosConfig;
        private readonly SessionHelper _session;
        private readonly CookieHelper _cookie;

        public IActionResult Login()
        {
            if (_session.Customer != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var instance = new LoginInstance(this, ModelState, LoginSubmits.Login, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return View();
        }

        public IActionResult Register()
        {
            if (_session.Customer != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var instance = new RegisterInstance(this, ModelState, RegisterSubmits.Register, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return View();
        }
    }
}