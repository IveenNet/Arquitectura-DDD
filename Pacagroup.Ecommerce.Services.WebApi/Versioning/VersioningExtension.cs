using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Pacagroup.Ecommerce.Services.WebApi.Versioning
{
	public static class VersioningExtension
	{
		public static IServiceCollection AddVersioning(this IServiceCollection services)
		{
			// Add API Versioning
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true;
				//options.ApiVersionReader = new QueryStringApiVersionReader("api-version"); //Con este nos exigen la version
				//options.ApiVersionReader = new HeaderApiVersionReader("x-version"); //Esto va en el header
				options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Usar solo la versión en la ruta
			}).AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}
	}
}
