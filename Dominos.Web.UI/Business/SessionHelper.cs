using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Dominos.Web.UI.Business
{
    public class SessionHelper
    {
        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        private readonly HttpContext httpContext;

        public string SessionId
        {
            get { return httpContext.Session.Id; }
        }

        public T Get<T>(string key)
        {
            try
            {
                var jsonObject = httpContext.Session.GetString(key);
                return JsonConvert.DeserializeObject<T>(jsonObject);
            }
            catch
            {
                return default(T);
            }
        }

        public void Set(string key, object value)
        {
            var valueJson = JsonConvert.SerializeObject(value);
            httpContext.Session.SetString(key, valueJson);
        }

        public void End()
        {
            httpContext.Session.Clear();
        }
    }
}