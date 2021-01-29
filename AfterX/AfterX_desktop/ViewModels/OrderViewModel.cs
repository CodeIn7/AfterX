using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AfterX_desktop.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AfterX_backend.Services.ServiceImplementations;
using AfterX_desktop.State;
using AfterX;
using AfterX_desktop.Helper;

namespace AfterX_desktop.ViewModels
{
    class OrderViewModel : BaseViewModel, IPageViewModel
    {

        private int currentOrder;

        public OrderViewModel()
        {
            LoadDataAsync();
            getOrderDrinksCommand = new RelayCommand<int>(GetOrderDrinksAsync, null);
            //searchCommand = new RelayCommand(Search);
            hideOrderDrinksCommand = new RelayCommand(HideOrderDrinks);
            endOrderCommand = new RelayCommand<int>(EndOrderAsync, null);
        }

        private string buttonText;

        public string ButtonText
        {
            get { return buttonText ?? (buttonText = "Add"); }
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }

        private ICommand buttonClickCommand;
        public ICommand ButtonClickCommand
        {
            get { return buttonClickCommand ?? (buttonClickCommand = getOrderDrinksCommand); }
            set
            {
                buttonClickCommand = value;
                OnPropertyChanged("ButtonClickCommand");
            }
        }

        private ICommand hideOrderDrinksCommand;

        public ICommand HideOrderDrinksCommand
        {
            get { return getOrderDrinksCommand; }
        }

        private void HideOrderDrinks()
        {
            currentOrderDrinks = null;
            ButtonText = "Add";
            ButtonClickCommand = GetOrderDrinksCommand;

        }

        private ObservableCollection<OrderDrink> currentOrderDrinks;

        public ObservableCollection<OrderDrink> CurrentOrderDrinks
        {
            get { return currentOrderDrinks; }
            set { currentOrderDrinks = value; OnPropertyChanged("CurrentOrderDrinks"); }
        }

        private ICommand getOrderDrinksCommand;

        public ICommand GetOrderDrinksCommand
        {
            get { return getOrderDrinksCommand; }
        }

         public async void GetOrderDrinksAsync(int Id)
         {
             try
             {
                 ButtonText = "Save";
                 ButtonClickCommand = HideOrderDrinksCommand;
                ObservableCollection<OrderDrink> ObjOrderDrinks = await RestHelper.GetOrderDrinks(Id);
                if (ObjOrderDrinks != null)
                {
                    CurrentOrderDrinks = ObjOrderDrinks;
                    currentOrder = Id;
                }
                else
                {
                    Message = "Order Drinks not found";
                }
            }
             catch (Exception ex)
             {
                 Message = "Error";
             }
         }

        #region LoadData
        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; OnPropertyChanged("OrdersList"); }
        }
        private async Task LoadDataAsync()
        {
            OrdersList = await RestHelper.GetOrders();
        }
        #endregion

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region EndOrder
        private ICommand endOrderCommand;

        public ICommand EndOrderCommand
        {
            get { return endOrderCommand; }
        }

        public async void EndOrderAsync(int Id)
        {
            try
            {
                await RestHelper.EndOrder(Id);
                if (currentOrder == Id)
                {
                    CurrentOrderDrinks = null;
                }
                LoadDataAsync();
            }
            catch (Exception ex)
            {
                Message = "Error";
            }
        }
        #endregion

        #region SearchByReservationId
        private ICommand searchCommand;

        public ICommand SearchCommand
        {
            get { return searchCommand; }
        }
        private int selectedId;

        public int SelectedId
        {
            get { return selectedId; }
            set { selectedId = value; OnPropertyChanged("SelectedId"); }
        }

        /*public void Search()
        {
        int Id = 101;

            try
            {
                if (ObjOrderService.Search(selectedId) != null)
                {
                    OrdersList = new ObservableCollection<Order>(ObjOrderService.Search(selectedId));
                }
                else
                {
                    Message = "Order Drinks not found";
                }
            }
            catch (Exception ex)
            {
                Message = "Error";
            }
        }*/
        #endregion

    }
}
