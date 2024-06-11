using Pacagroup.Ecommerce.Transversal.Mapper;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper
{
	public static class MapperExtensions
	{

		public static IServiceCollection AddMapper(this IServiceCollection services)
		{

			// Add services to the container.
			services.AddAutoMapper(typeof(MappingsProfile));

			return services;
		}

	}
}
