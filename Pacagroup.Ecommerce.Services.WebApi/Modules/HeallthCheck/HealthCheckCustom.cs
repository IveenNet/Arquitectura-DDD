using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HeallthCheck
{
	public class HealthCheckCustom : IHealthCheck
	{
		private readonly Random _random = new Random();

		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			var responseTime = _random.Next(1, 300);

			if (responseTime < 100) {

				return Task.FromResult(HealthCheckResult.Healthy("Healthy resutl from HealthCheckCustom"));

			}else if (responseTime < 200)
			{
				return Task.FromResult(HealthCheckResult.Degraded("Degreaded resutl from HealthCheckCustom"));
			}

			return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy resutl from HealthCheckCustom"));

		}
	}
}
