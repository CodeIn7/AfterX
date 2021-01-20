using System;
using System.Collections.Generic;


namespace AfterX
{
    public partial class OrderDrink
    {
        public int Orderid { get; set; }
        public int Drinkid { get; set; }
        public short Nobottles { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
    }
}
