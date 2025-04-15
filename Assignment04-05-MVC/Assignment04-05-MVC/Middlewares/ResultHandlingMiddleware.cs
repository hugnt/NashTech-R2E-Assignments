using Assignment04_05_MVC.Common;
using Newtonsoft.Json;

namespace Assignment04_05_MVC.Middlewares;

public class ResultHandlingMiddleware
{
	private readonly RequestDelegate _next;

	public ResultHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}


	public async Task InvokeAsync(HttpContext httpContext)
	{
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
			catch (JsonException) { }

			await responseBody.CopyToAsync(originalBodyStream);
		}
		finally
		{
			httpContext.Response.Body = originalBodyStream;
		}
	}
}
