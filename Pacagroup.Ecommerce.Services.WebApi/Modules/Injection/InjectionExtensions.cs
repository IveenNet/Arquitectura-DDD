using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Repository;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.Logging;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Injection
{
	public static class InjectionExtensions
	{

		public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddSingleton<IConfiguration>(configuration);
			services.AddSingleton<DapperContext>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//Customers
			services.AddScoped<ICustomersApplication, CustomersApplication>();
			services.AddScoped<ICustomersDomain, CustomersDomain>();
			services.AddScoped<ICustomersRepository, CustomersRepository>();

			//Users
			services.AddScoped<IUsersApplication, UsersApplication>();
			services.AddScoped<IUsersDomain, UsersDomain>();
			services.AddScoped<IUsersRepository, UsersRepository>();

			//Categories
			services.AddScoped<ICategoriesApplication, CategoriesApplication>();
			services.AddScoped<ICategoriesDomain, CategoriesDomain>();
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();

			return services;
		}

	}
}
