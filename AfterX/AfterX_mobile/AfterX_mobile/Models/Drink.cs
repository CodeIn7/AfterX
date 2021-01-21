using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class Drink
    {
        public Drink()
        {
            DrinkClubs = new HashSet<DrinkClub>();
            OrderDrinks = new HashSet<OrderDrink>();
            PackageDrinks = new HashSet<PackageDrink>();
        }

        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public int Drinktypeid { get; set; }

        public virtual DrinkType Drinktype { get; set; }
        public virtual ICollection<DrinkClub> DrinkClubs { get; set; }
        public virtual ICollection<OrderDrink> OrderDrinks { get; set; }
        public virtual ICollection<PackageDrink> PackageDrinks { get; set; }
    }
}
