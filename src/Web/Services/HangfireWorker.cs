using Hangfire;
using MaterialsExchangeAPI.Application.Materials.Commands.UpdateMaterialPrices;
using MaterialsExchangeAPI.Web.Endpoints;

namespace MaterialsExchangeAPI.Infrastructure.Hangfire;

public static class HangfireWorker
{
    public static void StartRecurringJobs(this IApplicationBuilder app)
    {
        UpdateMaterialPricesCommand command = new();

        // Добавляем повторяемую задачу по обновлению цен материалов,
        // выполняемую каждый день в 8:00.
        RecurringJob.AddOrUpdate<Materials>("UpdateMaterialPrices",
            x => x.UpdatePrices(command), "0 8 * * *");
    }
}
