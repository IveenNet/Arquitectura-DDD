using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validatior
{
	public class UsersDtoValidator : AbstractValidator<UserDto>
	{

		public UsersDtoValidator() { 
		
			RuleFor(u => u.UserName).NotNull().NotEmpty();
			RuleFor(u => u.Password).NotNull().NotEmpty();

		}

	}
}
