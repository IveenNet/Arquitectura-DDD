using FluentValidation;

namespace Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand
{
	public class CreateUserTokenValidator : AbstractValidator<CreateUserTokenCommand>
	{
		public CreateUserTokenValidator()
		{
			RuleFor(u => u.UserName).NotNull().NotEmpty();
			RuleFor(u => u.UserPassword).NotNull().NotEmpty().MinimumLength(5);
		}
	}
}
