using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Validatior;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.UseCases.Customers;

namespace Pacagroup.Ecommerce.Application.UseCases.User
{
    public class UsersApplication : IUsersApplication
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;
        private readonly UsersDtoValidator _validationRules;

        public UsersApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<CustomersApplication> appLogger, UsersDtoValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = appLogger;
            _validationRules = validationRules;
        }

        public Response<UserDto> Authenticate(string username, string password)
        {
            var response = new Response<UserDto>();
            var validation = _validationRules.Validate(new UserDto() { UserName = username, Password = password });

            if (!validation.IsValid)
            {
                response.Message = "Párametros no pueden ser vacíos";
                response.Errors = validation.Errors;
                return response;
            }
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
