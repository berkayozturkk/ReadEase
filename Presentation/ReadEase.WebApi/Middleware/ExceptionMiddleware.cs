using ReadEase.Domain.Entities;
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
            await LogExceptionToDatabaseAsync(ex, context.Request);
            //await HandleExceptionAsync(context, ex);
        }
    }

    private async Task LogExceptionToDatabaseAsync(Exception ex, HttpRequest request)
    {
        ErrorLog errorLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            ErrorMessage = ex.Message,
            StackTree = ex.StackTrace,
            RequestPath = request.Path,
            RequestMethod = request.Method,
            TimeStamp = DateTime.Now,
        };

        await _context.Set<ErrorLog>().AddAsync(errorLog, default);
        await _context.SaveChangesAsync(default);
    }
}
