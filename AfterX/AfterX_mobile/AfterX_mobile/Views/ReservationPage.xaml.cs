using AfterX_mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfterX_mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage(int id)
        {
            InitializeComponent();
            BindingContext = new ReservationViewModel(id);

        }

        private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}