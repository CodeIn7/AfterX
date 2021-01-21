using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_mobile.Contracts.V1.Requests
{
    public class UpdateDrinkRequest
    {
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public int Drinktypeid { get; set; }
    }
}
