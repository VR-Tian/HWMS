using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HWMS.Web.Extension
{
    public class IsAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public IsAuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserAppService service)
        {
            // Do something with context near the beginning of request processing.
            await _next.Invoke(context);

            // Clean up.
        }
    }

    public static class MyMiddlewareExtensions
    {
        /// <summary>
        /// 身份授权
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIsAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IsAuthorizedMiddleware>();
        }
    }
}