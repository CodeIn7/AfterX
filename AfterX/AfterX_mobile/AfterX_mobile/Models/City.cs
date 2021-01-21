using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class City
    {

        public City(int id, int cid, string name, decimal zip)
        {
            this.Id = id;
            this.Countryid = cid;
            this.Name = name;
            this.Zip = zip;
        }

        public int Id { get; set; }
        public int Countryid { get; set; }
        public string Name { get; set; }
        public decimal? Zip { get; set; }

        //public virtual Country Country { get; set; }
        //public virtual ICollection<Address> Addresses { get; set; }
    }
}
