using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AfterX_desktop.Commands;
using System.Collections.ObjectModel;
using AfterX_desktop.State;
using AfterX_desktop.Helper;
using AfterX;
using AfterX.Contracts.V1;

namespace AfterX_desktop.ViewModels
{
    public class ReservationViewModel : BaseViewModel, IPageViewModel
    {

        //ReservationService ObjReservationService;
        public ReservationViewModel()
        {
            //ObjReservationService = new ReservationService();
            LoadDataAsync();

            currentReservation = new Reservation();
        }

        #region DisplayOperation
        private ObservableCollection<Reservation> reservationsList;

        public ObservableCollection<Reservation> ReservationsList
        {
            get { return reservationsList; }
            set { reservationsList = value; OnPropertyChanged("ReservationsList"); }
        }
        private async Task LoadDataAsync()
        {
            string token = Authenticator.Instance.Token;
            System.Diagnostics.Debug.WriteLine("TOKEN", token);
            ReservationsList = await RestHelper.GetReservations();
            System.Diagnostics.Debug.WriteLine("Reservations list: "  + ReservationsList);

        }
        #endregion

        private Reservation currentReservation;

        public Reservation CurrentReservation
        {
            get { return currentReservation; }
            set { currentReservation = value; OnPropertyChanged("CurrentReservation"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
    }
}
