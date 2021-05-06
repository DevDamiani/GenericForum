using GenericForum.Model.Request;



namespace GenericForum.Model.Interfaces.Services
{
    public interface IClientService
    {
        public bool CreateClient(CreateClientRequest clientRequest);
        public bool UserNameIsTaken(ClientUserNameRequest data);
    }
}
