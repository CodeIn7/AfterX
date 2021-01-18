using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using Newtonsoft.Json;

namespace AfterX_desktop.Helper
{
    public static class RestHelper
    {
        private static string Base = "https://localhost:5001/";
        
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
    }
}
