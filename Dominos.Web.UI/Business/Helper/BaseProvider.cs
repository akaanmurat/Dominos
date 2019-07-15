using Dominos.Common.Classes;
using Dominos.Common.Configuration;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Output;
using Dominos.Common.Helpers;
using Dominos.Web.UI.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Dominos.Web.UI.Business.Helper
{
    public class BaseProvider
    {
        public Controller Controller { get; set; }
        public ModelStateDictionary ModelState { get; set; }
        public DominosConfig Config { get; set; }
        public SessionHelper Session { get; set; }
        public CookieHelper Cookie { get; set; }

        public CustomerOutputDTO Customer
        {
            get
            {
                return Session.Get<CustomerOutputDTO>(SessionKey.Customer);
            }
        }

        public int? CustomerId
        {
            get
            {
                var customerId = Customer?.CustomerId;

                if (customerId == null)
                {
                    try
                    {
                        customerId = Convert.ToInt32(Cookie.Get<string>(CookieKey.CustomerId));
                    }
                    catch (Exception)
                    {

                    }
                }

                return customerId;
            }
        }

        public string BasketKey
        {
            get
            {
                var cookieBasketKey = Cookie.Get<string>(CookieKey.CustomerId);
                if (cookieBasketKey == null)
                {
                    cookieBasketKey = Session.SessionId;
                    Cookie.Set(CookieKey.CustomerId, cookieBasketKey);
                }

                return cookieBasketKey;
            }
        }

        public void FillBasketList(BasketViewModel model)
        {
            var url = CustomerId == null ? $"{Config.DominosApiUrl}{Config.BasketServices.GetBasket}?basketKey={BasketKey}"
                                                    : $"{Config.DominosApiUrl}{Config.BasketServices.GetBasket}?customerId={CustomerId}";
            var basket = HttpHelper.Get<ResponseEntity<BasketOutputDTO>>(url)?.Result;

            model.BasketDetails = basket?.BasketDetails;
            model.DiscountPrice = basket?.DiscountPrice ?? default(double);
            model.TotalPrice = basket?.TotalPrice ?? default(double);
        }
    }
}