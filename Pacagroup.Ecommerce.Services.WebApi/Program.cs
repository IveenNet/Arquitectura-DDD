using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Validator;
using Pacagroup.Ecommerce.Services.WebApi.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Obtener IApiVersionDescriptionProvider del contenedor de servicios
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configurar el pipeline de solicitudes HTTP
ConfigureMiddleware(app, provider);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	services.AddControllers()
		.AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.PropertyNamingPolicy = null;
		});

	services.AddAuthentication(configuration);
	services.AddSwagger();
	services.AddVersioning(); // Usa la extensión de versionado
	services.AddMapper();
	services.AddFeature(configuration);
	services.AddInjection(configuration);
	services.AddValidator();

	// Registrar la configuración de Swagger
	services.ConfigureOptions<ConfigureSwaggerOptions>();
}

void ConfigureMiddleware(WebApplication app, IApiVersionDescriptionProvider provider)
{
	if (app.Environment.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			// Añadir un endpoint para cada descripción de versión
			foreach (var description in provider.ApiVersionDescriptions)
			{
				c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
			}
		});
	}
	else
	{
		app.UseExceptionHandler("/Home/Error");
		app.UseHsts();
	}

	app.UseCors("policyApiEcommerce");
	app.UseHttpsRedirection();
	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
}
