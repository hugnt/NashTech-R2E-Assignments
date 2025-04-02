using System.Net;

namespace Assignment04_05_MVC.Common;

public class ResultModel<T>
{
    public bool IsSuccess { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public T? Metadata { get; set; }

    public string Message { get; set; } = "";

    public static ResultModel<T> GeneralError() => new ResultModel<T> { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message ="Error", Metadata = default(T) };
	public static ResultModel<T> ErrorWithMessage(string message) => new ResultModel<T> { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = message, Metadata = default(T) };
	public static ResultModel<T> Error(string message, HttpStatusCode statusCode) => new ResultModel<T> { IsSuccess = false, StatusCode = statusCode, Message = message, Metadata = default(T) };
	public static ResultModel<T> SuccessWithBody(T body) => new ResultModel<T> { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Ok", Metadata = body };
	public static ResultModel<T> SuccessNoContent() => new ResultModel<T> { IsSuccess = true, StatusCode = HttpStatusCode.NoContent, Message = "Success", Metadata = default(T) };

}
