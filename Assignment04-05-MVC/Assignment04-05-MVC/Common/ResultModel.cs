using System.Net;

namespace Assignment04_05_MVC.Common;


public enum ErrorCode
{
	NoError,
	Validation,
	CheckExisted
}

public class Result
{
	public bool IsSuccess { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public string Message { get; set; } = "";
	public List<string> Errors { get; set; } = [];
	public ErrorCode ErrorCode { get; set; }
	public static Result Error(HttpStatusCode statusCode, string message) => new() { IsSuccess = false, StatusCode = statusCode, Message = message };
	public static Result SuccessNoContent() => new() { IsSuccess = true, StatusCode = HttpStatusCode.NoContent, Message = "Success" };
	public static Result Success(string message, HttpStatusCode statusCode) => new() { IsSuccess = true, StatusCode = statusCode, Message = message };

	public static Result ErrorValidation(HttpStatusCode statusCode, IEnumerable<string> errors)
	{
		return new()
		{
			IsSuccess = false,
			StatusCode = statusCode,
			Message = errors.FirstOrDefault() ?? "Error",
			ErrorCode = ErrorCode.Validation,
			Errors = errors.ToList()
		};
	}
}

public class Result<T> : Result
{
	public T? Metadata { get; set; }
	public static Result<T> Error(HttpStatusCode statusCode, string message) => new() { IsSuccess = false, StatusCode = statusCode, Message = message };
	public static Result<T> SuccessWithBody(T body) => new() { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Ok", Metadata = body };
}