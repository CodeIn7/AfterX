using AfterX_desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterX_desktop.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value; OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void seeReservations(object obj)
        {
            ChangeViewModel(PageViewModels[1]);
        }

        private void seeOrders(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void logout(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }
        public MainWindowViewModel()
        {
            PageViewModels.Add(new LoginViewModel());
            PageViewModels.Add(new ReservationViewModel());
            PageViewModels.Add(new OrderViewModel());

            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("seeReservations", seeReservations);
            Mediator.Subscribe("seeOrders", seeOrders);
            Mediator.Subscribe("logout", logout);
        }
    }
}
