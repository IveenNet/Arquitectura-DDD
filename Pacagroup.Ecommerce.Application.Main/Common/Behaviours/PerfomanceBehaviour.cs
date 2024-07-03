using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Behaviours
{
	public class PerfomanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
	{

		private readonly Stopwatch _timer;
		private readonly ILogger<TRequest> _logger;

		public PerfomanceBehaviour(ILogger<TRequest> logger)
		{
			_timer = new Stopwatch();
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{

			_timer.Start();
			var response = await next();
			_timer.Stop();

			var elapsedMilliseconds = _timer.ElapsedMilliseconds;

			if (elapsedMilliseconds > 10) _logger.LogWarning("Clean Architecture Long Running Request: {name} ({elapsedMilliseconds} milliseconds) {@request}", 
				typeof(TRequest).Name, 
				elapsedMilliseconds, 
				JsonSerializer.Serialize(request));

			return response;
		}
	}
}
