using AutoMapper;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Response;
using System.Linq;

namespace GenericForum.Logic.Services
{
    public class ProfileServiceHandler : IProfileService
    {

        private IClientRepository _clientRepository { get; }
        private IMapper _mapper { get; }

        public ProfileServiceHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public ProfileResponse GetProfileByID(int id)
        {

            var client = _clientRepository.GetClientAndProfile(id);

            if (client == null)
                return null;

            var profile = _mapper.Map<ProfileResponse>(client);

            profile.TopicBrief = profile.TopicBrief
                .OrderByDescending(t => t.Date)
                .ToList();

            return profile;
        }

    }
}
