using Microsoft.AspNetCore.Mvc;
using Dominos.Web.UI.Models.Home;
using Dominos.Web.UI.Business.Helper.Home;
using Dominos.Common.Configuration;
using Microsoft.Extensions.Options;
using Dominos.Web.UI.Business;

namespace Dominos.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<DominosConfig> dominosConfig,
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

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            var instance = new HomeInstance(this, ModelState, HomeSubmits.List, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model, HomeSubmits submit)
        {
            var instance = new HomeInstance(this, ModelState, submit, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return RedirectToAction("Index", "Basket");
        }
    }
}
