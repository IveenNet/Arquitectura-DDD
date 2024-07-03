using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
	public sealed record CreateUserTokenCommand : IRequest<Response<UserDto>>
	{
		public string UserName { get; set; }
		public string UserPassword { get; set; }
	}
}
