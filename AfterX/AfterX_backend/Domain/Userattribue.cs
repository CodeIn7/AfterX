using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class Userattribue
    {
        public Userattribue()
        {
            RoleUsers = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public char? Gender { get; set; }
        public DateTime? Yearofbirth { get; set; }
        public string Telephone { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
