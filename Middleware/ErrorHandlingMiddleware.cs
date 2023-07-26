using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using beflightsearch.Exceptions;


public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception (optional)

        var statusCode = StatusCodes.Status500InternalServerError;
        var message = "An unexpected error occurred.";

        // Customize the error message based on the type of exception if needed
        if (exception is NotFoundException)
        {
            statusCode = StatusCodes.Status404NotFound;
            message = exception.Message;
        }
        // Add more custom exception handling as required

        var result = JsonConvert.SerializeObject(new { error = message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        return context.Response.WriteAsync(result);
    }
}
