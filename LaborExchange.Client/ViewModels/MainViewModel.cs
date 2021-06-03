using System.Collections.Generic;

namespace LaborExchange.Client
{
    public class MainViewModel:ViewModelBase
    {
        public ViewModelBase LoginView { get; set; }

        public ViewModelBase CurrentView { get; set; }

        public MainViewModel()
        {

        }
    }
}