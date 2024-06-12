using Hangfire;
using MaterialsExchangeAPI.Controllers;
using MaterialsExchangeAPI.Features.Material.Commands.UpdateMaterialPricesCommand;

namespace MaterialsExchangeAPI.Tasks
{
    public static class HangfireWorker
    {
        public static void StartRecurringJobs(this IApplicationBuilder app)
        {
            UpdateMaterialPricesCommand command = new UpdateMaterialPricesCommand();
            CancellationToken token = new CancellationToken();

            // Добавляем повторяемую задачу по обновлению цен материалов, выполняемую каждый день в 8:00.
            RecurringJob.AddOrUpdate<MaterialController>("UpdateMaterialPrices", x => x.UpdatePrices(), "0 8 * * *");
        }
    }
}
