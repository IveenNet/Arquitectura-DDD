using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Main
{
	public class UsersApplication : IUsersApplication
	{

		private readonly IUsersDomain _usersDomain;
		private readonly IMapper _mapper;
		private readonly IAppLogger<CustomersApplication> _logger;

		public UsersApplication(IUsersDomain usersDomain, IMapper mapper, IAppLogger<CustomersApplication> appLogger)
		{
			_usersDomain = usersDomain;
			_mapper = mapper;
			_logger = appLogger;
		}

		public Response<UsersDto> Authenticate(string username, string password)
		{
			var response = new Response<UsersDto>();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				response.Message = "Párametros no pueden ser vacíos";
				return response;
			}
			try
			{

				var user = _usersDomain.Authenticate(username, password);
				response.Data = _mapper.Map<UsersDto>(user);
				response.IsSuccess = true;
				response.Message = "Autenticación OK";
				_logger.LogInformation("Autenticación OK");

			}
			catch(InvalidOperationException oe)
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
