using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
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
