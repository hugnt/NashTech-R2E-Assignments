namespace Assignment03.API.Models
{
    public class LoggingRequestModel
    {
        public string Schema { get; set; }
        public HostString Host { get; set; }
        public string Path { get; set; }
        public QueryString QueryString { get; set; }
        public string RequestBody { get; set; }
    }

    public class LoggingResponseModel
    {
        public string ResponseBody { get; set; }
    }
}
