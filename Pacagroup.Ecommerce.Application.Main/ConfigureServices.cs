using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.UseCases.Categories;
using Pacagroup.Ecommerce.Application.UseCases.Common.Behaviours;
using Pacagroup.Ecommerce.Application.UseCases.Customers;
using Pacagroup.Ecommerce.Application.UseCases.Discounts;
using Pacagroup.Ecommerce.Application.UseCases.User;
using System.Reflection;

namespace Pacagroup.Ecommerce.Application.UseCases
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// Añadimos los validadores del ensamblado actual
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			// Añadimos MediatR y registramos los comportamientos del pipeline
			services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerfomanceBehaviour<,>));
			});

			// Añadimos AutoMapper y registramos perfiles del ensamblado actual
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			// Registramos las implementaciones de las aplicaciones
			// Customers
			services.AddScoped<ICustomersApplication, CustomersApplication>();

			// Users
			services.AddScoped<IUsersApplication, UsersApplication>();

			// Categories
			services.AddScoped<ICategoriesApplication, CategoriesApplication>();

			// Discount
			services.AddScoped<IDiscountsApplication, DiscountsApplication>();

			return services;
		}
	}
}
