using System.Windows;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainsCoffee.CustomersApp.ViewModel;

namespace WiredBrainsCoffee.CustomersApp
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(
                new CustomerViewModel(new CustomerDataProvider()),
                new ProductsViewModel());
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
