using AfterX_mobile.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_mobile.State
{
    public sealed class Authenticator : IAuthenticator
    {

        private static Authenticator instance = null;
        private static readonly object padlock = new object();

        Authenticator()
        {

        }
        

        public static Authenticator Instance
        {
            get
            {
                lock (padlock)
                    if (instance == null)
                    {
                        instance = new Authenticator();
                    }
                return instance;
            }
        }
        private string token = null;
        public string Token
        {
            get
            {
                return token;
            }
        }

        public bool IsLoggedIn => token != null;

        public async Task Login(string username, string password)
        {   
            string res = await RestHelper.Login(username, password);
            
            if (!res.Equals("{\"errors\":[\"Username/password don't match\"]}"))
                token = res.Split('\"')[3];      
        }

        public void Logout()
        {
            token = null;
        }

    }
}
