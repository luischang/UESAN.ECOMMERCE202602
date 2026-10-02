using UESAN.ECOMMERCE.CORE.Core.Entities;

namespace UESAN.ECOMMERCE.CORE.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
        Task<bool> CreateUser(User user);
    }
}
