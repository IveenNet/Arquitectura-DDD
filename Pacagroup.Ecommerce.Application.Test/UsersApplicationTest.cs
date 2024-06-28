using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using System.IO;

[TestClass]
public class UsersApplicationTest
{
	private static IConfiguration _configuration;
	private static IServiceScopeFactory _scopeFactory;

	[ClassInitialize]
	public static void ClassInitialize(TestContext _)
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables();
		_configuration = builder.Build();

		var hostBuilder = Host.CreateDefaultBuilder()
			.ConfigureAppConfiguration((context, config) =>
			{
				config.AddConfiguration(_configuration);
			})
			.ConfigureServices((context, services) =>
			{
				// Add services as in Program.cs
				services.AddControllers()
					.AddJsonOptions(options =>
					{
						options.JsonSerializerOptions.PropertyNamingPolicy = null;
					});

				services.AddAuthentication(context.Configuration);
				services.AddSwagger();
				services.AddFeature(context.Configuration);
				services.AddInjection(context.Configuration);
				services.AddLogging();
			});

		var host = hostBuilder.Build();
		_scopeFactory = host.Services.GetService<IServiceScopeFactory>();
	}

	[TestMethod]
	public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
	{
		using var scope = _scopeFactory.CreateScope();
		var context = scope.ServiceProvider.GetService<IUsersApplication>();

		// Arrange
		var userName = string.Empty;
		var password = string.Empty;
		var expected = "Párametros no pueden ser vacíos";

		// Act            
		var result = context.Authenticate(userName, password);
		var actual = result.Message;

		// Assert
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
	{
		using var scope = _scopeFactory.CreateScope();
		var context = scope.ServiceProvider.GetService<IUsersApplication>();

		// Arrange
		var userName = "Ivan";
		var password = "123456";
		var expected = "Autenticación OK";

		// Act
		var result = context.Authenticate(userName, password);
		var actual = result.Message;

		// Assert
		Assert.AreEqual(expected, actual);
	}

	[TestMethod]
	public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
	{
		using var scope = _scopeFactory.CreateScope();
		var context = scope.ServiceProvider.GetService<IUsersApplication>();

		// Arrange
		var userName = "Ivan";
		var password = "123456899";
		var expected = "Usuario no existe";

		// Act
		var result = context.Authenticate(userName, password);
		var actual = result.Message;

		// Assert
		Assert.AreEqual(expected, actual);
	}
}
