using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainsCoffee.CustomersApp.Command;
using WiredBrainsCoffee.CustomersApp.Model;

namespace WiredBrainsCoffee.CustomersApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;
        private string _moveArrowAsset = ImagesArrowrightPng;
        private const string ImagesArrowrightPng = "/Images/arrowright.png";
        private const string ImagesArrowleftPng = "/Images/arrowleft.png";

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        private void Delete(object? obj)
        {
            if(SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? obj) => SelectedCustomer is not null;

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (Equals(value, _selectedCustomer)) return;
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            set
            {
                if (value == _navigationSide) return;
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public string MoveArrowAsset
        {
            get => _moveArrowAsset;
            set
            {
                if (value == _moveArrowAsset) return;
                _moveArrowAsset = value;
                RaisePropertyChanged();
            }
        }

        private void Add(object? parameter)
        {
            var customer = new Customer {FirstName = "Eka"};
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
            MoveArrowAsset = NavigationSide == NavigationSide.Left ? ImagesArrowrightPng : ImagesArrowleftPng;
        }
    }

    public enum NavigationSide
    {
        Left,
        Right
    }
}
