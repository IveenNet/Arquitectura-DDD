using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Application.Main;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Repository;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.Mapper;
using Pacagroup.Ecommerce.Transversal.Logging;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingsProfile));

var corsOrigin = builder.Configuration["Config:OriginCors"];
var appSettingSection = builder.Configuration.GetSection("Config");

var appSettings = appSettingSection.Get<AppSettings>();

if (string.IsNullOrEmpty(corsOrigin))
{
	throw new ArgumentNullException("Config:OriginCors", "CORS origin cannot be null or empty.");
}

builder.Services.AddCors(options =>
{
	options.AddPolicy("policyApiEcommerce", policyBuilder =>
		policyBuilder.WithOrigins(corsOrigin)
					 .AllowAnyHeader()
					 .AllowAnyMethod());
});

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.PropertyNamingPolicy = null;
	});

builder.Services.Configure<AppSettings>(appSettingSection);
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var issuer = appSettings.Issuer;
var audience = appSettings.Audience;

builder.Services.AddAuthentication(options =>
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
		ValidIssuer = issuer,
		ValidateAudience = true,
		ValidAudience = audience,
		ValidateLifetime = true,
		ClockSkew = TimeSpan.Zero
	};
});

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Pacagroup Technology Services API Market",
		Description = "A simple example ASP.NET Core Web API",
		TermsOfService = new Uri("https://example.com/terms"),
		Contact = new OpenApiContact
		{
			Name = "Ivan David Medina Vallez",
			Email = "iveen98@gmail.com",
			Url = new Uri("https://pacagroup.com")
		},
		License = new OpenApiLicense
		{
			Name = "Use under LICX",
			Url = new Uri("https://example.com/license")
		}
	});

	// Define el esquema de seguridad
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	// Requerir el esquema de seguridad
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] {}
		}
	});

	// Set the comments path for the Swagger JSON and UI.
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
	});
}
else
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseCors("policyApiEcommerce");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
