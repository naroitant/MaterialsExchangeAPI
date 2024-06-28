using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace MaterialsExchangeAPI.Infrastructure.Services;

public class LoggingMiddleware
{
    private static readonly ILogger Log = 
        Serilog.Log.ForContext<LoggingMiddleware>();

    private readonly RequestDelegate _next;

    const string MessageTemplate =
        "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var request = httpContext.Request;
        var start = Stopwatch.GetTimestamp();

        if (httpContext is null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }

        try
        {
            await _next(httpContext);
            var elapsedMilliseconds = 
                GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

            var statusCode = httpContext.Response.StatusCode;
            var level = (statusCode > 499)
                ? LogEventLevel.Error
                : LogEventLevel.Information;
            var log = (level is LogEventLevel.Error)
                ? LogForErrorContext(httpContext)
                : Log;
            log.Write(level, MessageTemplate, request.Method, request.Path, 
                statusCode, elapsedMilliseconds);
        }
        catch (Exception ex)
        {
            LogException(httpContext,
                GetElapsedMilliseconds(start, Stopwatch.GetTimestamp()), ex);
        }
    }

    private static double GetElapsedMilliseconds(long start, long stop)
    {
        var elapsedMilliseconds = 
            (stop - start) * 1000 / (double) Stopwatch.Frequency;
        return elapsedMilliseconds;
    }

    private static void LogException(HttpContext httpContext, 
        double elapsedMilliseconds, Exception ex)
    {
        var request = httpContext.Request;

        LogForErrorContext(httpContext).Error(
            ex, MessageTemplate, request.Method, request.Path, 500, 
            elapsedMilliseconds);
    }

    private static ILogger LogForErrorContext(HttpContext httpContext) {
        var request = httpContext.Request;

        var result = Log
            .ForContext("RequestHeaders", request.Headers.ToDictionary(
                h => h.Key, h => h.Value.ToString()), destructureObjects: true)
            .ForContext("RequestHost", request.Host)
            .ForContext("RequestProtocol", request.Protocol);

        if (request.HasFormContentType)
        {
            result = result.ForContext("RequestForm", request.Form.ToDictionary(
                v => v.Key, v => v.Value.ToString()));
        }

        return result;
    }
}
