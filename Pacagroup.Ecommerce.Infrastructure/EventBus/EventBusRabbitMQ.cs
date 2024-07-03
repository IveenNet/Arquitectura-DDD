using Pacagroup.Ecommerce.Application.Interface.Infrastructure;
using MassTransit;

namespace Pacagroup.Ecommerce.Infrastructure.EventBus
{
	public class EventBusRabbitMQ : IEventBus
	{

		private readonly IPublishEndpoint _endpoint;

		public EventBusRabbitMQ(IPublishEndpoint endpoint)
		{
			_endpoint = endpoint;
		}

		public async void Publish<T>(T @event)
		{
			await _endpoint.Publish(@event);
		}
	}
}
