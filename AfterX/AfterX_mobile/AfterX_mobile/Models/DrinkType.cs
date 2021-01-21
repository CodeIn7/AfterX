using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class DrinkType
    {
        public DrinkType()
        {
            Drinks = new HashSet<Drink>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
