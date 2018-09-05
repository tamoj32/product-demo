using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Account.Domain.Interfaces;
using Account.Services;
using Microsoft.Owin.Security.OAuth;
using Ninject.Modules;
using ProductService.TokenProvider.API.JwtProvider;
using ProductService.TokenProvider.API.Provider;

namespace ProductService.TokenProvider.API.Ninject
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Bind<IOAuthAuthorizationServerOptions>()
                .To<MyOAuthAuthorizationServerOptions>();
            Bind<IOAuthAuthorizationServerProvider>()
                .To<MyAuthorizationServerProvider>();

            var modules = new List<INinjectModule>
                {
                    new AccountDependencyResolution(),
                };
            Kernel.Load(modules);
        }

    }
}