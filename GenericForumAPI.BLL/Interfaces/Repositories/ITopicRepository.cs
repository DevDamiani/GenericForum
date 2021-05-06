using GenericForum.Model.Entity;
using System.Collections.Generic;


namespace GenericForum.Model.Interfaces.Repositories
{
    public interface ITopicRepository : IRepository<TopicEntity>
    {

        public TopicEntity GetTopicWithCommentsAndClients(int id);
        public IEnumerable<TopicEntity> GetInRangeTopicsByOrderDateDecrescent(int pagina, int quantidade);

        public IEnumerable<TopicEntity> GetinRangeTopicsByFilterWordsinTitle(int quantidade, string filter);
        

    }
}
