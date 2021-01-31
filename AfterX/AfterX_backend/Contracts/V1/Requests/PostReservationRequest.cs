using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Requests
{
    public class PostReservationRequest
    {
        public int ClubId { get; set; }
        public int TableTypeId { get; set; }
        public DateTime Reservationdate { get; set; }
        public short Numberofpeople { get; set; }   
    }

}
