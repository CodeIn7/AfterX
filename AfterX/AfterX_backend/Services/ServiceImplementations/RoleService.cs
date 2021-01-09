using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _dataContext;
        public RoleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateRoleAsync(Role role)
        {
            _dataContext.Add(role);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            var role = await GetRoleByIdAsync(roleId);

            _dataContext.Remove(role);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            var role = await _dataContext.Roles
                .FirstOrDefaultAsync(m => m.Id == roleId);

            return role;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _dataContext.Roles.ToListAsync();

        }

        public async Task<bool> UpdateRoleAsync(Role cityToUpdate)
        {
            _dataContext.Update(cityToUpdate);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
