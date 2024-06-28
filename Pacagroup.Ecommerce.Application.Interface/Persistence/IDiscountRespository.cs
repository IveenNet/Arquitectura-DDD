using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.Interface.Persistence
{
	public interface IDiscountRespository : IGenericRepository<Discount>
	{

		Task<Discount> GetById(int id, CancellationToken cancellationToken);

		Task<List<Discount>> GetAllAsync(CancellationToken cancellationToken);

	}
}
