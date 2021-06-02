using System.Collections.Concurrent;
using System.Threading.Tasks;
using MagicOnion;

namespace LaborExchange.Commons
{
    public interface ILaborExchangeHub:IStreamingHub<ILaborExchangeHub, ILaborExchangeHubReciever>
    {
        Task<bool> Login(string login, string password);
    }
}