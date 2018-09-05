using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Account.Domain.Interfaces;
using Account.Infrastructure.Data.Repository;
using Account.Services.Implementation;
using Account.Services.Interface;

namespace Account.Services
{
    public class AccountDependencyResolution : NinjectModule
    {
        public override void Load()
        {
            Bind<UserContext>().ToSelf();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IUserManager>().To<UserManager>();
        }
    }
}
