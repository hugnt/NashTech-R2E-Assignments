using Assignment03.API.Models;
using Assignment03.API.Services;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Assignment03.API.Middlewares
{
    public class LoggingResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILoggingService loggingService)
        {

            var originalBodyStream = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await _next(context);

                memoryStream.Seek(0, SeekOrigin.Begin);

                var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
                try
                {
                    loggingService.LogResponseInformation(new LoggingResponseModel()
                    {
                        ResponseBody = responseBody
                    });
                }
                catch (Exception e)
                {
                    loggingService.LogMessage(e.Message);
                }
                
                
                memoryStream.Seek(0, SeekOrigin.Begin);
                await memoryStream.CopyToAsync(originalBodyStream);
            }
            
        }

    }
}
