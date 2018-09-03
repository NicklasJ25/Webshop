using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Webshop.Models;

namespace Webshop.Managers
{
    public class APIManager
    {
        public static string localApi = "http://localhost:34036/api/";
        public static string globalApi = "http://130.226.195.251:54876/api/";

        public static T Get<T>(string apiName)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(localApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(apiName).Result;
                    response.EnsureSuccessStatusCode();
                    T result = response.Content.ReadAsAsync<T>().Result;
                    return result;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static string Post(string apiName, string stringData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(localApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(apiName, contentData).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {
                return "Der skete en ukendt fejl";
            }
        }
    }
}