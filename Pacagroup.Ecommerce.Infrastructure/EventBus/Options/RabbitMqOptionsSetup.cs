﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Pacagroup.Ecommerce.Infrastructure.EventBus.Options
{
	internal class RabbitMqOptionsSetup : IConfigureOptions<RabbitMqOptions>
	{

		private const string ConfigurationSectionName = "RabbitMqOptions";
		private readonly IConfiguration _configuration;

		public RabbitMqOptionsSetup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(RabbitMqOptions options)
		{
			_configuration.GetSection(ConfigurationSectionName).Bind(options);
		}
	}
}
