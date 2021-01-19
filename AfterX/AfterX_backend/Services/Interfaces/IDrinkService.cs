using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IDrinkService
    {
        Task<List<Drink>> GetDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int drinkId);
        Task<bool> CreateDrinkAsync(Drink drink);
        Task<bool> UpdateDrinkAsync(Drink drinkToUpdate);
        Task<bool> DeleteDrinkAsync(int drinkId);
    }
}
