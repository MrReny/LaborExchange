using System.Reactive;
using ReactiveUI;

namespace LaborExchange.Client
{
    public class LoginViewModel:ViewModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public ReactiveCommand<Unit, bool> TryLogin;
    }
}