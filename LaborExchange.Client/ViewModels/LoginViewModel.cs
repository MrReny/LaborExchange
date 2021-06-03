using System.Reactive;
using ReactiveUI;

using System.Reactive;
using System.Windows.Markup;
using LaborExchange.Client.Model;
using ReactiveUI;

namespace LaborExchange.Client
{
    public class LoginViewModel:ViewModelBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; set; }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.CreateFromTask<Unit, Unit>(
                async (a) =>
                {
                    await Connector.Instance.Client.Login(UserName, Password);
                    return Unit.Default;
                });
        }

    }
}