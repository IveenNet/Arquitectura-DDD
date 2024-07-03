using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.DeleteCustomerCommand;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Commands.UpdateCustomerCommand;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetAllCustomerQuery;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery;
using Pacagroup.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v3
{
	[Authorize]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("3.0")]
	public class CustomersController : ControllerBase
	{

		private readonly IMediator _mediator;

		public CustomersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		#region Métodos Asíncronos

		/// <summary>
		/// Inserts a new customer asynchronously.
		/// </summary>
		/// <param name="command">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPost("InsertCustomerAsync", Name = "InsertCustomerAsyncV3")]
		[ProducesResponseType(typeof(CreateCustomerCommand), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> InsertAsync([FromBody] CreateCustomerCommand command)
		{
			if (command == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = await _mediator.Send(command);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Updates an existing customer asynchronously.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <param name="command">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateCustomerAsync/{customerId}", Name = "UpdateCustomerAsyncV3")]
		[ProducesResponseType(typeof(UpdateCustomerCommand), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] UpdateCustomerCommand command)
		{
			var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });

			if (customerDto == null) return NotFound(customerDto.Message);

			if (command == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = await _mediator.Send(command);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Deletes a customer by ID asynchronously.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpDelete("DeleteCustomerAsync/{customerId}", Name = "DeleteCustomerAsyncV3")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> DeleteAsync(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = customerId });

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets a customer by ID asynchronously.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <returns>The customer data.</returns>
		[HttpGet("GetCustomerAsync/{customerId}", Name = "GetCustomerAsyncByIdV3")]
		[ProducesResponseType(typeof(GetCustomerQuery), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetAsync(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });

			if (response == null)
			{
				return NotFound($"Customer with Id {customerId} not found.");
			}

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets all customers asynchronously.
		/// </summary>
		/// <returns>A list of customers.</returns>
		[HttpGet("GetAllCustomersAsync", Name = "GetAllCustomersAsyncV3")]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllAsync()
		{
			var response = await _mediator.Send(new GetAllCustomerQuery());

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets all customers but now with Pagination.
		/// </summary>
		/// <param name="pageNumber">Number of the page.</param>
		/// <param name="pageSize">Number of customers to display.</param>
		/// <returns>A list of customers.</returns>
		[HttpGet("GetAllCustomersWithPaginationAsync", Name = "GetAllCustomersWithPaginationAsyncV3")]
		[ProducesResponseType(typeof(IEnumerable<GetAllWithPaginationCustomerQuery>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
		{
			var response = await _mediator.Send(new GetAllWithPaginationCustomerQuery()
			{
				PageNumber = pageNumber,
				PageSize = pageSize
			});

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		#endregion

	}
}
