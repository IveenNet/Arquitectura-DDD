using System;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
	public interface ICustomersRepository
	{

		#region Métodos Síncronos

		public bool Insert(Customers customers);
		public bool Update(Customers customers);
		public bool Delete(string customersId);
		public Customers Get(string customersId);
		public IEnumerable<Customers> GetAll();

		#endregion

		#region Métodos Asíncronos

		public Task<bool> InsertAsync(Customers customers);
		public Task<bool> UpdateAsync(Customers customers);
		public Task<bool> DeleteAsync(string customersId);
		public Task<Customers> GetAsync(string customersId);
		public Task<IEnumerable<Customers>> GetAllAsync();

		#endregion


	}
}
