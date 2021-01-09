using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public int Countryid { get; set; }
        public string Name { get; set; }
        public decimal? Zip { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
