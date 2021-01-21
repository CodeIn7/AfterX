using System;
using System.Collections.Generic;


namespace AfterX_mobile.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Order>();
        }

        public int Id { get; set; }
        
        public int Number { get; set; }
        public int Tabletypeid { get; set; }
        public int Clubid { get; set; }
        public short? Capacity { get; set; }
        public short Minnobottles { get; set; }

        public virtual Club Club { get; set; }
        public virtual TableType Tabletype { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> Reservations { get; set; }
    }
}
