using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AfterX_android
{
    [Activity(Label = "Home")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home);
            string email = Intent.GetStringExtra("email" ?? "Not recv");
            string password = Intent.GetStringExtra("password" ?? "Not recv");

            var email1 = FindViewById<TextView>(Resource.Id.email);
            var password1 = FindViewById<TextView>(Resource.Id.password);
            email1.Text = email;
            password1.Text = password;

            // Create your application here
        }
    }
}