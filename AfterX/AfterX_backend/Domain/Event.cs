﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class Event
    {
        public int Id { get; set; }
        public int Clubid { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }

        public virtual Club Club { get; set; }
    }
}
