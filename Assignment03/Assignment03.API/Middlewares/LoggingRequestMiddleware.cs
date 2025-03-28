using Assignment03.API.Models;
using Assignment03.API.Services;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Assignment03.API.Middlewares
{
    public class LoggingRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILoggingService loggingService)
        {
            var requestBody = "";
            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            loggingService.LogRequestInformation(new LoggingRequestModel()
            {
                Schema = context.Request.Scheme,
                Host = context.Request.Host,
                Path = context.Request.Path,
                QueryString = context.Request.QueryString,
                RequestBody = requestBody
            });

            await _next(context);

        }

    }
}
