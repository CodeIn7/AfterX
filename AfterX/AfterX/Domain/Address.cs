using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class Address
    {
        public Address()
        {
            Clubs = new HashSet<Club>();
        }

        public int Id { get; set; }
        public int Cityid { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
    }
}
