using AfterX_desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Controllers.V1;
using Microsoft.AspNetCore.Mvc;

using System.Windows.Controls;

namespace AfterX_desktop.ViewModels
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private UserLoginRequest userLoginRequest;
        IdentityController identityController;


        public LoginViewModel()
        {
            loginCommand = new RelayCommand<object>(Login);
            userLoginRequest = new UserLoginRequest();
            string token = null;
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
            get{ return loginCommand;}
        }

        public async void Login(object passwordBoxInput)
        {
            var passwordBox = passwordBoxInput as PasswordBox;
            userLoginRequest.Email = email;
            userLoginRequest.Password = passwordBox.Password;
            IActionResult actionResult = await identityController.Login(userLoginRequest);
            Console.WriteLine(actionResult.ToString());
            Mediator.Notify("seeReservations", "");
        }
    }
}
