using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LaborExchange.Commons;

namespace LaborExchange.Client
{
    public class JobsViewModel:ViewModelBase
    {
        private ObservableCollection<Job> _jobs;

        public ObservableCollection<Job> Jobs
        {
            get => _jobs;
            set
            {
                if(_jobs == value) return;
                _jobs = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public DelegateCommand UpdateJobsCollectionCommand { get; set; }

        #endregion

        public JobsViewModel()
        {
            Name = "Вакансии";
            Task.Run(PullJobs);

            UpdateJobsCollectionCommand = new DelegateCommand(async () => await PullJobs());
        }

        public async Task PullJobs()
        {
            try
            {
                var a = await Connector.Instance.GetClient();
                Jobs = new ObservableCollection<Job>(await a.GetJobs());
            }
            catch (Exception e)
            {

            }

        }
    }
}