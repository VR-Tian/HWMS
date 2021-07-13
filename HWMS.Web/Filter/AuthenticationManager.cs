
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using HWMS.Web.Extension;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HWMS.Web.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationManager<T> : IAuthenticationHandler where T: AuthenticationSchemeOptions,new()
    {

      
        ///TODO：如何启用身份认证方案（Base,Bearer）
        public Task<AuthenticateResult> AuthenticateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            throw new System.NotImplementedException();
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            throw new System.NotImplementedException();
        }

        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            throw new System.NotImplementedException();
        }

    }

}