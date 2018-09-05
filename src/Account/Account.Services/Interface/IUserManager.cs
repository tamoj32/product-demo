using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Services.Interface
{
    public interface IUserManager
    {
        User FindUser(string userName, string password);
    }
}
