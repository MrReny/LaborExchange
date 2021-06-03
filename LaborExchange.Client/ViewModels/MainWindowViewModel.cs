using LaborExchange.Client.Model;

namespace LaborExchange.Client
{
    public class MainWindowViewModel:ViewModelBase
    {
        private LoginViewModel _loginViewModel;

        public MainWindowViewModel()
        {
            _loginViewModel = new LoginViewModel();
        }
    }
}