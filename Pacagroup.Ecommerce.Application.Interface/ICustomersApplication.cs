using System;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface
{
	public interface ICustomersApplication
	{

		#region Métodos Síncronos

		public Response<bool> Insert(CustomersDto customers);
		public Response<bool> Update(CustomersDto customers);
		public Response<bool> Delete(string customersId);
		public Response<CustomersDto> Get(string customersId);
		public Response<IEnumerable<CustomersDto>> GetAll();

		#endregion

		#region Métodos Asíncronos

		public Task<Response<bool>> InsertAsync(CustomersDto customers);
		public Task<Response<bool>> UpdateAsync(CustomersDto customers);
		public Task<Response<bool>> DeleteAsync(string customersId);
		public Task<Response<CustomersDto>> GetAsync(string customersId);
		public Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();

		#endregion

	}
}
