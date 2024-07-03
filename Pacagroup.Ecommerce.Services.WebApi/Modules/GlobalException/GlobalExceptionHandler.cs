using Pacagroup.Ecommerce.Application.UseCases.Common.Exceptions;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Net;
using System.Text.Json;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationExceptionCustom ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new Response<object>
                {
                    IsSuccess = false,
                    Message = "Errores de validación",
                    Errors = ex.Errors.ToList()
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                _logger.LogError($"Error: {message}", ex);

                var response = new Response<object>
                {
                    IsSuccess = false,
                    Message = message
                };

                await JsonSerializer.SerializeAsync(context.Response.Body, response);
            }
        }
    }
}
