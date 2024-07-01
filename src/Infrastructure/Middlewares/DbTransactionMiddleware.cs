using MaterialsExchangeAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Http;

namespace MaterialsExchangeAPI.Infrastructure.Services;

public class DbTransactionMiddleware : IMiddleware
{
    private readonly AppDbContext _context;

    public DbTransactionMiddleware(AppDbContext context)
    {
        _context = context;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        if (httpContext.Request.Method.Equals("GET",
            StringComparison.CurrentCultureIgnoreCase))
        {
            await next(httpContext);
            return;
        }

        try
        {
            await next(httpContext);
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
