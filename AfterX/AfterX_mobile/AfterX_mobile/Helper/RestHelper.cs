using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using AfterX_mobile.Contracts.V1.Requests;
using AfterX_mobile.Contracts.V1;

namespace AfterX_mobile.Helper
{
    public static class RestHelper
    {
        private static string Base = "https://192.168.0.35:45455/";
        
        public static async Task<string> Login(string email, string password)
        {
            UserLoginRequest user = new UserLoginRequest { Email = email, Password = password };

            var input = JsonContent.Create(user);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(Base+ApiRoutes.Identity.Login, input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }

                }
            }
            return string.Empty;

        }

        public static async Task<string> GetCities()
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(Base+ApiRoutes.Cities.GetAll))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;

        }
    }
}
