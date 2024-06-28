using System.Text.Json.Serialization;

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

			services.AddControllers().AddJsonOptions(opts =>
			{

				var enumConverter = new JsonStringEnumConverter();
				opts.JsonSerializerOptions.Converters.Add(enumConverter);
			});

			return services;
		}

	}
}
