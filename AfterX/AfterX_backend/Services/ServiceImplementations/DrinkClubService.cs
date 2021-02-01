using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class DrinkClubService : IDrinkClubService
    {
        private readonly DataContext _dataContext;
        public DrinkClubService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateDrinkClubAsync(DrinkClub drinkClub)
        {
            _dataContext.Add(drinkClub);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteDrinkClubAsync(int drinkClubId)
        {
            var drinkClub = await GetDrinkClubByIdAsync(drinkClubId);

            _dataContext.Remove(drinkClub);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<DrinkClub> GetDrinkClubByIdAsync(int drinkClubId)
        {
            return null;
            //var drinkClub = await _dataContext.DrinkClubs
            //    .FirstOrDefaultAsync(m => m. == drinkClubId);

            //return drinkClub;
        }
        public async Task<bool> CreateDrinkClubListAsync(List<DrinkClub> drinkInClub)
        {
            await _dataContext.AddRangeAsync(drinkInClub);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<DrinkClub>> GetDrinkClubsAsync()
        {
            return await _dataContext.DrinkClubs.ToListAsync();

        }

        public async Task<bool> UpdateDrinkClubAsync(DrinkClub drinkClubToUpdate)
        {
            _dataContext.Update(drinkClubToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<List<DrinkClub>> GetDrinkClubsByReservationIdAsync(int reservationId)
        {
            var reservation = await _dataContext.Reservations.Include(a=>a.Table).FirstOrDefaultAsync(a => a.Id == reservationId);
            return await _dataContext.DrinkClubs.Include(a=>a.Drink).Where(s => s.Clubid == reservation.Table.Clubid).ToListAsync();
        }

    }
}
