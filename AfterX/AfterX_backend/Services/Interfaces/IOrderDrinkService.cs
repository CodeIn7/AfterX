using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface IOrderDrinkService
    {
        Task<List<OrderDrink>> GetOrderDrinksAsync();
        Task<List<OrderDrink>> GetOrderDrinksByOrderIdAsync(int orderId);
        Task<bool> CreateOrderDrinkeAsync(OrderDrink orderDrink);
        Task<bool> UpdateOrderDrinkAsync(OrderDrink orderDrinkToUpdate);
        Task<bool> DeleteOrderDrinkAsync(int Drinkid,int orderId);
        Task<bool> CreateOrdersAsync(List<OrderDrink> orders);
    }
}
