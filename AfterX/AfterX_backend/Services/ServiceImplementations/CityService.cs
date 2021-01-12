using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Services
{
    public class CityService : ICityService
    {
        private readonly DataContext _dataContext;
        
        public CityService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<City>> GetCitiesAsync()
        {
            return await _dataContext.Cities.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            var city = await _dataContext.Cities.SingleOrDefaultAsync(x => x.Id == cityId);

            return city;
        }

        public async Task<bool> UpdateCityAsync(City cityToUpdate)
        {
            _dataContext.Update(cityToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> CreateCityAsync(City city)
        {
            await _dataContext.Cities.AddAsync(city);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var city = GetCityByIdAsync(cityId);

            _dataContext.Remove(city);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
