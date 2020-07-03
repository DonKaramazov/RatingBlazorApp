using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RatingBlazorApp.Data
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //ClaimsIdentity identity = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name,"david")
            //},"sqlserverauth_type");

            ClaimsIdentity identity = new ClaimsIdentity();

            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string emailAdress)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,emailAdress)
            }, "sqlserverauth_type");

            ClaimsPrincipal user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
