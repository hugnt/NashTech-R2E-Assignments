using Assignment03.API.Models;

namespace Assignment03.API.Services;

public interface ILoggingService
{
    public void LogRequestInformation(LoggingRequestModel loggingRequestModel);

    public void LogResponseInformation(LoggingResponseModel loggingResponseModel);

    public void LogMessage(string message);
}
