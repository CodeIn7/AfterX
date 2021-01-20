using System;
using System.Collections.Generic;


namespace AfterX
{
    public partial class Reservation
    {
        public Reservation()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int Tableid { get; set; }
        public int Userid { get; set; }
        public DateTime Reservationdate { get; set; }
        public short Numberofpeople { get; set; }

        public virtual Table Table { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
