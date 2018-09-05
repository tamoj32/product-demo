using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using ProductService.TokenProvider.API.Provider;

namespace ProductService.TokenProvider.API.JwtProvider
{
    public interface IOAuthAuthorizationServerOptions
    {
        OAuthAuthorizationServerOptions GetOptions();
    };

    public class MyOAuthAuthorizationServerOptions : IOAuthAuthorizationServerOptions
    {
        private readonly IOAuthAuthorizationServerProvider _provider;

        public MyOAuthAuthorizationServerOptions(IOAuthAuthorizationServerProvider provider)
        {
            _provider = provider;
        }
        public OAuthAuthorizationServerOptions GetOptions()
        {
            return new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //TODO: HTTPS
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = _provider,
                AccessTokenFormat = new CustomJwtFormat()
            };
        }
    }
}