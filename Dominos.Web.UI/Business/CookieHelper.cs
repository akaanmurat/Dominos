using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Dominos.Web.UI.Business
{
    public class CookieHelper
    {
        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        private readonly HttpContext httpContext;

        public void Set<T>(string key, T value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            var claimsPrincipal = CreateCookieClaims(key, jsonValue);
            httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal
            );
        }

        public T Get<T>(string key)
        {
            var jsonValue = httpContext.Request.Cookies[key];

            return JsonConvert.DeserializeObject<T>(jsonValue);
        }

        public void Remove()
        {
            httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private ClaimsPrincipal CreateCookieClaims(string key, string value)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(key, value));

            return new ClaimsPrincipal(identity);
        }
    }
}