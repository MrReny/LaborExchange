using System.Threading.Tasks;
using MagicOnion;

namespace LaborExchange.Commons
{
    public interface ILaborExchangeHub:IStreamingHub<ILaborExchangeHub, ILaborExchangeHubReciever>
    {
        Task<User> Login(string login, string password);

        Task<bool> Logout();

        Task<Employee[]> GetEmployees();

        Task<Job[]> GetJobs();

        Task<bool> MakeOffer(JobOffer offer);

        Task<bool> ReturnOffer(JobOffer offer);

    }
}