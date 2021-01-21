using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDrinks = new HashSet<OrderDrink>();
        }

        public Order(int id, int resid)
        {
            this.Id = id;
            this.Reservationid = resid;
        }

        public int Id { get; set; }
        public int Tableid { get; set; }
        public int Reservationid { get; set; }
        public string Note { get; set; }
        public TimeSpan Time { get; set; }
        public bool? Active { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<OrderDrink> OrderDrinks { get; set; }
    }
}
