using Microsoft.AspNetCore.Diagnostics;

namespace MyResourceList.API.Services.Errors
{
    public class Errorhandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var message = exception.Message;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                title = "Internal Server Error",
                Description = message
            });
            return await ValueTask.FromResult(true);
        }
    }
}
