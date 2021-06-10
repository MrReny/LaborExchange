using ReactiveUI;

namespace LaborExchange.Client
{
    public class MainWindowViewModel:ViewModelBase
    {
        public LoginViewModel LoginViewModel { get; set; }

        public  MainViewModel MainViewModel { get; set; }
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
        }

        public MainWindowViewModel()
        {
            MainViewModel = new MainViewModel();
            LoginViewModel = new LoginViewModel();
            CurrentViewModel = LoginViewModel;
        }
    }
}