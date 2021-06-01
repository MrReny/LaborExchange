using System.Threading.Tasks;
using LaborExchange.Commons;
using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    public class LaborExchangeHub: StreamingHubBase<ILaborExchangeHub, ILaborExchangeHubReciever>, ILaborExchangeHub
    {
        public async Task<bool> Login(string login, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}