using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Persistence.Contexts;
using Pacagroup.Ecommerce.Persistence.Interceptors;
using Pacagroup.Ecommerce.Persistence.Repositories;

namespace Pacagroup.Ecommerce.Persistence
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddSingleton<DapperContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//Interceptors
			services.AddScoped<AuditableEntitySaveChangesInterceptor>();
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("NorthwindConnection"),
				builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


			//Customers
			services.AddScoped<ICustomersRepository, CustomersRepository>();

			//Users
			services.AddScoped<IUsersRepository, UsersRepository>();

			//Categories
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();

			//Discount
			services.AddScoped<IDiscountRespository, DiscountRepository>();

			return services;
		}



	}
}
