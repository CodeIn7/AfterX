using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Responses
{
    public class PostClubResponse
    {
        public string Name { get;  set; }
        public int ClubId { get; set; }
        public int AddressId { get; set; }
        public int Cityid { get; set; }
        public string Number { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
