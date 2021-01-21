using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class Package
    {
        public Package()
        {
            PackageDrinks = new HashSet<PackageDrink>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PackageDrink> PackageDrinks { get; set; }
    }
}
