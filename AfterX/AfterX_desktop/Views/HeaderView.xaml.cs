using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AfterX_desktop.Commands;
using AfterX_desktop.State;

namespace AfterX_desktop.Views
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        private void Reservations_Click(object sender, RoutedEventArgs e)
        {
            Mediator.Notify("seeReservations", "");
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            Mediator.Notify("seeOrders", "");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Authenticator.Instance.Logout();
            Mediator.Notify("logout", "");
        }
    }
}
