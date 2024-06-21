using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
	public class CustomersDomain : ICustomersDomain
	{
		private readonly IUnitOfWork _unitOfWork;

		public CustomersDomain(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public bool Insert(Customers customers) => _unitOfWork.Customers.Insert(customers);
		public bool Update(Customers customers) => _unitOfWork.Customers.Update(customers);
		public bool Delete(string customerId) => _unitOfWork.Customers.Delete(customerId);
		public Customers Get(string customerId) => _unitOfWork.Customers.Get(customerId);
		public IEnumerable<Customers> GetAll() => _unitOfWork.Customers.GetAll();
		public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize) => _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
		public int Count() => _unitOfWork.Customers.Count();

		public async Task<bool> InsertAsync(Customers customers) => await _unitOfWork.Customers.InsertAsync(customers);
		public async Task<bool> UpdateAsync(Customers customers) => await _unitOfWork.Customers.UpdateAsync(customers);
		public async Task<bool> DeleteAsync(string customerId) => await _unitOfWork.Customers.DeleteAsync(customerId);
		public async Task<Customers> GetAsync(string customerId) => await _unitOfWork.Customers.GetAsync(customerId);
		public async Task<IEnumerable<Customers>> GetAllAsync() => await _unitOfWork.Customers.GetAllAsync();
		public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize) => await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
		public async Task<int> CountAsync() => await _unitOfWork.Customers.CountAsync();
	}
}
