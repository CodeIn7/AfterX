using System;
using System.Collections.Generic;


namespace AfterX
{
    public partial class TableType
    {
        public TableType()
        {
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}
