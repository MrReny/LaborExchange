using System;
using System.Security;
using LaborExchange.Client.Helpers;
using LaborExchange.Client.Model;
using Prism.Commands;

namespace LaborExchange.Client
{
    public class LoginViewModel:ViewModelBase
    {
        public string UserName { get; set; }

        [RequiredSecureString]
        public SecureString Password { get; set; }

        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(
                async () =>
                {
                    try
                    {
                        if (Connector.Instance.Client is null) await Connector.Instance.Connect();
                        if(await Connector.Instance.Client.Login(UserName, Password.ToUnsecuredString()))
                        {
                            //TODO
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                });
        }

    }
}