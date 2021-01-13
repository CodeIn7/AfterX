using System.Collections.Generic;

namespace AfterX_backend.Controllers.V1
{


    public class PostClubRequest
    {

        public string ClubName { get; set; }
        public int Cityid { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        //key=table type id, value = number of tables
        public Dictionary<int, TableRequest> Tables { get; set; }

    }
    public class TableRequest
    {
        public int numberOfTables { get; set; }
        public short Capacity { get; set; }
        public short Minnobottles { get; set; }
    }
}

