using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class Role :IdentityRole<int>
    {
        public Role()
        {
            RoleUsers = new HashSet<RoleUser>();
        }

        //public int Id { get; set; }
        //public string Name { get; set; }

        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
