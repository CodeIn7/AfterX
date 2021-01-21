using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateOrderAsync(Order order)
        {
            _dataContext.Add(order);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);

            _dataContext.Remove(order);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _dataContext.Orders
                .FirstOrDefaultAsync(m => m.Id == orderId);

            return order;
        }

        public async Task<List<Order>> GetOrdersAsync(User bartender)
        {
            var userAtt = await _dataContext.Userattribues.FirstOrDefaultAsync(o=>o.Userid==bartender.Id);
            return await _dataContext.Orders.Include(o=>o.Table).Where(a=>a.Table.Clubid== userAtt.ClubId && a.Active==true).ToListAsync();

        }

        public async Task<bool> UpdateOrderAsync(Order orderToUpdate)
        {
            _dataContext.Update(orderToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> CreateOrdersAsync(List<Order> orders)
        {
            await _dataContext.AddRangeAsync(orders);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeactivateOrderAsync(int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);
            order.Active = false;
            _dataContext.Update(order);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
