using Dominos.Common.Constants;
using Microsoft.AspNetCore.Http;
using System;

namespace Dominos.Web.UI.Business
{
    public class CookieHelper
    {
        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        private readonly HttpContext httpContext;

        public void Set(string key, string value)
        {
            httpContext.Response.Cookies.Delete(key);
            httpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMonths(1)
            });
        }

        public string Get(string key)
        {
            string value = null;

            try
            {
                value = httpContext.Request.Cookies[key].ToString();
            }
            catch (Exception)
            {

            }

            return value;
        }

        public void Remove(string key)
        {
            httpContext.Response.Cookies.Delete(key);
        }        
    }
}