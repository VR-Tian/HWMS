using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWMS.Web.Extension
{
    public class PlatformAuthenticationMiddleware : AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public PlatformAuthenticationMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemeProvider) :base(next, schemeProvider)
        {
            _next = next;
            //_logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }
    }
}
