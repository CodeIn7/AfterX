﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AfterX
{
    public partial class PackageDrink
    {
        public int Packageid { get; set; }
        public int Drinkid { get; set; }
        public short Nobottles { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Package Package { get; set; }
    }
}
