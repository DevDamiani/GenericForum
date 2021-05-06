using GenericForum.Model.Response;

namespace GenericForum.Model.Interfaces.Services
{
    public interface IProfileService
    {

        public ProfileResponse GetProfileByID(int id);
    }
}
