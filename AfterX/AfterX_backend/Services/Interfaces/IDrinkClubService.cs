using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IDrinkClubService
    {
        Task<List<DrinkClub>> GetDrinkClubsAsync();
        Task<DrinkClub> GetDrinkClubByIdAsync(int drinkClubId);
        Task<bool> CreateDrinkClubAsync(DrinkClub drinkClub);
        Task<bool> UpdateDrinkClubAsync(DrinkClub cityToUpdate);
        Task<bool> DeleteDrinkClubAsync(int drinkClubId);

        Task<bool> CreateDrinkClubListAsync(List<DrinkClub> tables);
    }
}
