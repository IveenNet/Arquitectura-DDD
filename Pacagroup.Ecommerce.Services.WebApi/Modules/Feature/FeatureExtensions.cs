namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Feature
{
	public static class FeatureExtensions
	{

		public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration) 
		{

			var corsOrigin = configuration["Config:OriginCors"];


			if (string.IsNullOrEmpty(corsOrigin))
			{
				throw new ArgumentNullException("Config:OriginCors", "CORS origin cannot be null or empty.");
			}


			services.AddCors(options =>
			{
				options.AddPolicy("policyApiEcommerce", policyBuilder =>
					policyBuilder.WithOrigins(corsOrigin)
								 .AllowAnyHeader()
								 .AllowAnyMethod());
			});

			return services;
		}

	}
}
