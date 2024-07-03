using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
	public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Response<UserDto>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
		{
			var response = new Response<UserDto>();

			try
			{
				var user = await _unitOfWork.Users.Authenticate(request.UserName, request.UserPassword);
				if (user == null)
				{
					response.IsSuccess = false;
					response.Message = "Usuario no existe";
				}
				else
				{
					response.Data = _mapper.Map<UserDto>(user);
					response.IsSuccess = true;
					response.Message = "Autenticación OK";
				}
			}
			catch (Exception ex)
			{
				response.Message = ex.Message;
				response.IsSuccess = false;
			}

			return response;
		}
	}
}
