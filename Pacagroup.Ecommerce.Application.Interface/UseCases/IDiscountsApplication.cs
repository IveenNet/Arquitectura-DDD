using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
	public interface IDiscountsApplication
	{

		public Task<Response<bool>> CreateAsync(DiscountDto discountDto, CancellationToken cancellationToken=default);
		public Task<Response<bool>> UpdateAsync(DiscountDto discountDto, CancellationToken cancellationToken = default);
		public Task<Response<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default);
		public Task<Response<DiscountDto>> GetAsync(int id, CancellationToken cancellationToken = default);
		public Task<Response<List<DiscountDto>>> GetAllAsync(CancellationToken cancellationToken = default);
		public Task<ResponsePagination<IEnumerable<DiscountDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
		
	}
}
