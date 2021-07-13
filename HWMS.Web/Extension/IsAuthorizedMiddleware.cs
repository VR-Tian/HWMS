using System.Threading.Tasks;
using HWMS.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HWMS.Web.Extension
{
    /// <summary>
    /// 身份授权中间件
    /// </summary>
    public class IsAuthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public IsAuthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
            //_logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>()
        }

        public async Task Invoke(HttpContext context, IConfiguration configuration, ILogger<IsAuthorizedMiddleware> logger, IUserAppService service)
        {
            // Do something with context near the beginning of request processing.
            await _next.Invoke(context);

            // Clean up.
        }
    }
}