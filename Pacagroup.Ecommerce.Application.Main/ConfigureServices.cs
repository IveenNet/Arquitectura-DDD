using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.UseCases.Categories;
using Pacagroup.Ecommerce.Application.UseCases.Customers;
using Pacagroup.Ecommerce.Application.UseCases.Discounts;
using Pacagroup.Ecommerce.Application.UseCases.User;
using Pacagroup.Ecommerce.Application.Validatior;
using System.Reflection;

namespace Pacagroup.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
	{

		public static IServiceCollection AddAplicationServices(this IServiceCollection services)
		{
			//Lo hace en tiempo de ejecucion
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			//Customers
			services.AddScoped<ICustomersApplication, CustomersApplication>();

			//Users
			services.AddScoped<IUsersApplication, UsersApplication>();
			services.AddTransient<UsersDtoValidator>(); //Añadimos las validaciones

			//Categories
			services.AddScoped<ICategoriesApplication, CategoriesApplication>();

			//Discount
			services.AddScoped<IDiscountsApplication, DiscountsApplication>();
			services.AddTransient<DiscountDtoValidator>(); //Añadimos las validaciones

			return services;
		}

	}
}
