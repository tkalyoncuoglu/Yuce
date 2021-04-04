using DAL.Abstract;
using DAL.Concrete;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace Yuce.App_Start
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {
    

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var authRepository = NinjectWebCommon.GetInstance<IUserRepository>();
            var user = await authRepository.ValidateUser(context.UserName,
            context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", context.UserName));
                identity.AddClaim(new Claim("Password", context.Password));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is      incorrect.");
                return;
            }
        }
    }
}