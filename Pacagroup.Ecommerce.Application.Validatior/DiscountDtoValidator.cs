using FluentValidation;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Application.Validatior
{
	public class DiscountDtoValidator : AbstractValidator<DiscountDto>
	{

		public DiscountDtoValidator() {

			RuleFor(x => x.Name).NotEmpty().NotNull();
			RuleFor(x => x.Description).NotEmpty().NotNull();
			RuleFor(x => x.Percent).NotEmpty().NotNull().GreaterThan(0);
		
		}

	}
}
