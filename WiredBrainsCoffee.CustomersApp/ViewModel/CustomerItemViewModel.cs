using WiredBrainsCoffee.CustomersApp.Model;

namespace WiredBrainsCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set
            {
                if (value == _model.FirstName) return;
                _model.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                if (value == _model.LastName) return;
                _model.LastName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                if (value == _model.IsDeveloper) return;
                _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }
    }
}
