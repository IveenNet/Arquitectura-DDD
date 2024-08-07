﻿using AutoMapper;
using MediatR;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Transversal.Common;

namespace Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetAllCustomerQuery
{
	public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, Response<IEnumerable<CustomerDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<Response<IEnumerable<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
		{

			var response = new Response<IEnumerable<CustomerDto>>();
			var customer = await _unitOfWork.Customers.GetAllAsync();
			response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customer);

			if (response.Data != null)
			{
				response.IsSuccess = true;
				response.Message = "Consulta OK";
			}

			return response;

		}
	}
}
