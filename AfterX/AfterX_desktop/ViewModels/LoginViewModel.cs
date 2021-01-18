using AfterX_desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Controllers.V1;
using Microsoft.AspNetCore.Mvc;

namespace AfterX_desktop.ViewModels
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private UserLoginRequest userLoginRequest;
        IdentityController identityController;


        public LoginViewModel()
        {
            loginCommand = new RelayCommand(Login);
            userLoginRequest = new UserLoginRequest();
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged("UserName"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private RelayCommand loginCommand;

        public RelayCommand LoginCommand
        {
            get{ return loginCommand;}
        }

        public async void Login()
        {
            userLoginRequest.Email = userName;
            userLoginRequest.Password = "Admin123!";//Password;
            IActionResult actionResult = await identityController.Login(userLoginRequest);
            Console.WriteLine(actionResult.ToString());
            //string Token = loginResult;
            Mediator.Notify("seeReservations", "");
        }
    }
}
