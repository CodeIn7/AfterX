using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class RoleUser : IdentityUserRole<int>
    {
        //public int UserId { get; set; }
        //public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userattribue User { get; set; }
    }
}
