using MagicOnion.Server.Hubs;

namespace LaborExchange.Server
{
    public class UsersRepositoryService: IGroupRepository
    {
        public IGroup GetOrAdd(string groupName)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet(string groupName, out IGroup? @group)
        {
            throw new System.NotImplementedException();
        }

        public bool TryRemove(string groupName)
        {
            throw new System.NotImplementedException();
        }
    }
}