using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
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
