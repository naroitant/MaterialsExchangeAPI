using MaterialsExchangeAPI.Infrastructure.Data;
using MaterialsExchangeAPI.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class DbTransactionMiddleware : IDbTransactionMiddleware
{
    private readonly RequestDelegate _next;

    public DbTransactionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, AppDbContext context)
    {
        using var transaction = await context.Database.BeginTransactionAsync();

        if (httpContext.Request.Method.Equals("GET",
            StringComparison.CurrentCultureIgnoreCase))
        {
            await _next(httpContext);
            return;
        }

        try
        {
            await _next(httpContext);
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
