using AutoMapper;
using Microsoft.Extensions.Logging;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.UseCases.Customers;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.User
{
	public class UsersApplication : IUsersApplication
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersApplication> _logger;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomersApplication> appLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = appLogger;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();

            try
            {

                var user = _unitOfWork.Users.Authenticate(username, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación OK";
                _logger.LogInformation("Autenticación OK");

            }
            catch (InvalidOperationException oe)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
                _logger.LogInformation("Usuario no existe");
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
                return response;
            }

            return response;
        }
    }
}
