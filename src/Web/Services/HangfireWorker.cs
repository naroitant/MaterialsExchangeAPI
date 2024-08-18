using Application.Materials.Commands.UpdateMaterialPrices;
using Hangfire;
using Web.Endpoints;

namespace Web.Services;

public static class HangfireWorker
{
    public static void StartRecurringJobs(this IApplicationBuilder app)
    {
        UpdateMaterialPricesCommand command = new();
        
        RecurringJob.AddOrUpdate<Materials>("UpdateMaterialPrices",
            x => x.UpdateMaterialPricesAsync(command), "0 8 * * *");
    }
}
