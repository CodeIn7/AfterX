using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class RoleUser
    {
        public int Userid { get; set; }
        public int Roleid { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userattribue User { get; set; }
    }
}
