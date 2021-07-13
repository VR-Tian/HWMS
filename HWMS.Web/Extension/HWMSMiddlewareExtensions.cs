using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWMS.Web.Extension
{
    /// <summary>
    /// 注册中间件拓展
    /// </summary>
    public static class HWMSMiddlewareExtensions
    {
        /// <summary>
        /// 使用自定义身份授权
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIsAuthorized(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            return builder.UseMiddleware<IsAuthorizedMiddleware>();
        }

        /// <summary>
        /// 使用记录请求日志
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRecordRequestLog(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
