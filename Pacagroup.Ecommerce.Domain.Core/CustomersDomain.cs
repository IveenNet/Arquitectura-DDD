using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
	public class CustomersDomain : ICustomersDomain
	{
		private readonly ICustomersRepository _customerRepository;

		public CustomersDomain(ICustomersRepository customerRepository)
		{
			_customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
		}

		public bool Insert(Customers customers) => _customerRepository.Insert(customers);
		public bool Update(Customers customers) => _customerRepository.Update(customers);
		public bool Delete(string customerId) => _customerRepository.Delete(customerId);
		public Customers Get(string customerId) => _customerRepository.Get(customerId);
		public IEnumerable<Customers> GetAll() => _customerRepository.GetAll();

		public async Task<bool> InsertAsync(Customers customers) => await _customerRepository.InsertAsync(customers);
		public async Task<bool> UpdateAsync(Customers customers) => await _customerRepository.UpdateAsync(customers);
		public async Task<bool> DeleteAsync(string customerId) => await _customerRepository.DeleteAsync(customerId);
		public async Task<Customers> GetAsync(string customerId) => await _customerRepository.GetAsync(customerId);
		public async Task<IEnumerable<Customers>> GetAllAsync() => await _customerRepository.GetAllAsync();
	}
}
