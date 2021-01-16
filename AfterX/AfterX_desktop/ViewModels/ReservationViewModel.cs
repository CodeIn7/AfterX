using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AfterX_desktop.Models;
using AfterX_desktop.Commands;
using System.Collections.ObjectModel;

namespace AfterX_desktop.ViewModels
{
    public class ReservationViewModel : BaseViewModel, IPageViewModel
    {
        /*#region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion*/

        ReservationService ObjReservationService;
        public ReservationViewModel()
        {
            ObjReservationService = new ReservationService();
            LoadData();
            currentReservation = new Reservation();
            
        }

        #region DisplayOperation
        private ObservableCollection<Reservation> reservationsList;

        public ObservableCollection<Reservation> ReservationsList
        {
            get { return reservationsList; }
            set { reservationsList = value; OnPropertyChanged("ReservationsList"); }
        }
        private void LoadData()
        {
            ReservationsList = new ObservableCollection<Reservation>(ObjReservationService.GetAll());
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

        /*#region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjReservation = ObjReservationService.Search(CurrentReservation.Id);
                if (ObjReservation != null)
                {
                    CurrentReservation.TableId = ObjReservation.TableId;
                    CurrentReservation.UserId = ObjReservation.UserId;
                    CurrentReservation.ReservationDate = ObjReservation.ReservationDate;
                }
                else
                {
                    Message = "Resrvation not found";
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion*/
    }
}
