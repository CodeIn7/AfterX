using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync(User bartender);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<bool> CreateOrderAsync(Order order);
        Task<bool> UpdateOrderAsync(Order cityToUpdate);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<bool> DeactivateOrderAsync(int orderId);
        Task<bool> CreateOrdersAsync(List<Order> orders);
    }
}
