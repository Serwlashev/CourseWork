using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.ServicesShared.Core.Exceptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.API.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        public ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError($"New error occured { error.Message }");

                var innerException = error.InnerException;

                while (innerException is not null)
                {
                    _logger.LogError($"Inner exception { innerException.Message }");
                    innerException = innerException.InnerException;
                }

                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ForbiddenActionException:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case NotFoundException:
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
