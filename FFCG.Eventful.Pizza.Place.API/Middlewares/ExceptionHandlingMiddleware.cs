using System.Net;
using FFCG.Eventful.Pizza.Place.Domain.Exceptions;
using Newtonsoft.Json;

namespace FFCG.Eventful.Pizza.Place.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
	public async Task Invoke(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception ex)
	{
		var statusCode = HttpStatusCode.InternalServerError;
		var result = JsonConvert.SerializeObject(new { error = ex.Message });
		statusCode = ex switch
		{
			NotFoundException _ => HttpStatusCode.NotFound,
			ArgumentException _ => HttpStatusCode.BadRequest,
			_ => statusCode
		};

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)statusCode;
		return context.Response.WriteAsync(result);
	}
}
