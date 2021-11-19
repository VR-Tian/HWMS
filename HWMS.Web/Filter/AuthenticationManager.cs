
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
    /// 身份验证方案的处理程序
    /// </summary>
    public class AuthenticationManager : IAuthenticationHandler
    {
        ///TODO：关于其他身份验证方案的处理程序（Base,Bearer,JWT）
        ///
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