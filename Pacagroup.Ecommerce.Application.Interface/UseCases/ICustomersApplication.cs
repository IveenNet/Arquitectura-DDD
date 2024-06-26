using System;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Interface.UseCases
{
    public interface ICustomersApplication
    {

        #region Métodos Síncronos

        public Response<bool> Insert(CustomerDto customers);
        public Response<bool> Update(CustomerDto customers);
        public Response<bool> Delete(string customersId);
        public Response<CustomerDto> Get(string customersId);
        public Response<IEnumerable<CustomerDto>> GetAll();
        public ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize);

        #endregion

        #region Métodos Asíncronos

        public Task<Response<bool>> InsertAsync(CustomerDto customers);
        public Task<Response<bool>> UpdateAsync(CustomerDto customers);
        public Task<Response<bool>> DeleteAsync(string customersId);
        public Task<Response<CustomerDto>> GetAsync(string customersId);
        public Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        public Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        #endregion

    }
}
