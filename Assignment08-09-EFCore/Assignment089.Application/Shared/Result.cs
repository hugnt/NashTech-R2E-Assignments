using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment089.Application.Shared;

public class Result
{
	public bool IsSuccess { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public string Message { get; set; } = "";
	public List<string> Errors { get; set; } = [];


	public static Result ServerError() => new() { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = "Error" };
	public static Result GeneralError() => new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Error" };
	public static Result ErrorWithMessage(string message) => new() { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = message };
	public static Result Error(HttpStatusCode statusCode, string message) => new() { IsSuccess = false, StatusCode = statusCode, Message = message };


	public static Result SuccessNoContent() => new() { IsSuccess = true, StatusCode = HttpStatusCode.NoContent, Message = "Success" };
	public static Result SuccessWithMessage(string message) => new() { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = message };
	public static Result Success(string message, HttpStatusCode statusCode) => new() { IsSuccess = true, StatusCode = statusCode, Message = message };

	public static Result ErrorValidation(HttpStatusCode statusCode, IEnumerable<string> errors)
	{
		return new()
		{
			IsSuccess = false,
			StatusCode = statusCode,
			Message = errors.FirstOrDefault() ?? "Error",
			Errors = errors.ToList()
		};
	}
}

public class Result<T> : Result
{
	public T? Metadata { get; set; }

	public static Result<T> SuccessWithBody(T body) => new() { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Ok", Metadata = body };


}