using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AfterX_mobile.Models;

namespace AfterX_mobile.ViewModels
{
    class MyReservationsViewModel : BaseViewModel
    {
        public Command LoadReservationsCommand { get; }

        public MyReservationsViewModel()
        {
            Reservations = new ObservableCollection<Reservation>();
            Title = "Moje rezervacije";
            LoadReservationsCommand = new Command(() => ExecuteLoadReservationsCommand());
        }

        private ObservableCollection<Reservation> reservations;

        public ObservableCollection<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; OnPropertyChanged("Reservations"); }
        }


        void ExecuteLoadReservationsCommand()
        {
            IsBusy = true;

            try
            {
                Reservations.Clear();
                ObservableCollection<Reservation> r = new ObservableCollection<Reservation>();
                r.Add(new Reservation(1, 1, 1, new DateTime(), 10));
                foreach (var reservation in r)
                {
                    Reservations.Add(reservation);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
