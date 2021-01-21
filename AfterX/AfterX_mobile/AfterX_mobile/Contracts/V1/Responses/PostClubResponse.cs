using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterX_mobile.Models;

namespace AfterX_mobile.Contracts.V1.Responses
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
