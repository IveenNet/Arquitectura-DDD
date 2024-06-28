using System;
using AutoMapper;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers
{
    public class CustomersApplication : ICustomersApplication
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;


        public CustomersApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<CustomersApplication> appLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = appLogger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(CustomerDto customers)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customers);
                response.Data = _unitOfWork.Customers.Insert(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = " Registro OK";
                    _logger.LogInformation("Registro OK");
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public Response<bool> Update(CustomerDto customers)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customers);
                response.Data = _unitOfWork.Customers.Update(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = " Update OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public Response<bool> Delete(string customersId)
        {
            var response = new Response<bool>();

            try
            {

                response.Data = _unitOfWork.Customers.Delete(customersId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Borrado OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public Response<CustomerDto> Get(string customersId)
        {
            var response = new Response<CustomerDto>();

            try
            {
                var customer = _unitOfWork.Customers.Get(customersId);
                response.Data = _mapper.Map<CustomerDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public Response<IEnumerable<CustomerDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDto>>();

            try
            {
                var customers = _unitOfWork.Customers.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                    _logger.LogInformation("Consulta OK");
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                _logger.LogError($"Error al obtenerlos : {ex.Message}");

            }

            return response;
        }

        public ResponsePagination<IEnumerable<CustomerDto>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();

            try
            {
                var count = _unitOfWork.Customers.Count();
                var customers = _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;

                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                    _logger.LogInformation("Consulta OK");
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                _logger.LogError($"Error al obtenerlos : {ex.Message}");

            }

            return response;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(CustomerDto customers)
        {

            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customers);
                response.Data = await _unitOfWork.Customers.InsertAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = " Registro OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;

        }
        public async Task<Response<bool>> UpdateAsync(CustomerDto customers)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customer>(customers);
                response.Data = await _unitOfWork.Customers.UpdateAsync(customer);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Update OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customersId)
        {
            var response = new Response<bool>();

            try
            {

                response.Data = await _unitOfWork.Customers.DeleteAsync(customersId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Borrado OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public async Task<Response<CustomerDto>> GetAsync(string customersId)
        {
            var response = new Response<CustomerDto>();

            try
            {
                var customer = await _unitOfWork.Customers.GetAsync(customersId);
                response.Data = _mapper.Map<CustomerDto>(customer);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }
        public async Task<Response<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDto>>();

            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;

            }

            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomerDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDto>>();

            try
            {
                var count = await _unitOfWork.Customers.CountAsync();
                var customers = await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;

                    response.IsSuccess = true;
                    response.Message = "Consulta OK";
                    _logger.LogInformation("Consulta OK");
                }

            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                _logger.LogError($"Error al obtenerlos : {ex.Message}");

            }

            return response;
        }

        #endregion
    }
}
