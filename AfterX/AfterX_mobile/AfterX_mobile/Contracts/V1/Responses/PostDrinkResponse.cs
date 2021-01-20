using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Contracts.V1.Responses
{
    public class PostDrinkResponse
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public int Drinktypeid { get; set; }
    }
}
