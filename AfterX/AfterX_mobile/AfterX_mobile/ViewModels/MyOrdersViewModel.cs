using AfterX_mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AfterX_mobile.ViewModels
{
    public class MyOrdersViewModel : BaseViewModel
    {
        public Command LoadOrdersCommand { get; }

        public MyOrdersViewModel()
        {
            Orders = new ObservableCollection<Order>();
            Title = "Moje narudžbe";
            LoadOrdersCommand = new Command(() => ExecuteLoadOrdersCommand());
        }

        private ObservableCollection<Order> orders;

        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged("Orders"); }
        }


        void ExecuteLoadOrdersCommand()
        {
            IsBusy = true;

            try
            {
                Orders.Clear();
                ObservableCollection<Order> r = new ObservableCollection<Order>();
                r.Add(new Order(1, 1));
                foreach (var reservation in r)
                {
                    Orders.Add(reservation);
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
