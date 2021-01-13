using AfterX;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IAddressService
    {
        Task<List<Address>> GetAddressesAsync();
        Task<Address> GetAddressByIdAsync(int addressId);
        Task<Address> GetAddressByFormAsync(int cityId,string street,string number);
        Task<bool> CreateAddressAsync(Address address);
        Task<bool> UpdateAddressAsync(Address addressToUpdate);
        Task<bool> DeleteAddressAsync(int addressId);
    }
}