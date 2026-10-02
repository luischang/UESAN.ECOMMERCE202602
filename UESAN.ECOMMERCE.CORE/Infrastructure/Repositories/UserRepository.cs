using Microsoft.EntityFrameworkCore;
using UESAN.ECOMMERCE.CORE.Core.Entities;
using UESAN.ECOMMERCE.CORE.Core.Interfaces;
using UESAN.ECOMMERCE.CORE.Infrastructure.Data;

namespace UESAN.ECOMMERCE.CORE.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext
                        .User
                        .Where(u => u.Email == email && u.IsActive == true)
                        .FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> CreateUser(User user)
        {
            user.IsActive = true;
            await _dbContext.User.AddAsync(user);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
