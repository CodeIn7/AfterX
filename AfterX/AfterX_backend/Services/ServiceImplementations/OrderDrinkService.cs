using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class OrderDrinkService : IOrderDrinkService
    {
        private readonly DataContext _dataContext;


        public OrderDrinkService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateOrderDrinkeAsync(OrderDrink orderDrink)
        {
            _dataContext.Add(orderDrink);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> CreateOrdersAsync(List<OrderDrink> orderDrinks)
        {
            _dataContext.AddRangeAsync(orderDrinks);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteOrderDrinkAsync(int Drinkid, int orderId)
        {
            var orderDrink = await _dataContext.OrderDrinks.FirstOrDefaultAsync(
                drinkOrder => drinkOrder.Orderid == orderId && drinkOrder.Drinkid == Drinkid);

            _dataContext.Remove(orderDrink);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
        public async Task<List<OrderDrink>> GetOrderDrinksAsync()
        {
            return await _dataContext.OrderDrinks.ToListAsync();
        }

        public async Task<List<OrderDrink>> GetOrderDrinksByOrderIdAsync(int orderId)
        {
            return await _dataContext.OrderDrinks.Where(drinkOrder => drinkOrder.Orderid == orderId).ToListAsync();
        }

        public async Task<bool> UpdateOrderDrinkAsync(OrderDrink orderDrinkToUpdate)
        {
            _dataContext.Update(orderDrinkToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
