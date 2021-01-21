using System;
using System.Collections.Generic;
using System.Text;

namespace AfterX_mobile.ViewModels
{
    class ReservationViewModel : BaseViewModel
    {
        public ReservationViewModel(int id)
        {
            Id = id;
            System.Diagnostics.Debug.WriteLine(Id);
        }

        public int Id { get; }

        private int minOrder;

        public int MinOrder
        {
            get { return minOrder; }
            set { minOrder = value; OnPropertyChanged("MinOrder");  }
        }


        public void GetReservationForm(int type)
        {
            System.Diagnostics.Debug.WriteLine(type);
        }
    }
}
