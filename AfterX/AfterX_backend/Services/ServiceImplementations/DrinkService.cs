using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class DrinkService:IDrinkService
    {
        private readonly DataContext _dataContext;

        public DrinkService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Drink>> GetDrinksAsync()
        {
            var list = await _dataContext.Drinks.ToListAsync();

            return list;
        }

        public async Task<Drink> GetDrinkByIdAsync(int drinkId)
        {
            return await _dataContext.Drinks.SingleOrDefaultAsync(x => x.Id == drinkId);
        }
        public async Task<bool> UpdateDrinkAsync(Drink drinkToUpdate)
        {
            _dataContext.Update(drinkToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> CreateDrinkAsync(Drink drink)
        {
            await _dataContext.Drinks.AddAsync(drink);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteDrinkAsync(int drinkId)
        {
            var drink = await  GetDrinkByIdAsync(drinkId);

            _dataContext.Remove(drink);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }


    }
}
