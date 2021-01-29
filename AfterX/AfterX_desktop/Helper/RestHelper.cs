using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AfterX;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using AfterX_desktop.State;
using Microsoft.AspNetCore.Mvc;
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

        public static async Task<ObservableCollection<Reservation>> GetReservations()
        {
            ObservableCollection<Reservation> data = new ObservableCollection<Reservation>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authenticator.Instance.Token);
                using (HttpResponseMessage res = await client.GetAsync(Base + ApiRoutes.Reservations.GetAll))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsAsync<ObservableCollection<Reservation>>();
                    }

                }
            }
            return data;
        }

        public static async Task<ObservableCollection<Order>> GetOrders()
        {

            ObservableCollection<Order> data = new ObservableCollection<Order>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authenticator.Instance.Token);
                using (HttpResponseMessage res = await client.GetAsync(Base + ApiRoutes.Orders.GetAll))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsAsync<ObservableCollection<Order>>();
                    }

                }
            }
            return data;
        }

        public static async Task EndOrder(int orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authenticator.Instance.Token);
                using (HttpResponseMessage res = await client.PostAsync($"https://localhost:5001/api/v1/orders/done/{orderId}", JsonContent.Create(orderId)))
                {
                    using (HttpContent content = res.Content)
                    {
                    }

                }
            }
        }

        public static async Task<ObservableCollection<OrderDrink>> GetOrderDrinks(int orderId)
        {

            ObservableCollection<OrderDrink> data = new ObservableCollection<OrderDrink>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authenticator.Instance.Token);

                using (HttpResponseMessage res = await client.GetAsync($"https://localhost:5001/api/v1/orders/{orderId}"))
                {
                    using (HttpContent content = res.Content)
                    {
                        data = await content.ReadAsAsync<ObservableCollection<OrderDrink>>();
                    }

                }
            }
            return data;
        }
    }
}
