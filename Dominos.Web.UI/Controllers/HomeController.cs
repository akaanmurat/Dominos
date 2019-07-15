using Microsoft.AspNetCore.Mvc;
using Dominos.Web.UI.Models.Home;
using Dominos.Web.UI.Business.Helper.Home;
using Dominos.Common.Configuration;
using Microsoft.Extensions.Options;

namespace Dominos.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<DominosConfig> dominosConfig)
        {
            _dominosConfig = dominosConfig.Value;
        }

        private readonly DominosConfig _dominosConfig;

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            var instance = new HomeInstance(this, ModelState, HomeSubmits.List, _dominosConfig);
            instance.Provider.Execute(model);

            return View(model);
        }
    }
}
