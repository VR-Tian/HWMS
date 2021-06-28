
using System.Linq;
using System.Net;
using System.Security.Claims;
using HWMS.Application.Interfaces;
using HWMS.Web.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HWMS.Web.Filter
{
    /// <summary>
    /// 
    /// </summary>
    /// 弃用：改用自定义中间件来进行身份授权
    public class IsAuthorizedAttribute : ActionFilterAttribute
    {

        private IUserAppService _UserAppService;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _UserAppService = context.HttpContext.RequestServices.GetService<IUserAppService>();


            var isauthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
            var clima = claimsIndentity.Claims.Where(t => t.Type == "USER_ID").FirstOrDefault();
            var getuserPerissioninfo = _UserAppService.GetRolePermissionOfUser(int.Parse(clima.Value));

            var allpermissinfo = getuserPerissioninfo.Select(t => (t.ControllerName + "/" + t.ActionName).ToUpper());

            var accessRouteName = context.RouteData.Values["controller"].ToString() + "/" + context.RouteData.Values["action"].ToString();
            if (!isauthenticated || !allpermissinfo.Contains(accessRouteName.ToUpper()))
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