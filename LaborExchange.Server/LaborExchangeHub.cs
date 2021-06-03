using System.Threading.Tasks;
using LaborExchange.Commons;
using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    public class LaborExchangeHub: StreamingHubBase<ILaborExchangeHub, ILaborExchangeHubReciever>, ILaborExchangeHub
    {
        private IGroup _group;
        public async Task<bool> Login(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Logout()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Employee[]> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Job[]> GetJobs()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> MakeOffer(Job job, Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ReturnOffer(JobOffer offer)
        {
            throw new System.NotImplementedException();
        }
    }
}