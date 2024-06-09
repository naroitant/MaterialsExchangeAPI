using Hangfire;
using MaterialsExchange.Controllers;

namespace MaterialsExchange.Tasks
{
	public static class HangfireWorker
	{
		public static void StartRecurringJobs(this IApplicationBuilder app)
		{
			RecurringJob.AddOrUpdate<MaterialController>("UpdateMaterialPrices", x => x.UpdateMaterialPrices(), "0 8 * * *");
		}
	}
}
