using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
	public class CustomersDomain :ICustomersDomain
	{

		public readonly ICustomerRepository _customerRepository;


		#region Métodos Síncronos

		public bool Insert(Customers customers) { return this._customerRepository.Insert(customers); }
		public bool Update(Customers customers) { return this._customerRepository.Update(customers); }
		public bool Delete(string customersId) { return this._customerRepository.Delete(customersId); }
		public Customers Get(string customersId) { return this._customerRepository.Get(customersId); }
		public IEnumerable<Customers> GetAll() { return this._customerRepository.GetAll(); }

		#endregion

		#region Métodos Asíncronos

		public async Task<bool> InsertAsync(Customers customers) { return await this._customerRepository.InsertAsync(customers); }
		public async Task<bool> UpdateAsync(Customers customers) { return await this._customerRepository.UpdateAsync(customers); }
		public async Task<bool> DeleteAsync(string customersId) { return await this._customerRepository.DeleteAsync(customersId); }
		public async Task<Customers> GetAsync(string customersId) { return await this._customerRepository.GetAsync(customersId); }
		public async Task<IEnumerable<Customers>> GetAllAsync() { return await this._customerRepository.GetAllAsync(); }

		#endregion

	}
}
