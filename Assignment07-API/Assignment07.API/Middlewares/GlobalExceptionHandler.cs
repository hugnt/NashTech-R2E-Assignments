using Assignment07.Application.Common.Exceptions;
using Assignment07.Domain.Shared;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assignment07.API.Middlewares;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
	private readonly ILogger<GlobalExceptionHandler> _logger;

	public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
	{
		_logger = logger;
	}

	public async ValueTask<bool> TryHandleAsync(
		HttpContext httpContext,
		Exception exception,
		CancellationToken cancellationToken)
	{
		_logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

		var statusCode = GetExceptionStatusCode(exception);
		httpContext.Response.StatusCode = statusCode;
		httpContext.Response.ContentType = "application/json";
	
		var errors = exception.Message.Split(",");
		var errorResponse = Result.ErrorWithMessage("Error existed!");
		if (errors.Length > 0)
		{
			errorResponse = Result.ErrorValidation((HttpStatusCode)statusCode, errors);
		}
		else
		{
			errorResponse = Result.Error(exception.Message, (HttpStatusCode)statusCode);
		}
		

		await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

		return true;
	}


	private int GetExceptionStatusCode(Exception exception)
	{
		return exception switch
		{
			ObjectNotExistedException => 404,
			ValidationException => 400,
			_ => 500
		};
	}

}
