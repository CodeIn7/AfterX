using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IDrinkTypesService
    {
        Task<List<DrinkType>> GetDrinkTypesAsync();
        Task<DrinkType> GetDrinkTypeByIdAsync(int drinkTypeId);
        Task<bool> CreateDrinkTypeAsync(DrinkType drinkType);
        Task<bool> UpdateDrinkTypeAsync(DrinkType drinkTypeToUpdate);
        Task<bool> DeleteDrinkTypeAsync(int drinkTypeId);
    }
}
