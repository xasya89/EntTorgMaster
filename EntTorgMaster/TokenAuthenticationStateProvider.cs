using EntTorgMaster.Infrastructure;
using EntTorgMaster.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EntTorgMaster
{
    public class TokenAuthenticationStateProvider: AuthenticationStateProvider
    {
        public static int UserId;
        ILocalStorageService _storage;
        public TokenAuthenticationStateProvider(ILocalStorageService storage)
            => _storage = storage;
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState returnAnonimus()
            {
                var claimIdentity = new ClaimsIdentity();
                var anonimusPrincipal = new ClaimsPrincipal(claimIdentity);
                return new AuthenticationState(anonimusPrincipal);
            }

            var token = await _storage.GetAsync<SecurityToken>(nameof(SecurityToken));
            if (token == null)
                return returnAnonimus();
            if (string.IsNullOrEmpty(token.AccessToken) || token.ExpireAt < System.DateTime.UtcNow)
                return returnAnonimus();
            
            UserId = token.UserId;

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,token.UserName),
                new Claim(ClaimTypes.Expired, token.ExpireAt.ToLongDateString()),
                new Claim(ClaimTypes.Role, "Tester"),
                new Claim(ClaimTypes.Role,token.Role)
            };

            var identity = new ClaimsIdentity(claims, "Token");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        public void MakeAnonimys()
        {
            _storage.RemoveAsync(nameof(SecurityToken));

            var claimIdentity = new ClaimsIdentity();
            var anonimusPrincipal = new ClaimsPrincipal(claimIdentity);
            var state = Task.FromResult(new AuthenticationState(anonimusPrincipal));
            NotifyAuthenticationStateChanged(state);
        }
    }
}
