using System.Collections.ObjectModel;
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

        private User CurrentUser { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

        public EmployeesViewModel EmployeesViewModel { get; set; }

        public JobsViewModel JobsViewModel { get; set; }

        public ResourceEditorViewModel StyleEditViewModel { get; set; }

        public ObservableCollection<ViewModelBase> ViewModels { get; set; } = new ObservableCollection<ViewModelBase>();

        private ViewModelBase _currentViewModel;

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

        #endregion

        #region Commands

        public DelegateCommand<ViewModelBase> ChangeViewCommand => new(SwitchToView);

        #endregion

        public MainWindowViewModel()
        {
            var res = new ResourceEditorViewModel();

            LoginViewModel = new LoginViewModel(this);


            StyleEditViewModel = new ResourceEditorViewModel();

            JobsViewModel = new JobsViewModel();

            ViewModels.Add(JobsViewModel);

            CurrentViewModel = LoginViewModel;

        }

        public void SwitchToView(ViewModelBase view)
        {
            CurrentViewModel = view;
        }

        public void ChangeUser(User user)
        {
            CurrentUser = user;
        }
    }
}