using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Persistence.Repositories
{
    public class TopicRepository : BaseRepository<TopicEntity>, ITopicRepository
    {
        public TopicRepository(ForumGenericContext forumGenericContext) : base(forumGenericContext) { }

        public TopicEntity GetTopicWithCommentsAndClients(int id)
        {

            return DbSet.Where(t => t.ID == id)
                .Include(t => t.Client)
                .Include(t => t.Comments)
                .ThenInclude(c => c.Client)
                .FirstOrDefault();
        }

        

        public IEnumerable<TopicEntity> GetInRangeTopicsByOrderDateDecrescent(int pagina, int quantidade)
        {
            return DbSet
                .OrderByDescending(t => t.CreationDate)
                .Skip(pagina * quantidade)
                .Take(quantidade)
                .Include(t => t.Client)
                .ToList();
        }



        public IEnumerable<TopicEntity> GetinRangeTopicsByFilterWordsinTitle(int quantidade, string filter)
        {
            return DbSet
                .Where(t => t.Title.Contains(filter))
                .OrderByDescending(t => t.CreationDate)
                .Take(quantidade)
                .Include(t => t.Client)
                .ToList();
        }
    }
}
