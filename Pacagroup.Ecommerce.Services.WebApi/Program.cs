using Asp.Versioning.ApiExplorer;
using HealthChecks.UI.Client;
using Pacagroup.Ecommerce.Application.UseCases;
using Pacagroup.Ecommerce.Infrastructure;
using Pacagroup.Ecommerce.Persistence;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException;
using Pacagroup.Ecommerce.Services.WebApi.Modules.HeallthCheck;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiter;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Redis;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Watch;
using Pacagroup.Ecommerce.Services.WebApi.Versioning;
using WatchDog;

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

	services.AddCors(options =>
	{
		options.AddPolicy("policyApiEcommerce", builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
	});

	services.AddAuthentication(configuration);
	services.AddSwagger();
	services.AddVersioning(); // Usa la extensión de versionado
	services.AddFeature(configuration);
	services.AddInjection(configuration);
	services.AddPersistenceServices(configuration);
	services.AddInfrastructureServices();
	services.AddApplicationServices();
	services.AddHealthCheck(configuration);
	services.AddWatchDog(configuration);
	services.AddRedisCache(configuration);
	services.AddRateLimiting(configuration);

	// Registrar la configuración de Swagger
	services.ConfigureOptions<ConfigureSwaggerOptions>();

	// Registrar GlobalExceptionHandler
	services.AddTransient<GlobalExceptionHandler>();
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

		app.UseReDoc(options =>
		{
			foreach (var description in provider.ApiVersionDescriptions)
			{
				options.DocumentTitle = "Pacagroup Technology Services API Market";
				options.SpecUrl = $"/swagger/{description.GroupName}/swagger.json";
			}
		});
	}
	else
	{
		app.UseExceptionHandler("/Home/Error");
		app.UseHsts();
	}

	app.UseMiddleware<GlobalExceptionHandler>();
	app.UseWatchDogExceptionLogger();
	app.UseHttpsRedirection();
	app.UseCors("policyApiEcommerce");
	app.UseRouting();
	app.UseAuthentication();
	app.UseRateLimiter();
	app.UseAuthorization();
	app.UseEndpoints(endpoints => { });
	app.MapControllers();
	app.MapHealthChecksUI();

	app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
	{
		Predicate = _ => true,
		ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
	});

	app.UseWatchDog(conf =>
	{
		conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
		conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
	});

	app.AddMiddleware();
}
