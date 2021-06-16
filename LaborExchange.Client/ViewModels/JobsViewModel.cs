using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LaborExchange.Commons;
using NLog;

namespace LaborExchange.Client
{
    public class JobsViewModel:ViewModelBase
    {
        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

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

        private Job _selectedJob;

        public Job SelectedJob
        {
            get => _selectedJob;
            set
            {
                if(_selectedJob == value) return;
                _selectedJob = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public DelegateCommand UpdateJobsCollectionCommand => new DelegateCommand(async () => await PullJobs());

        public DelegateCommand MakeOfferCommand => new DelegateCommand(async () => await PullJobs());

        #endregion

        public JobsViewModel()
        {
            Name = "Вакансии";
            Task.Run(PullJobs);
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
                _logger.Error(e);
            }

        }

        public async Task MakeOffer()
        {
            try
            {
                var a = await Connector.Instance.GetClient();
                var offer = new JobOffer()
                {
                    DateOfOffer = DateTime.Now,
                    JobId = SelectedJob.Id
                };
                var result = await a.MakeOffer(offer);
                if (result)
                {
                    //TODO
                }
                else
                {
                    //TODO
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                //TODO
            }

        }
    }
}