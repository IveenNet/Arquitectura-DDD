using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using System.Text;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication
{
	public static class AuthenticationExtensions
	{
		public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			var appSettingsSection = configuration.GetSection("Config");
			services.Configure<AppSettings>(appSettingsSection);

			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.Events = new JwtBearerEvents
				{
					OnTokenValidated = context =>
					{
						var userId = int.Parse(context.Principal.Identity.Name);
						return Task.CompletedTask;
					},
					OnAuthenticationFailed = context =>
					{
						if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						{
							context.Response.Headers.Add("Token-Expired", "true");
						}
						return Task.CompletedTask;
					}
				};
				options.RequireHttpsMetadata = false;
				options.SaveToken = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidIssuer = appSettings.Issuer,
					ValidateAudience = true,
					ValidAudience = appSettings.Audience,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});

			return services;
		}
	}
}
