using Assignment03.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Assignment03.API.Services;

public class SeriLogService : ILoggingService
{
    private readonly string _logRequestFilePath;
    private readonly string _logResponseFilePath;
    public SeriLogService(IWebHostEnvironment env)
    {
         Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("Logging/serilog.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
    public async void LogRequestInformation(LoggingRequestModel loggingRequestModel)
    {
       

        StringBuilder logMessage = new StringBuilder();
        logMessage.AppendLine($"Timestamp: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        logMessage.AppendLine($"Scheme: {loggingRequestModel.Schema}");
        logMessage.AppendLine($"Host: {loggingRequestModel.Host.Value}");
        logMessage.AppendLine($"Path: {loggingRequestModel.Path}");
        logMessage.AppendLine($"QueryString: {loggingRequestModel.QueryString}");
        logMessage.AppendLine($"Request Body: {loggingRequestModel.RequestBody}");
        logMessage.AppendLine("-----------------------------------------");


        Log.Information(logMessage.ToString());
    }

    public async void LogResponseInformation(LoggingResponseModel loggingResponseModel)
    {
        Log.Information(loggingResponseModel.ResponseBody);
    }

    public async void LogMessage(string message) => Log.Error(message);
}
