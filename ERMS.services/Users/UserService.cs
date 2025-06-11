using ERMS.core.Models;
using ERMS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMS.services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                var users = _dbContext.Users
                .Select(u =>
                new UserModel
                {
                    userID = u.UserId,
                    LastName = u.Name,
                    FirstName = u.FirstName,
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
