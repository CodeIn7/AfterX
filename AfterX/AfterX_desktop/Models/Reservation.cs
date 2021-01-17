using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace AfterX_desktop.Models
{
    public class Reservation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string tableId;

        public string TableId
        {
            get { return tableId; }
            set { tableId = value; OnPropertyChanged("TableId"); }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }

        private String reservationDate;

        public String ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; OnPropertyChanged("ReservationDate"); }
        }



    }
}
