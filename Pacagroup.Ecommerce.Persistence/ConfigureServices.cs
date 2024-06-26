using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Contexts;
using Pacagroup.Ecommerce.Persistence.Repositories;

namespace Pacagroup.Ecommerce.Persistence
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
		{

			services.AddSingleton<DapperContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//Customers
			services.AddScoped<ICustomersRepository, CustomersRepository>();

			//Users
			services.AddScoped<IUsersRepository, UsersRepository>();

			//Categories
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();

			return services;
		}



	}
}
