using Hangfire;
using MaterialsExchange.Controllers;
using MaterialsExchange.Features.Material.Commands;

namespace MaterialsExchange.Tasks
{
	public static class HangfireWorker
	{
		public static void StartRecurringJobs(this IApplicationBuilder app)
		{
			UpdateMaterialPricesCommand command = new UpdateMaterialPricesCommand();
			CancellationToken token = new CancellationToken();
			RecurringJob.AddOrUpdate<MaterialController>("UpdatePrices", x => x.UpdatePrices(command, token), "* * * * *");
		}
	}
}
