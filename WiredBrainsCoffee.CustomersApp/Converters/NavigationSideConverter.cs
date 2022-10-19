using System;
using System.Globalization;
using System.Windows.Data;
using WiredBrainsCoffee.CustomersApp.ViewModel;

namespace WiredBrainsCoffee.CustomersApp.Converters
{
    public class NavigationSideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSide) value;
            return navigationSide == NavigationSide.Left ? 0 : 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
