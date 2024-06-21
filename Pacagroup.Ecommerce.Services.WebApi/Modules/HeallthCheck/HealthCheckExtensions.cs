namespace Pacagroup.Ecommerce.Services.WebApi.Modules.HeallthCheck
{
	public static class HealthCheckExtensions
	{

		public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHealthChecks()
				.AddSqlServer(configuration.GetConnectionString("NorthwindConnection"), tags: new[] { "databse" })
				.AddCheck<HealthCheckCustom>("HealthCheckCustom", tags: new[] {"custom"});

			services.AddHealthChecksUI()
				.AddInMemoryStorage();

			return services;
		}
	}
}
