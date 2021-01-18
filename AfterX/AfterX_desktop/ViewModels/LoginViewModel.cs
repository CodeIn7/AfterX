using AfterX_desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AfterX_desktop.ViewModels
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {

        public LoginViewModel()
        {
            loginCommand = new RelayCommand(Login);
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

        public void Login()
        {
            Mediator.Notify("seeReservations", "");
        }
    }
}
