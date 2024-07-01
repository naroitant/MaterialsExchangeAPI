using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace MaterialsExchangeAPI.Infrastructure.Services;

public class LoggingMiddleware : IMiddleware
{
    private static readonly ILogger Log = 
        Serilog.Log.ForContext<LoggingMiddleware>();

    const string MessageTemplate = 
        "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var request = context.Request;

        // Фиксируем время отправки запроса.
        var start = Stopwatch.GetTimestamp();

        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        try
        {
            await next(context);

            // Вычисляем время на получение ответа на запрос.
            var elapsedMilliseconds =
                GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

            var statusCode = context.Response.StatusCode;
            var level = (statusCode > 499)
                ? LogEventLevel.Error
                : LogEventLevel.Information;
            var log = (level is LogEventLevel.Error)
                ? LogForErrorContext(context)
                : Log;

            log.Write(level, MessageTemplate, request.Method, request.Path,
                statusCode, elapsedMilliseconds);
        }
        catch (Exception ex)
        {
            var elapsedMilliseconds =
                GetElapsedMilliseconds(start, Stopwatch.GetTimestamp());

            LogForErrorContext(context).Error(ex, MessageTemplate,
                request.Method, request.Path, context.Response.StatusCode,
                elapsedMilliseconds, ex);
        }
    }

    private static double GetElapsedMilliseconds(long start, long stop)
    {
        var elapsedMilliseconds = 
            (stop - start) * 1000 / (double) Stopwatch.Frequency;
        return elapsedMilliseconds;
    }

    private static ILogger LogForErrorContext(HttpContext httpContext)
    {
        var request = httpContext.Request;

        var result = Log
            .ForContext("RequestHeaders", request.Headers.ToDictionary(
                h => h.Key, h => h.Value.ToString()), destructureObjects: true)
            .ForContext("RequestHost", request.Host)
            .ForContext("RequestProtocol", request.Protocol);

        if (request.HasFormContentType)
        {
            result = result.ForContext("RequestForm", request.Form.
                ToDictionary(v => v.Key, v => v.Value.ToString()));
        }

        return result;
    }
}
