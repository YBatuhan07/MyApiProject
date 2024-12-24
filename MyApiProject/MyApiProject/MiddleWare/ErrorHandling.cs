using Serilog;
using System.Net;

namespace MyApiProject.MiddleWare;

public class ErrorHandling
{
    private readonly RequestDelegate _next;

    public ErrorHandling(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.BadRequest;

            switch (error)
            {
                case KeyNotFoundException e:
                    statusCode = HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case Exception e:
                    statusCode = HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            Log.Error(error.Message);

            await response.WriteAsync(error.Message);
        }
    }
}
