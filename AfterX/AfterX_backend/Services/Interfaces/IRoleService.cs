using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<bool> CreateRoleAsync(Role role);
        Task<bool> UpdateRoleAsync(Role cityToUpdate);
        Task<bool> DeleteRoleAsync(int roleId);
    }
}
