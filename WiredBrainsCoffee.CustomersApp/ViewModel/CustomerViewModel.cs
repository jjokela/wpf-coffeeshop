using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainsCoffee.CustomersApp.Model;

namespace WiredBrainsCoffee.CustomersApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;
        private string _moveArrowAsset = ImagesArrowrightPng;
        private const string ImagesArrowrightPng = "/Images/arrowright.png";
        private const string ImagesArrowleftPng = "/Images/arrowleft.png";

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (Equals(value, _selectedCustomer)) return;
                _selectedCustomer = value;
                RaisePropertyChanged();
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

        public void Add()
        {
            var customer = new Customer {FirstName = "Eka"};
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        public void MoveNavigation()
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
