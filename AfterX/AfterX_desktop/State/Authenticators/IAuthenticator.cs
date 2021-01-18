using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_desktop.State
{
    public interface IAuthenticator
    {
        string Token { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task Login(string username, string password);

        void Logout();
    }
}
