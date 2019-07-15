using Dominos.Common.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Net;
using System.Text;

namespace Dominos.Common.Helpers
{
    public static class HttpHelper
    {
        public static T Get<T>(string url, string accessToken = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (accessToken.IsNotNull())
            {
                request.Headers.Add("Authorization", $"{accessToken.AddBearerIfNotExist()}");
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(responseString, new IsoDateTimeConverter() { DateTimeFormat = General.JsonDateFormat });
        }

        public static R Post<R, T>(T entity, string url, string accessToken = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            if (accessToken.IsNotNull())
            {
                request.Headers.Add("Authorization", $"{accessToken.AddBearerIfNotExist()}");
            }
            var postString = JsonConvert.SerializeObject(entity, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            var postData = Encoding.UTF8.GetBytes(postString);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postData.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(postData, 0, postData.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return JsonConvert.DeserializeObject<R>(responseString, new IsoDateTimeConverter() { DateTimeFormat = General.JsonDateFormat }); ;
        }
    }
}