using Account.Domain.Entities;
using Account.Domain.Interfaces;
using Account.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
            Setup();
        }

		//Temporary Data Setup for demo
        private void Setup()
        {
            
            var userList = new List<User>
            {
                new User {Id = 1, UserName = "admin", Password="admin123", Role = "administrator"},
                new User {Id = 2, UserName = "supervisor", Password="super123", Role = "supervisor"}
            };

            _dbContext.Users.AddRange(userList);
            _dbContext.SaveChanges();
        }

        public User FindUser(string userName, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }
    }
}
