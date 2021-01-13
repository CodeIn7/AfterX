using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IClubService 
    {
        Task<List<Club>> GetClubsByCityIdAsync(int cityId);
        Task<List<Club>> GetClubsAsync();
        Task<Club> GetClubByIdAsync(int clubId);
        Task<bool> CreateClubAsync(Club club);
        Task<bool> UpdateClubAsync(Club cityToUpdate);
        Task<bool> DeleteClubAsync(int clubId);
    }
}
