using AutoMapper;
using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using System;

namespace GenericForum.Logic.Services
{
    public class ClientServiceHandler : IClientService
    {
        

        public ClientServiceHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;


        }

        private IClientRepository _clientRepository { get; }
        private IMapper _mapper { get; }

        public bool CreateClient(CreateClientRequest clientRequest)
        {
            var client = _clientRepository.GetByUserName(clientRequest.UserName);

            if (client != null)
                return false;

            _clientRepository.Add(_mapper.Map<ClientEntity>(clientRequest));

            Console.WriteLine($"New User Create! Name: { clientRequest.UserName }, Email: { clientRequest.EmailAddress }, Password: { clientRequest.Password }.");

            return true;
        }

        public bool UserNameIsTaken(ClientUserNameRequest data)
        {
            Console.WriteLine(data.UserName);

            var client = _clientRepository.GetByUserName(data.UserName);

            if (client == null)
                return false;

            return true;
        }


    }
}
