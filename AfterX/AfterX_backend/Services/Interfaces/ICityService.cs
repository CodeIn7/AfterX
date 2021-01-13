using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int cityId);
        Task<bool> CreateCityAsync(City city);
        Task<bool>  UpdateCityAsync(City cityToUpdate);
        Task<bool> DeleteCityAsync(int cityId);
    }
}
