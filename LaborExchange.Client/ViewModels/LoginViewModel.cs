using System;
using System.Security;
using LaborExchange.Client.Helpers;
using LaborExchange.Client.Services;
using LaborExchange.Commons;
using NLog;
using Splat;
using ToastNotifications.Messages;

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
                            Locator.Current.GetService<INotificationService>()?.ShowSuccess($"Добро пожаловать {UserName}");
                        }
                        else
                        {
                            Locator.Current.GetService<INotificationService>()?.ShowError("Неверные логин или пароль");
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e);
                        Locator.Current.GetService<INotificationService>()?.ShowError("Нет соединения с сервером");
                    }

                });

            CancelCommand = new DelegateCommand(() =>
            {
                _parent.SwitchToView(this);
            });
        }

    }
}