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
    class OrderViewModel : BaseViewModel, IPageViewModel
    {
        /*#region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion*/

        OrderService ObjOrderService;
        public OrderViewModel()
        {
            ObjOrderService = new OrderService();
            LoadData();
            currentOrder = new Order();
            showDrinksCommand = new RelayCommand(ShowDrinks);

        }

        private RelayCommand showDrinksCommand;

        public RelayCommand ShowDrinksCommand
        {
            get { return showDrinksCommand; }
        }

        public void ShowDrinks()
        {
            Mediator.Notify("seeReservations", "");
            Console.WriteLine("drinks");
        }

        #region DisplayOperation
        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; OnPropertyChanged("OrdersList"); }
        }
        private void LoadData()
        {
            OrdersList = new ObservableCollection<Order>(ObjOrderService.GetAll());
        }
        #endregion

        private Order currentOrder;

        public Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; OnPropertyChanged("CurrentOrder"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjOrder = ObjOrderService.Search(CurrentOrder.Id);
                if (ObjOrder != null)
                {
                    CurrentOrder.TableId = ObjOrder.TableId;
                    CurrentOrder.ReservationId = ObjOrder.ReservationId;
                    CurrentOrder.Note = ObjOrder.Note;
                    CurrentOrder.Time = ObjOrder.Time;
                    CurrentOrder.Active = ObjOrder.Active;
                    CurrentOrder.OrderDrinks = ObjOrder.OrderDrinks;

                }
                else
                {
                    Message = "Order not found";
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}

