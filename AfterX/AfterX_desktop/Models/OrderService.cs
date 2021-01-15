using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_desktop.Models
{
    public class OrderService
    {
        private static List<Order> objOrderList;

        public OrderService()
        {
            objOrderList = new List<Order>()
            {
                new Order{Id = 100, TableId = "1", ReservationId = 101, Note = "blabla", Time = "22:00", Active = true, OrderDrinks = new List<OrderDrink>() { new OrderDrink("Coca-Cola", 2) } },
                new Order{Id = 101, TableId = "2", ReservationId = 101, Note = "blabla", Time = "21:00", Active = false, OrderDrinks = new List<OrderDrink>() { new OrderDrink("Coca-Cola", 2) }}
            };
        }

        public List<Order> GetAll()
        {
            return objOrderList;
        }

        public bool Add(Order objNewOrder)
        {
            objOrderList.Add(objNewOrder);
            return true;
        }

        public bool Update(Order objOrderToUpdate)
        {
            bool IsUpdated = false;
            for (int index = 0; index < objOrderList.Count; index++)
            {
                if (objOrderList[index].Id == objOrderToUpdate.Id)
                {
                    objOrderList[index].TableId = objOrderToUpdate.TableId;
                    objOrderList[index].ReservationId = objOrderToUpdate.ReservationId;
                    objOrderList[index].Note = objOrderToUpdate.Note;
                    objOrderList[index].Time = objOrderToUpdate.Time;
                    objOrderList[index].Active = objOrderToUpdate.Active;
                    objOrderList[index].OrderDrinks = objOrderToUpdate.OrderDrinks;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int index = 0; index < objOrderList.Count; index++)
            {
                if (objOrderList[index].Id == id)
                {
                    objOrderList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        public Order Search(int id)
        {
            return objOrderList.FirstOrDefault(e => e.Id == id);
        }
    }
}
