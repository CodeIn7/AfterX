using AfterX_backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterX;

namespace AfterX_backend.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(User user, string password, string roleName);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<int> GetUserIdByName(string name);
    }
}
