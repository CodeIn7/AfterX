using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int UserattribueId { get; set; }
        public virtual Userattribue Userattribue { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
