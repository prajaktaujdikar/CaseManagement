using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CaseManagementSystem.Data.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal user;

        public async Task AuthenticateUserAsync(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var identity = new ClaimsIdentity(claims, "custom");
            user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task LogoutUserAsync()
        {
            user = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(user));
        }

        public bool IsAuthenticated()
        {
            try
            {
                return (user?.Identity?.IsAuthenticated ?? false);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RoleType()
        {
            try
            {
                IEnumerable<Claim> roleClaims = user?.Claims?.Where(c => c.Type == ClaimTypes.Role);
                return roleClaims?.FirstOrDefault()?.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string UserName()
        {
            try
            {
                IEnumerable<Claim> nameClaims = user?.Claims?.Where(c => c.Type == ClaimTypes.Name);
                return nameClaims?.FirstOrDefault()?.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
