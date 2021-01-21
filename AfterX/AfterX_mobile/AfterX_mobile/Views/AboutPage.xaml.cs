using AfterX_mobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AfterX_mobile.Models;

namespace AfterX_mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var club = e.Item as Club;
            await Navigation.PushAsync(new ReservationPage(club.Id));
        }
    }
}