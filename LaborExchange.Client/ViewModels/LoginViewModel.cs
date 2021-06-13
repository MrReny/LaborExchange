using System;
using System.Security;
using LaborExchange.Client.Helpers;
using NLog;

namespace LaborExchange.Client
{
    public class LoginViewModel:ViewModelBase
    {

        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public string UserName { get; set; }

        [RequiredSecureString]
        public SecureString Password { get; set; }

        public DelegateCommand LoginCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        private MainWindowViewModel _parent;

        public LoginViewModel(MainWindowViewModel parent)
        {
            Name = "Войти";
            _parent = parent;
            LoginCommand = new DelegateCommand(
                async () =>
                {
                    try
                    {
                        if (Connector.Instance.Client is null) await Connector.Instance.Connect();
                        var user = await Connector.Instance.Client.Login(UserName, Password.ToUnsecuredString());
                        if( user != null)
                        {
                            _parent.ChangeUser(user);
                            _parent.SwitchToView(_parent);
                        }
                        else
                        {
                            //TODO
                        }
                    }
                    catch (Exception e)
                    {
                        //TODO
                        Console.WriteLine(e);
                    }

                });

            CancelCommand = new DelegateCommand(() =>
            {
                //TODO
            });
        }

    }
}