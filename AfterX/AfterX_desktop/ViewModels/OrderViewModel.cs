﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AfterX_desktop.Models;
using AfterX_desktop.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AfterX_backend.Services.ServiceImplementations;

namespace AfterX_desktop.ViewModels
{
    class OrderViewModel : BaseViewModel, IPageViewModel
    {

        OrderService ObjOrderService;
        private int currentOrder;

        public OrderViewModel()
        {
            ObjOrderService = new OrderService();
            LoadData();
            getOrderDrinksCommand = new RelayCommand<int>(GetOrderDrinks, null);
            //searchCommand = new RelayCommand<int>(Search, null);
            searchCommand = new RelayCommand(Search);

            endOrderCommand = new RelayCommand<int>(EndOrder, null);
        }

        #region OrderDrinksDetail
        private List<OrderDrink> currentOrderDrinks;

        public List<OrderDrink> CurrentOrderDrinks
        {
            get { return currentOrderDrinks; }
            set { currentOrderDrinks = value; OnPropertyChanged("CurrentOrderDrinks"); }
        }

        private ICommand getOrderDrinksCommand;

        public ICommand GetOrderDrinksCommand
        {
            get { return getOrderDrinksCommand; }
        }

        public void GetOrderDrinks(int Id)
        {
            try
            {
                var ObjOrderDrinks = ObjOrderService.GetOrderDrinks(Id);
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
        #endregion

        #region LoadData
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

        public void EndOrder(int Id)
        {
            try
            {
                if (ObjOrderService.End(Id))
                {   
                    if(currentOrder == Id)
                    {
                        CurrentOrderDrinks = null;
                    }
                    LoadData();
                    
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

        public void Search()
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
        }
        #endregion

    }



}