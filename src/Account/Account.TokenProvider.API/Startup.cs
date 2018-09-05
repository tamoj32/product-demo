using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ProductService.TokenProvider.API.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Account.Domain.Interfaces;
using Microsoft.Owin.Security.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using ProductService.TokenProvider.API.JwtProvider;

[assembly: OwinStartup(typeof(ProductService.TokenProvider.API.Startup))]
namespace ProductService.TokenProvider.API
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            var kernel = CreateKernel();
            app.UseNinjectMiddleware(() => kernel).UseNinjectWebApi(config);

            ConfigureOAuth(app, kernel);

        }

        public void ConfigureOAuth(IAppBuilder app, IKernel kernel)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            // Token Generation
            app.UseOAuthAuthorizationServer(
                kernel.Get<MyOAuthAuthorizationServerOptions>().GetOptions());
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }


    }

    //public class NinjectConfig : NinjectModule
    //{
    //    public override void Load()
    //    {
    //        RegisterServices();
    //    }

    //    private void RegisterServices()
    //    {
    //        Bind<IOAuthAuthorizationServerOptions>()
    //            .To<MyOAuthAuthorizationServerOptions>();
    //        Bind<IOAuthAuthorizationServerProvider>()
    //            .To<MyAuthorizationServerProvider>();
    //        Bind<IUserRepository>().To<UserRepository>();
    //    }
    //}
}