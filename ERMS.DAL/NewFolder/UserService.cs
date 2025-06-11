using ERMS.core.Models;
using ERMS.DAL.Data;

namespace ERMS.DAL.Users
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductModel>> GetUsers()
        {
            try
            {
                var users = _dbContext.Products
                .Select(u =>
                new ProductModel
                {
                    productID = u.UserId,
                    Name = u.Name,
                    Description = u.FirstName,
                })
                .ToList();
                return users;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving users.", ex);
            }
        }
    }
}
