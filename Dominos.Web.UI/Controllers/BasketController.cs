﻿using Dominos.Common.Configuration;
using Dominos.Web.UI.Business;
using Dominos.Web.UI.Business.Helper.Basket;
using Dominos.Web.UI.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dominos.Web.UI.Controllers
{
    public class BasketController : Controller
    {
        public BasketController(IOptions<DominosConfig> dominosConfig,
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
            var model = new BasketViewModel();

            var instance = new BasketInstance(this, ModelState, BasketSubmits.List, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BasketViewModel model, BasketSubmits submit)
        {
            var instance = new BasketInstance(this, ModelState, submit, _dominosConfig, _session, _cookie);
            instance.Provider.Execute(model);

            return View(model);
        }
    }
}