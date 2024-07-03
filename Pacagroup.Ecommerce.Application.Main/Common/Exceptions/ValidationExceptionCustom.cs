using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Exceptions
{
	public class ValidationExceptionCustom : Exception
	{

		public ValidationExceptionCustom(IEnumerable<BaseError>? errors) : this()
		{

			Errors = errors;

		}

		public ValidationExceptionCustom() : base("One or more validation failures")
		{

			Errors = new List<BaseError>();
			
		}

		public IEnumerable<BaseError>? Errors { get; }

	}
}
