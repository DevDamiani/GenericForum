using GenericForum.Model.Entity;


namespace GenericForum.Model.Interfaces.Helpers
{
    public interface ITokenHelper
    {
        public string GenerateToken(ClientEntity client);
        public ClientEntity DecodeToken(string tokenString);
    }
}