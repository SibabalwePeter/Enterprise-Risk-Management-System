using ERMS.core.Models;

namespace ERMS.services.Users
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetUsers();
    }
}
