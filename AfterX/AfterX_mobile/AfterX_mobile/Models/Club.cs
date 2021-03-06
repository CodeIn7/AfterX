﻿using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class Club
    {
        public Club()
        {
            DrinkClubs = new HashSet<DrinkClub>();
            Events = new HashSet<Event>();
            Reviews = new HashSet<Review>();
            Tables = new HashSet<Table>();
        }

        public Club(int id, string name, int addressId)
        {
            this.Id = id;
            this.Name = name;
            this.Addressid = addressId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Addressid { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<DrinkClub> DrinkClubs { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
