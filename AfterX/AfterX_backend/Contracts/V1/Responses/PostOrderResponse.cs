using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Requests
{
    public class PostOrderResponse
    {
        public int Id { get; set; }
        public int Tableid { get; set; }
        public string Note { get; set; }
        public TimeSpan Time { get; set; }
        public bool? Active { get; set; }
    }
}
