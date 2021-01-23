using AfterX;
using AfterX.Services;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    class ClubService : IClubService
    {
        private readonly DataContext _dataContext;
        public ClubService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateClubAsync(Club club)
        {
            _dataContext.Add(club);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteClubAsync(int clubId)
        {
            var club = await GetClubByIdAsync(clubId);

            _dataContext.Remove(club);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Club> GetClubByIdAsync(int clubId)
        {
            var club = await _dataContext.Clubs
                .FirstOrDefaultAsync(m => m.Id == clubId);

            return club;
        }

        public async Task<List<Club>> GetClubsAsync()
        {
            return await _dataContext.Clubs.ToListAsync();

        }

        public async Task<List<Club>> GetClubsByCityIdAsync(int cityId)
        {
            var clubs = await _dataContext.Clubs
                .Include(a => a.Tables).ThenInclude(table => table.Tabletype)
                .Include(a => a.DrinkClubs).ThenInclude(d => d.Drink)
                .Where(club => club.Address.Cityid == cityId)
                .ToListAsync();

            return clubs;
        }

        public async Task<bool> UpdateClubAsync(Club cityToUpdate)
        {
            _dataContext.Update(cityToUpdate);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
