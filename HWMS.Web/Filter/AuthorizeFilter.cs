
using System.Linq;
using System.Net;
using System.Security.Claims;
using HWMS.Web.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HWMS.Web.Filter
{

    public class IsAuthorized : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isauthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (!isauthenticated)
            {
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    context.HttpContext.Response.StatusCode =
                      (int)HttpStatusCode.Forbidden; //Set HTTP 403 - JRozario
                }
                else
                {
                    context.Result = new RedirectResult("~/NoPermission.html");
                }
            }
            
            base.OnActionExecuting(context);
        }



    }
    // public class AuthorizeAttribute : TypeFilterAttribute
    // {
    //     public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
    //     {
    //         Arguments = new object[] { claim };
    //     }
    // }

    // public class AuthorizeFilter : IAuthorizationFilter
    // {
    //     readonly string[] _claim;

    //     public AuthorizeFilter(params string[] claim)
    //     {
    //         _claim = claim;
    //     }

    //     public void OnAuthorization(AuthorizationFilterContext context)
    //     {
    //         var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
    //         var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;

    //         if (IsAuthenticated)
    //         {
    //             bool flagClaim = false;
    //             foreach (var item in _claim)
    //             {
    //                 if (context.HttpContext.User.HasClaim(item, item))
    //                     flagClaim = true;
    //             }
    //             if (!flagClaim)
    //                 context.Result = new RedirectResult("~/NoPermission.html");
    //         }
    //         return;
    //     }
    // }

}