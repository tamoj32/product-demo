using Account.Domain.Entities;
using Account.Domain.Interfaces;
using Account.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRespository)
        {
            _userRepository = userRespository;
        }

        public User FindUser(string userName, string password)
        {
            return _userRepository.FindUser(userName, password);
        }
    }
}
