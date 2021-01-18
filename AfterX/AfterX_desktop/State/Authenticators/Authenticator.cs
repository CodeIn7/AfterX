using AfterX_desktop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_desktop.State
{
    public class Authenticator : IAuthenticator
    {
       

        private  Authenticator instance;

        public  Authenticator Instance
        {
            get {
                if (instance == null)
                    instance = new Authenticator();
                return instance;
            }
        }

        private string token;
        public string Token
        {
            get
            {
                return token;
            }
            private set
            {
                token = value;
            }
        }

        public bool IsLoggedIn => token != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {   
            string res = await RestHelper.Login(username, password);
            if(!(res == string.Empty))
                token = res.Split("\"")[3];
           
        }

        public void Logout()
        {
            token = null;
        }

    }
}
