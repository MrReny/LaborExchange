using System;
using System.Windows;
using LaborExchange.Commons;
using NLog;

namespace LaborExchange.Client
{
    public class MainWindowViewModel:ViewModelBase
    {
        #region Properties

        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private ViewModelBase _currentViewModel;

        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if(_currentUser == value) return;

                _currentUser = value;
                OnPropertyChanged();
                OnPropertyChanged($"IsEmployeesTabVisible");
            }
        }

        public LoginViewModel LoginViewModel { get; set; }

        public EmployeesViewModel EmployeesViewModel { get; set; }

        public JobsViewModel JobsViewModel { get; set; }

        public ResourceEditorViewModel StyleEditViewModel { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if(_currentViewModel == value) return;

                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public Visibility IsEmployeesTabVisible =>
            CurrentUser?.UserType == UserType.Employer ? Visibility.Visible : Visibility.Collapsed;



        #endregion

        #region Commands

        public DelegateCommand<ViewModelBase> ChangeViewCommand => new(SwitchToView);

        public DelegateCommand LogOutCommand => new DelegateCommand(() =>
        {
            try
            {
                Connector.Instance.Client.Logout();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
            finally
            {
                CurrentUser = null;
            }

        });

        #endregion

        public MainWindowViewModel()
        {
            LoginViewModel = new LoginViewModel(this);

            StyleEditViewModel = new ResourceEditorViewModel();

            JobsViewModel = new JobsViewModel();

            EmployeesViewModel = new EmployeesViewModel();

            CurrentViewModel = LoginViewModel;



        }

        public void SwitchToView(ViewModelBase view)
        {
            if (CurrentViewModel == LoginViewModel && this == view)
            {
                CurrentViewModel = JobsViewModel;
                return;
            }
            CurrentViewModel = view;
        }

        public void ChangeUser(User user)
        {
            CurrentUser = user;
        }
    }
}