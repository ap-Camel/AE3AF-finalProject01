using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FinalProject.Services
{
    public class ApiServices
    {

        public static async Task<List<T>> GetItems<T>(string controller) where T : new()
        {
            List<T> list = new List<T>();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string fullUrl = $"https://www.breakingbadapi.com/api/{controller}";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.
                    Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }

            return list;
        }

    }
}
