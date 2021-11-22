
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace HWMS.API.Filter
{
    /// <summary>
    /// 系统重写的Cookie身份验证
    /// </summary>
    /// <remarks>CookieAuthenticationHandler,</remarks>
    public class HWMSAuthenticationHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
    {
        public AuthenticationScheme Scheme { get; private set; }
        protected HttpContext Context { get; private set; }

        public Task<AuthenticateResult> AuthenticateAsync()
        {
            var cookie = Context.Request.Cookies["myCookie"];
            if (string.IsNullOrEmpty(cookie))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }
            return Task.FromResult(AuthenticateResult.Success(Deserialize(cookie)));
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.Redirect("/login");
            return Task.CompletedTask;
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return Task.CompletedTask;
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            Scheme = scheme;
            Context = context;
            return Task.CompletedTask;
        }

        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var ticket = new AuthenticationTicket(user, properties, Scheme.Name);
            Context.Response.Cookies.Append("myCookie", Serialize(ticket));
            return Task.CompletedTask;
        }
        public Task SignOutAsync(AuthenticationProperties properties)
        {
            Context.Response.Cookies.Delete("myCookie");
            return Task.CompletedTask;
        }


        private string Serialize(AuthenticationTicket ticket)
        {
            return Guid.NewGuid().ToString();
        }

        private AuthenticationTicket Deserialize(string cookie)
        {
            throw new System.NotImplementedException();
        }

    }

}