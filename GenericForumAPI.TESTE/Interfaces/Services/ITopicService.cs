using GenericForum.Model.Request;
using GenericForum.Model.Response;
using System.Collections.Generic;

namespace GenericForum.Model.Interfaces.Services
{
    public interface ITopicService
    {
        bool CreateCommentForTopic(CommentRequest commentDataModel, string token);
        bool CreateTopic(TopicRequest topicDataModel, string token);
        TopicResponse GetTopicByID(int id);
        public int TotalData();
        public IList<TopicBriefResponse> GetTopicsInRangeByOrderDateDecrescent(int pagina, int quantidade);
        public IList<TopicBriefResponse> GetinRangeTopicsByFilterWordsinTitle(int count, string filter);




    }
}