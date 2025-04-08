using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment07.Domain.Shared
{
	public class Result
	{
		public bool IsSuccess { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string Message { get; set; } = "";
		public List<string> Errors { get; set; } = new();


		public static Result ServerError() => new Result { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = "Error" };
		public static Result GeneralError() => new Result { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = "Error" };
		public static Result ErrorWithMessage(string message) => new Result { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Message = message };
		public static Result Error(string message, HttpStatusCode statusCode) => new Result { IsSuccess = false, StatusCode = statusCode, Message = message };
		

		public static Result SuccessNoContent() => new Result { IsSuccess = true, StatusCode = HttpStatusCode.NoContent, Message = "Success" };
		public static Result SuccessWithMessage(string message) => new Result { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = message };
		public static Result Success(string message, HttpStatusCode statusCode) => new Result { IsSuccess = true, StatusCode = statusCode, Message = message };

		public static Result ErrorValidation(HttpStatusCode statusCode, IEnumerable<string> errors)
		{
			return new Result
			{
				IsSuccess = false,
				StatusCode = statusCode,
				Message = "Error",
				Errors = errors.ToList()
			};
		}
	}

	public class Result<T> : Result
	{
		public T? Metadata { get; set; }

		public static Result<T> SuccessWithBody(T body) => new Result<T> { IsSuccess = true, StatusCode = HttpStatusCode.OK, Message = "Ok", Metadata = body };

		
	}

}
