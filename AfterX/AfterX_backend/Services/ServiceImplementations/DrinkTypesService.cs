using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class DrinkTypesService : IDrinkTypesService
    {
        private readonly DataContext _dataContext;

        public DrinkTypesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<DrinkType>> GetDrinkTypesAsync()
        {
            var list = await _dataContext.DrinkTypes.ToListAsync();

            return list;
        }

        public async Task<DrinkType> GetDrinkTypeByIdAsync(int drinkTypeId)
        {
            var drinkType = await _dataContext.DrinkTypes.SingleOrDefaultAsync(x => x.Id == drinkTypeId);

            return drinkType;
        }

        public async Task<bool> UpdateDrinkTypeAsync(DrinkType drinkTypeToUpdate)
        {
            _dataContext.Update(drinkTypeToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> CreateDrinkTypeAsync(DrinkType drinkType)
        {
            await _dataContext.DrinkTypes.AddAsync(drinkType);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteDrinkTypeAsync(int drinkTypeId)
        {
            var drinkType = GetDrinkTypeByIdAsync(drinkTypeId);

            _dataContext.Remove(drinkType);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
