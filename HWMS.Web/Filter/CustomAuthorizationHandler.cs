using HWMS.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HWMS.API.Filter
{
    /// <summary>
    /// 实现自定义授权认证逻辑
    /// </summary>
    /// <remarks>
    /// 动态控制业务API的授权策略
    /// </remarks>
    public class CustomAuthorizationHandler : IAuthorizationService
    {
        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
        {
            throw new NotImplementedException();
        }
    }
}
