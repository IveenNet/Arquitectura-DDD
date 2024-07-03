namespace Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException
{
	public static class MiddlewareExtensions
	{

		public static IApplicationBuilder AddMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<GlobalExceptionHandler>();
		}

	}
}
