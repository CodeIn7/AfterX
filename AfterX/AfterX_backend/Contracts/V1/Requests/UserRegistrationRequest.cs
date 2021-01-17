using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Requests
{
    public class UserRegistrationRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Gender { get; set; }
        public int RoleId { get; set; }
        public DateTime Yearofbirth { get; set; }
        public string Telephone { get; set; }
    }
}
