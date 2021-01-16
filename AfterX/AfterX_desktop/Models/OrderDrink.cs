using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AfterX_desktop.Models;
namespace AfterX_desktop.Models
{
    public class OrderDrink : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public OrderDrink(string v1, int v2)
        {
            this.drink = v1;
            this.noBottles = v2;
        }

        private String drink;

        public String Drink
        {
            get { return drink; }
            set { drink = value; OnPropertyChanged("Drink"); }
        }

        private int noBottles;

        public int NoBottles
        {
            get { return noBottles; }
            set { noBottles = value; OnPropertyChanged("NoBottles"); }
        }
    }
}
