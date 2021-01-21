using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_mobile.State
{
    public interface IAuthenticator
    {   
        //static Authenticator Instance { get; }
        string Token { get; }
        bool IsLoggedIn { get; }

        Task Login(string username, string password);

        void Logout();
    }
}
