using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Response;

public class Result<T>
{
    public bool IsSuccess { get; set; }
	public HttpStatusCode StatusCode { get; set; }
    public T? Metadata { get; set; }
    public string Message { get; set; } = "";

	public static Result<T> GeneralError() => new Result<T> { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = "Error", Metadata = default(T) };
	public static Result<T> ErrorWithMessage(string message) => new Result<T> { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = message, Metadata = default(T) };
	public static Result<T> Error(string message, HttpStatusCode statusCode) => new Result<T> { IsSuccess = false, StatusCode = statusCode, Message = message, Metadata = default(T) };
	public static Result<T> SuccessWithBody(T body) => new Result<T> { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Ok", Metadata = body };
	public static Result<T> SuccessNoContent() => new Result<T> { IsSuccess = true, StatusCode = HttpStatusCode.NoContent, Message = "Success", Metadata = default(T) };
	public static Result<T> SuccessWithMesage(string message) => new Result<T> { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = message, Metadata = default(T) };
	public static Result<T> Success(string message, HttpStatusCode statusCode) => new Result<T> { IsSuccess = true, StatusCode = statusCode, Message = message, Metadata = default(T) };
}
