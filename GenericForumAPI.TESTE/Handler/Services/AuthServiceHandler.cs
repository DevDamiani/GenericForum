using GenericForum.Model.Interfaces.Helpers;
using GenericForum.Model.Interfaces.Repositories;
using GenericForum.Model.Interfaces.Services;
using GenericForum.Model.Request;
using System;

namespace GenericForum.Logic.Services
{
    public class AuthServiceHandler : IAuthService
    {


        private IClientRepository _clientRepository { get; set; }
        private ITokenHelper _tokenService { get; set; }

        public AuthServiceHandler(
            IClientRepository clientRepository,
            ITokenHelper tokenService)
        {
            _clientRepository = clientRepository;
            _tokenService = tokenService;
        }


        public string AuthClient(ClientLoginRequest clientLoginRequest)
        {

            Console.WriteLine($"Client Receive! UserNAme: { clientLoginRequest.UserName }, Password: {clientLoginRequest.Password}.");

            var client = _clientRepository.ValidClient(clientLoginRequest.UserName, clientLoginRequest.Password);
            if (client == null)
                return null;

            var mToken = _tokenService.GenerateToken(client);

            Console.WriteLine($"Send Token");

            return mToken;

        }
    }
}
