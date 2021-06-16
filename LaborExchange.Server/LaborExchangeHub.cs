using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using LaborExchange.Commons;
using LaborExchange.DataBaseModel;
using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    [GroupConfiguration(typeof(ConcurrentDictionaryGroupRepositoryFactory))]
    public class LaborExchangeHub: StreamingHubBase<ILaborExchangeHub, ILaborExchangeHubReciever>, ILaborExchangeHub
    {
        private IGroup _group;
        private IInMemoryStorage<User> _users => _group.GetInMemoryStorage<User>();
        private readonly ConcurrentDictionary<Guid, User> _loginnedUsers = new ConcurrentDictionary<Guid, User>();

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
            _loginnedUsers.TryAdd(ConnectionId, user);
            _group.GetInMemoryStorage<User>().Set(ConnectionId, user);
            return user;

        }


        public async Task<bool> Logout()
        {
            var asd = _group.GetInMemoryStorage<User>();
            var user = _users?.Get(ConnectionId);
            if (user == null) return false;
            _users.Remove(ConnectionId);
            return true;
        }

        public async Task<Employee[]> GetEmployees()
        {
            var user = _users?.Get(ConnectionId);
            if (user is not {UserType: UserType.Employer}) return new Employee[0];

            return _dbConnector.GetEmployees();
        }

        public async Task<Job[]> GetJobs()
        {
            return _dbConnector.GetJobs();
        }

        public async Task<bool> MakeOffer(JobOffer offer)
        {
            var user = _users?.Get(ConnectionId);
            if (user == null) return false;
            else if(user.UserType == UserType.Employer)
            {
                offer.Initiator = OfferInitiator.Employer;

            }
            else if(user.UserType == UserType.Employee)
            {
                offer.Initiator = OfferInitiator.Employee;
                offer.EmployeeId = user.UserId;
            }

            return _dbConnector.AddOffer(offer);
        }

        public Task<bool> ReturnOffer(JobOffer offer)
        {
            throw new System.NotImplementedException();
        }
    }
}