using HWMS.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HWMS.API.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public class MinimumAgeRequirement : AuthorizationHandler<ClaimsAuthorizationRequirement>, IAuthorizationRequirement
    {
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
        public int MinimumAge { get; private set; }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
        {

            return Task.CompletedTask;
        }
    }
}
