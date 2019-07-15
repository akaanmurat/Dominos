using Dominos.Common.Configuration;
using Dominos.Common.Constants;
using Dominos.Common.DTO.Output;
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
                return Session.Customer;
            }
        }

        public int? CustomerId
        {
            get
            {
                return Session.CustomerId;
            }
        }

        public string BasketKey
        {
            get
            {
                return Session.BasketKey;
            }
        }
    }
}