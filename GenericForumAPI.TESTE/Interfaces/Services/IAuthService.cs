using GenericForum.Model.Request;

namespace GenericForum.Model.Interfaces.Services
{
    public interface IAuthService
    {
        public string AuthClient(ClientLoginRequest clientLoginRequest);

    }
}
