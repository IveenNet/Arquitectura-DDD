using Pacagroup.Ecommerce.Domain.Entity;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Domain.Interface
{
	public interface ICustomersDomain
	{

		#region Métodos Síncronos

		public bool Insert(Customers customers);
		public bool Update(Customers customers);
		public bool Delete(string customersId);
		public Customers Get(string customersId);
		public IEnumerable<Customers> GetAll();
		public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize);
		public int Count();

		#endregion

		#region Métodos Asíncronos

		public Task<bool> InsertAsync(Customers customers);
		public Task<bool> UpdateAsync(Customers customers);
		public Task<bool> DeleteAsync(string customersId);
		public Task<Customers> GetAsync(string customersId);
		public Task<IEnumerable<Customers>> GetAllAsync();
		public Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
		public Task<int> CountAsync();

		#endregion

	}
}
