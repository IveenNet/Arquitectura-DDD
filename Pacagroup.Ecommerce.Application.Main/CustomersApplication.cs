﻿using System;
using AutoMapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.Main
{
	public class CustomersApplication : ICustomersApplication
	{

		private readonly ICustomersDomain _customersDomain;
		private readonly IMapper _mapper;

		public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
		{
			this._customersDomain = customersDomain;
			this._mapper = mapper;
		}

		#region Métodos Síncronos

		public Response<bool> Insert(CustomersDto customers)
		{
			var response = new Response<bool>();

			try
			{

				var customer = this._mapper.Map<Customers>(customers);
				response.Data = this._customersDomain.Insert(customer);

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
		public Response<bool> Update(CustomersDto customers)
		{
			var response = new Response<bool>();

			try
			{

				var customer = this._mapper.Map<Customers>(customers);
				response.Data = this._customersDomain.Update(customer);

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

				response.Data = this._customersDomain.Delete(customersId);

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
		public Response<CustomersDto> Get(string customersId)
		{
			var response = new Response<CustomersDto>();

			try
			{
				var customer = this._customersDomain.Get(customersId);
				response.Data = this._mapper.Map<CustomersDto>(customer);

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
		public Response<IEnumerable<CustomersDto>> GetAll()
		{
			var response = new Response<IEnumerable<CustomersDto>>();

			try
			{
				var customers = this._customersDomain.GetAll();
				response.Data = this._mapper.Map <IEnumerable<CustomersDto>>(customers);

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

		#endregion

		#region Métodos Asíncronos

		public async Task<Response<bool>> InsertAsync(CustomersDto customers)
		{

			var response = new Response<bool>();

			try
			{

				var customer = this._mapper.Map<Customers>(customers);
				response.Data = await this._customersDomain.InsertAsync(customer);

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
		public async Task<Response<bool>> UpdateAsync(CustomersDto customers)
		{
			var response = new Response<bool>();

			try
			{

				var customer = this._mapper.Map<Customers>(customers);
				response.Data = await this._customersDomain.UpdateAsync(customer);

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

				response.Data = await this._customersDomain.DeleteAsync(customersId);

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
		public async Task<Response<CustomersDto>> GetAsync(string customersId)
		{
			var response = new Response<CustomersDto>();

			try
			{
				var customer = await this._customersDomain.GetAsync(customersId);
				response.Data = this._mapper.Map<CustomersDto>(customer);

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
		public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
		{
			var response = new Response<IEnumerable<CustomersDto>>();

			try
			{
				var customers = await this._customersDomain.GetAllAsync();
				response.Data = this._mapper.Map<IEnumerable<CustomersDto>>(customers);

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

		#endregion
	}
}