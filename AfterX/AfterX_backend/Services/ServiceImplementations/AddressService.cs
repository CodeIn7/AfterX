using AfterX;
using AfterX_backend.Controllers.V1;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class AddressService : IAddressService
    {
        private readonly DataContext _dataContext;

        public AddressService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Address>> GetAddressesAsync()
        {
            var list = await _dataContext.Addresses.ToListAsync();

            return list;
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            return await _dataContext.Addresses.SingleOrDefaultAsync(x => x.Id == addressId);
        }
        public async Task<Address> GetAddressByFormAsync(int cityId, string street, string number)
        {
            var address = await _dataContext.Addresses
                .SingleOrDefaultAsync(
                    x => x.Cityid == cityId &&
                    x.Street == street &&
                    x.Number == number
                );

            return address;
        }
        public async Task<bool> UpdateAddressAsync(Address addressToUpdate)
        {
            _dataContext.Update(addressToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> CreateAddressAsync(Address address)
        {
            await _dataContext.Addresses.AddAsync(address);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteAddressAsync(int addressId)
        {
            var address = GetAddressByIdAsync(addressId);

            _dataContext.Remove(address);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }


    }
}
