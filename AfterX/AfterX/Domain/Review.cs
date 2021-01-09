using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class Review
    {
        public int Id { get; set; }
        public int Clubid { get; set; }
        public int Userid { get; set; }
        public DateTime Date { get; set; }
        public string Desciption { get; set; }
        public short? Grade { get; set; }

        public virtual Club Club { get; set; }
        public virtual User User { get; set; }
    }
}
