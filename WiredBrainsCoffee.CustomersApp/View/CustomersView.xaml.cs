using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainsCoffee.CustomersApp.ViewModel;

namespace WiredBrainsCoffee.CustomersApp.View
{
    public partial class CustomersView : UserControl
    {
        private readonly CustomerViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
