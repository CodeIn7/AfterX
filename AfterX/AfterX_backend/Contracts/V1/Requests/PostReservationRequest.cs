using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Requests
{
    public class PostReservationRequest
    {
        public int Tableid { get; set; }
        //public int Userid { get; set; }
        public DateTime Reservationdate { get; set; }
        public short Numberofpeople { get; set; }   
        public virtual ICollection<OrderRequest> Orders { get; set; }
    }
    public class OrderRequest
    {
        public int Tableid { get; set; }
        public string Note { get; set; }
        public DateTime Time { get; set; }
        public virtual ICollection<Drinks> drinks { get; set; }

    }
    public class Drinks
    {
        public int Drinkid { get; set; }
        public short Nobottles { get; set; }

    }

}
