using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace AfterX_desktop.Models
{
    public class Order : INotifyPropertyChanged
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

        private int reservationId;

        public int ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; OnPropertyChanged("ReservationId"); }
        }

        private String note;

        public String Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged("Note"); }
        }

        private String time;

        public String Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }

        private List<OrderDrink> orderDrinks;

        public List<OrderDrink> OrderDrinks
        {
            get { return orderDrinks; }
            set { orderDrinks = value; OnPropertyChanged("OrderDrinks"); }
        }

    }
}
