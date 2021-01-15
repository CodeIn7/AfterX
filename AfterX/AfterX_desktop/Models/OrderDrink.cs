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
        private String drink;

        public String Drink
        {
            get { return drink; }
            set { drink = value; OnPropertyChanged("Drink"); }
        }

        private int noBottles;
        private string v1;
        private int v2;

        public OrderDrink(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int NoBottles
        {
            get { return noBottles; }
            set { noBottles = value; OnPropertyChanged("NoBottles"); }
        }
    }
}
