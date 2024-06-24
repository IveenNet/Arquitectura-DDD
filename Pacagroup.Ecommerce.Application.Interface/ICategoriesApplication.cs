using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface
{
	public interface ICategoriesApplication
	{

		public Task<Response<IEnumerable<CategoriesDto>>> GetAll();

	}
}
