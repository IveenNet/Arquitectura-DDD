using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger
{
	public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;

		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

		public static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
		{
			var info = new OpenApiInfo
			{
				Version = description.ApiVersion.ToString(),
				Title = "Pacagroup Technology Services API Market",
				Description = "A simple example ASP.NET Core Web API",
				TermsOfService = new Uri("https://example.com/terms"),
				Contact = new OpenApiContact
				{
					Name = "Ivan David Medina Vallez",
					Email = "iveen98@gmail.com",
					Url = new Uri("https://pacagroup.com")
				},
				License = new OpenApiLicense
				{
					Name = "Use under LICX",
					Url = new Uri("https://example.com/license")
				}
			};

			if (description.IsDeprecated)
			{
				info.Description += " This API version has been deprecated.";
			}

			return info;
		}

		public void Configure(SwaggerGenOptions options)
		{
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				// This will ensure no duplicates are added
				if (!options.SwaggerGeneratorOptions.SwaggerDocs.ContainsKey(description.GroupName))
				{
					options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
				}
			}
		}
	}
}
