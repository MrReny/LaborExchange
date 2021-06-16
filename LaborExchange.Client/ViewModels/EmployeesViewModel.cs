using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LaborExchange.Commons;
using NLog;

namespace LaborExchange.Client
{
    public class EmployeesViewModel:ViewModelBase
    {

        #region Properties

        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private ObservableCollection<Employee> _employees;


        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                if(_employees == value) return;
                _employees = value;
                OnPropertyChanged();
            }
        }

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if(_selectedEmployee == value) return;
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand UpdateEmployeesCollectionCommand { get; set; }

        #endregion

        #region Ctors

        public EmployeesViewModel()
        {

            Name = "Соискатели";
            Task.Run(GetEmployees);

            UpdateEmployeesCollectionCommand = new DelegateCommand(
                async () =>
                {
                    await GetEmployees();

                });
        }

        #endregion

        public async Task GetEmployees()
        {
            try
            {
                var client = await Connector.Instance.GetClient();
                var result = await client.GetEmployees();
                Employees = new ObservableCollection<Employee>(result);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

        }


    }
}