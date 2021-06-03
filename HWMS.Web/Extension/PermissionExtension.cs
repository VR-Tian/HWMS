using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace HWMS.Web.Extension
{
    public static class PermissionExtension
    {
        public static bool HavePermission(this ControllerBase c, string claimValue)
        {
            var user = c.HttpContext.User as ClaimsPrincipal;
            bool havePer = user.HasClaim(claimValue, claimValue);
            return havePer;
        }
        public static bool HavePermission(this IIdentity claims, string claimValue)
        {
            var userClaims = claims as ClaimsIdentity;
            bool havePer = userClaims.HasClaim(claimValue, claimValue);
            return havePer;
        }
    }
}