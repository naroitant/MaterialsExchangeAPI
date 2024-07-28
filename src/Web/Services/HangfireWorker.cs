using Hangfire;
using Application.Materials.Commands.UpdateMaterialPrices;
using Web.Endpoints;

namespace Web.Services;

public static class HangfireWorker
{
    public static void StartRecurringJobs(this IApplicationBuilder app)
    {
        UpdateMaterialPricesCommand command = new();
        
        RecurringJob.AddOrUpdate<Materials>("UpdateMaterialPrices",
            x => x.UpdatePrices(command), "0 8 * * *");
    }
}
