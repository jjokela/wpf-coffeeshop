using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WiredBrainCoffee.CustomersApp.Data;
using WiredBrainsCoffee.CustomersApp.Model;
using WiredBrainsCoffee.CustomersApp.ViewModel;

namespace WiredBrainsCoffee.CustomersApp.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
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

        private void ButtonMoveNavigation_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveNavigation();
        }

        private void BtnAddCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Add();
        }
    }
}
