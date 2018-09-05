using System.Security.Claims;
using System.Threading.Tasks;
using Account.Domain.Interfaces;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace ProductService.TokenProvider.API.JwtProvider
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserRepository _userRepository;
        public MyAuthorizationServerProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = _userRepository.FindUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("username", context.UserName));
            identity.AddClaim(new Claim("permission", user.Role));

            var ticket = new AuthenticationTicket(identity, null);

            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }

}