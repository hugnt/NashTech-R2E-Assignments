namespace Assignment03.API.Models
{
    public class APIResponseModel<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T Metadata { get; set; }
        public List<string> Message { get; set; }
       
    }
}
