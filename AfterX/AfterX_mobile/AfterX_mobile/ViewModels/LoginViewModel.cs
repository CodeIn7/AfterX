using AfterX_mobile.State;
using AfterX_mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AfterX_mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }



        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            /*System.Diagnostics.Debug.WriteLine(Email);
            System.Diagnostics.Debug.WriteLine(Password);
            System.Diagnostics.Debug.WriteLine(Authenticator.Instance.IsLoggedIn);*/

            await Authenticator.Instance.Login(Email, Password);
           
            if (Authenticator.Instance.IsLoggedIn)
            {
                await Shell.Current.GoToAsync($"{nameof(AboutPage)}");
            }
        }
    }
}
