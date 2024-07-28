namespace Library.WebApi.Filters.Exceptions;

public class CustomExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken
    )
    {
        var error = new Error
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity,
            Message = exception.Message
        };

        httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
        await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

        return true;
    }
}