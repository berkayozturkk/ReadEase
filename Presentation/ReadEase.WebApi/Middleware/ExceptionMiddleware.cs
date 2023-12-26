using ReadEase.Persistance.Context;


namespace ReadEase.WebApi.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private readonly BaseDbContext _context;

    public ExceptionMiddleware(BaseDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            //await LogExceptionToDatabaseAsync(ex, context.Request);
            //await HandleExceptionAsync(context, ex);
        }
    }
}
