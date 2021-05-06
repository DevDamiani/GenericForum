using GenericForum.Model.Entity;

namespace GenericForum.Model.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        public ClientEntity GetClientAndProfile(int id);
        public ClientEntity GetByUserName(string name);
        public ClientEntity ValidClient(string name, string password);

    }
}
