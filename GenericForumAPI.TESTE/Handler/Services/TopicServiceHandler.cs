

using AutoMapper;
using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Helpers;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using GenericForum.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericForum.Logic.Services
{
    public class TopicServiceHandler : ITopicService
    {

        private ITokenHelper _tokenService { get; }
        private ITopicRepository _topicRepository { get; }
        private IClientRepository _clientRepository { get; }
        private ICommentRepository _commentRepository { get; }
        private IMapper _mapper { get; }

        public TopicServiceHandler(
            ITokenHelper tokenService, ITopicRepository topicRepository, IClientRepository clientRepository, ICommentRepository commentRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _tokenService = tokenService;
            _topicRepository = topicRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }


        public TopicResponse GetTopicByID(int id)
        {
            var topicSend = _topicRepository.GetTopicWithCommentsAndClients(id);

            if (topicSend == null)
                return null;

            var topicResponse =  _mapper.Map<TopicResponse>(topicSend);

            Console.WriteLine($"Send Topic: {topicResponse.Title}");

            return topicResponse;
        }

        public bool CreateTopic(TopicRequest topicDataModel, string token)
        {

            var tokenClient = _tokenService.DecodeToken(token);
            var client = _clientRepository.GetByID(tokenClient.ID);

            if (client == null)
                return false;

            var newTopic = _mapper.Map<TopicEntity>(topicDataModel);
            newTopic.Client = client;

            _topicRepository.Add(newTopic);

            Console.WriteLine($"Title:{topicDataModel.Title} Subtopic:{topicDataModel.Subtitle}");

            return true;
        }

        public bool CreateCommentForTopic(CommentRequest commentDataModel, string token)
        {

            var tokenClient = _tokenService.DecodeToken(token);

            var client = _clientRepository.GetByID(tokenClient.ID);

            if (client == null)
                return false;

            var topic = _topicRepository.GetByID(int.Parse(commentDataModel.TopicID));

            if (topic == null)
                return false;

            var comment = _mapper.Map<CommentEntity>(commentDataModel);
            comment.ClientId = client.ID;

            //_commentRepository.Add();

            _commentRepository.Add(comment);

            Console.WriteLine($"New Comment: {commentDataModel.CommentText} By: {client.ID} in Topic: { topic.ID }");

            return true;
        }

        public int TotalData()
        {
            return _topicRepository.TotalOfRows();
        }
        public IList<TopicBriefResponse> GetTopicsInRangeByOrderDateDecrescent(int pag, int count)
        {

            pag--;

            var topicos = _topicRepository.GetInRangeTopicsByOrderDateDecrescent(pag, count);

            var topicBriefList = topicos
                .Select(t => _mapper.Map<TopicBriefResponse>(t))
                .ToList();

            Console.WriteLine("Send Topics By Order Decrescent");

            return topicBriefList;

        }
        public IList<TopicBriefResponse> GetinRangeTopicsByFilterWordsinTitle(int count, string filter)
        {


            var topicos =  _topicRepository.GetinRangeTopicsByFilterWordsinTitle(count, filter);

            var topicBriefList = topicos
                .Select(t => _mapper.Map<TopicBriefResponse>(t))
                .ToList();

            Console.WriteLine("Send Topics Filtred By Order Decrescent");

            return topicBriefList;
        }

    }
}
