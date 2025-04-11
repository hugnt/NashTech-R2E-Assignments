using Assignment089.Application.Shared;
using Newtonsoft.Json;
using System.Net;


namespace Assignment089.API.Middlewares;

public class ResultHandlingMiddleware
{
	private readonly RequestDelegate _next;

	public ResultHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		// Bỏ qua các request đến Swagger
		if (httpContext.Request.Path.StartsWithSegments("/swagger"))
		{
			await _next(httpContext);
			return;
		}
		var originalBodyStream = httpContext.Response.Body;

		try
		{
			using var responseBody = new MemoryStream();
			httpContext.Response.Body = responseBody;

			await _next(httpContext);

			responseBody.Seek(0, SeekOrigin.Begin);
			var responseText = await new StreamReader(responseBody).ReadToEndAsync();

			responseBody.Seek(0, SeekOrigin.Begin);

			try
			{
				var result = JsonConvert.DeserializeObject<Result>(responseText);
				if (result != null)
				{
					httpContext.Response.StatusCode = (int)result.StatusCode;
				}
			}
			catch (JsonException){}

			await responseBody.CopyToAsync(originalBodyStream);
		}
		finally
		{
			httpContext.Response.Body = originalBodyStream;
		}
	}
}
