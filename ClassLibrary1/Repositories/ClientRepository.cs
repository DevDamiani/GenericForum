
using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(ForumGenericContext forumGenericContext) : base(forumGenericContext) { }

        public ClientEntity GetByUserName(string name)
        {
            return DbSet.FirstOrDefault(c => c.UserName == name);
        }

        public ClientEntity GetClientAndProfile(int id) 
        {
            return DbSet
                .Where(c => c.ID == id)
                .Include(c => c.Profile)
                .Include(c => c.Topics)
                .ThenInclude(t => t.Client)
                .FirstOrDefault();

        }

        public ClientEntity ValidClient(string name, string password)
        {

            return DbSet
                .Where(c => c.UserName == name && c.Password == password)
                .FirstOrDefault();

        }



    }
}
