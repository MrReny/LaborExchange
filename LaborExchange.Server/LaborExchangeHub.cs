using System.Collections.Concurrent;
using System.Threading.Tasks;
using LaborExchange.Commons;
using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    public class LaborExchangeHub: StreamingHubBase<ILaborExchangeHub, ILaborExchangeHubReciever>, ILaborExchangeHub
    {
        private ConcurrentDictionary<string, User> _loginnedUsers;



        public async Task<bool> Login(string login, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}