using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class DrinkClub
    {
        public int Drinkid { get; set; }
        public int Clubid { get; set; }
        public decimal Price { get; set; }

        public virtual Club Club { get; set; }
        public virtual Drink Drink { get; set; }
    }
}
