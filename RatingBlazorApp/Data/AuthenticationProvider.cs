using DAL.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RatingBlazorApp.Data
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity = new ClaimsIdentity();

            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(UserModel user)
        {
            ClaimsIdentity identity = GetClaimsIdentity(user);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


        private ClaimsIdentity GetClaimsIdentity(UserModel user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            if(user.EmailAddress != null)
            {
                claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.Name, user.Nickname),
                    new Claim(ClaimTypes.PrimarySid,user.IdUse.ToString())
                }, "sqlserverauth_type");
            }

            return claimsIdentity;
        }
    }
}
