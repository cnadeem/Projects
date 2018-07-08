using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebProduct
{
    public static class WebApiCaller
    {
        readonly static string WebApiUrl = System.Configuration.ConfigurationManager.AppSettings["WebApiUrl"];
        public static Product[] GetProducts(string token)
        {
            Product[] products = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var resp = client.GetAsync(WebApiUrl + "api/Products");

                    resp.Wait(TimeSpan.FromSeconds(10));

                    if (resp.IsCompleted)
                    {
                        if (resp.Result.StatusCode == HttpStatusCode.OK)
                        {
                            string response = resp.Result.Content.ReadAsStringAsync().Result;
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            products = js.Deserialize<Product[]>(response);
                        }
                        else
                        {
                            //errror occured
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return products;
        }
        public static string GetUserToken(string username, string password)
        {

            var getTokenUrl = string.Format(WebApiUrl + "token");

            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

                HttpResponseMessage result = httpClient.PostAsync(getTokenUrl, content).Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    var data = (JObject)JsonConvert.DeserializeObject(resultContent);
                    string access_token = data["access_token"].Value<string>();

                    return access_token;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}