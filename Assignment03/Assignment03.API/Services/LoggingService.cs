using Assignment03.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Assignment03.API.Services;

public class LoggingService : ILoggingService
{
    private readonly string _logRequestFilePath;
    private readonly string _logResponseFilePath;
    public LoggingService(IWebHostEnvironment env)
    {
        _logRequestFilePath = Path.Combine(env.ContentRootPath, "Logging/requests.log");
        _logResponseFilePath = Path.Combine(env.ContentRootPath, "Logging/response.log");
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


        // Write the log to a file
        await File.AppendAllTextAsync(_logRequestFilePath, logMessage.ToString());
    }

    public async void LogResponseInformation(LoggingResponseModel loggingResponseModel)
    {
        await File.AppendAllTextAsync(_logResponseFilePath, loggingResponseModel.ResponseBody);
    }

    public async void LogMessage(string message) => await File.AppendAllTextAsync(_logResponseFilePath, message);
}
