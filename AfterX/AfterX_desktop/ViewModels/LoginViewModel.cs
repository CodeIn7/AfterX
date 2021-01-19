using AfterX_desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Controllers.V1;
using AfterX_desktop.Helper;
using Microsoft.AspNetCore.Mvc;

using System.Windows.Controls;
using AfterX_desktop.State;

namespace AfterX_desktop.ViewModels
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private string token;

        public LoginViewModel()
        {
            loginCommand = new RelayCommand<object>(Login);
            token = null;
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get{ return loginCommand; }
        }

        private string loginText = "";

        public string LoginText
        {
            get { return loginText; }
            set { loginText = value; }
        }

        public async void Login(object passwordBoxInput)
        {
            var passwordBox = passwordBoxInput as PasswordBox;
            await Authenticator.Instance.Login(Email, passwordBox.Password);
            if (Authenticator.Instance.IsLoggedIn) {
                Mediator.Notify("seeReservations", "");
            }
            else
            {
                loginText = "Neispravan email ili lozinka.";
            }
            
        }
    }
}
