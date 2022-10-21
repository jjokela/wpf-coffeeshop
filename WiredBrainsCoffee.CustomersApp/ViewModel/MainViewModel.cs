using System.Threading.Tasks;
using WiredBrainsCoffee.CustomersApp.Command;

namespace WiredBrainsCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        
        public CustomerViewModel CustomersViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }

        public MainViewModel(CustomerViewModel customerViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customerViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;
            
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public DelegateCommand SelectViewModelCommand { get; }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        public override async Task LoadAsync()
        {
            if(SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }
}
