using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using LaborExchange.Commons;
using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    [GroupConfiguration(typeof(ConcurrentDictionaryGroupRepositoryFactory))]
    public class LaborExchangeHub : StreamingHubBase<ILaborExchangeHub, ILaborExchangeHubReciever>, ILaborExchangeHub
    {
        private IGroup _group;
        private IInMemoryStorage<User> Users => _group.GetInMemoryStorage<User>();
        private readonly ConcurrentDictionary<Guid, User> _loggedUsers = new();

        private DbConnector _dbConnector => DbConnector.Instance;

        public LaborExchangeHub()
        {
            _dbConnector.Init();
        }

        public async Task<User> Login(string login, string password)
        {
            //TODO Разобраться с группами и тд
            var user = _dbConnector.GetUser(login, password);

            if (user == null) return null;

            _group = await Group.AddAsync(ConnectionId.ToString());
            _loggedUsers.TryAdd(ConnectionId, user);
            _group.GetInMemoryStorage<User>().Set(ConnectionId, user);
            return user;
        }

        public async Task<bool> Logout()
        {
            var _ = _group.GetInMemoryStorage<User>();
            var user = Users?.Get(ConnectionId);
            if (user == null) return false;
            Users.Remove(ConnectionId);
            return true;
        }

        public async Task<Employee[]> GetEmployees()
        {
            var user = Users?.Get(ConnectionId);
            if (user is not { UserType: UserType.Employer }) return Array.Empty<Employee>();

            return await _dbConnector.GetEmployees();
        }

        public async Task<Job[]> GetJobs()
        {
            return await _dbConnector.GetJobs();
        }

        public async Task<bool> MakeOffer(JobOffer offer)
        {
            var user = Users?.Get(ConnectionId);
            if (user == null) return false;

            switch (user.UserType)
            {
                case UserType.Employer:
                    offer.Initiator = OfferInitiator.Employer;
                    break;
                case UserType.Employee:
                    offer.Initiator = OfferInitiator.Employee;
                    offer.EmployeeId = user.UserId;
                    break;
            }

            return await _dbConnector.AddOffer(offer);
        }

        public Task<bool> ReturnOffer(JobOffer offer)
        {
            throw new NotImplementedException();
        }
    }
}