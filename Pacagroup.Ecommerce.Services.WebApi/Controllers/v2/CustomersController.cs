using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{
    [Authorize]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("2.0")]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomersApplication _customersApplication;

		public CustomersController(ICustomersApplication customersApplication)
		{
			_customersApplication = customersApplication;
		}

		#region Métodos Síncronos

		/// <summary>
		/// Inserts a new customer.
		/// </summary>
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPost(Name = "InsertCustomerV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		public IActionResult Insert([FromBody] CustomerDto customersDto)
		{
			if (customersDto == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = _customersApplication.Insert(customersDto);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Updates an existing customer.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateCustomer/{customerId}", Name = "UpdateCustomerV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		public IActionResult Update(string customerId, [FromBody] CustomerDto customersDto)
		{
			var customerDto = _customersApplication.Get(customerId);

			if (customerDto == null) return NotFound(customerDto.Message);

			if (customersDto == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = _customersApplication.Update(customersDto);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Deletes a customer by ID.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpDelete("DeleteCustomer/{customerId}", Name = "DeleteCustomerV2")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult Delete(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = _customersApplication.Delete(customerId);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets a customer by ID.
		/// </summary>
		/// <param name="customerId">The customer ID.</param>
		/// <returns>The customer data.</returns>
		[HttpGet("GetCustomer/{customerId}", Name = "GetCustomerByIdV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public ActionResult<CustomerDto> Get(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = _customersApplication.Get(customerId);

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
		/// Gets all customers.
		/// </summary>
		/// <returns>A list of customers.</returns>
		[HttpGet("GetAllCustomers", Name = "GetAllCustomersV2")]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		public IActionResult GetAll()
		{
			var response = _customersApplication.GetAll();

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
		[HttpGet("GetAllCustomersWithPagination", Name = "GetAllCustomersWithPaginationV2")]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		public IActionResult GetAllWithPagination([FromQuery] int pageNumber, [FromQuery] int pageSize)
		{
			var response = _customersApplication.GetAllWithPagination(pageNumber, pageSize);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		#endregion

		#region Métodos Asíncronos

		/// <summary>
		/// Inserts a new customer asynchronously.
		/// </summary>
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPost("InsertCustomerAsync", Name = "InsertCustomerAsyncV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> InsertAsync([FromBody] CustomerDto customersDto)
		{
			if (customersDto == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = await _customersApplication.InsertAsync(customersDto);

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
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateCustomerAsync/{customerId}", Name = "UpdateCustomerAsyncV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> UpdateAsync(string customerId, [FromBody] CustomerDto customersDto)
		{
			var customerDto = _customersApplication.Get(customerId);

			if (customerDto == null) return NotFound(customerDto.Message);

			if (customersDto == null)
			{
				return BadRequest("Customer data cannot be null.");
			}

			var response = await _customersApplication.UpdateAsync(customersDto);

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
		[HttpDelete("DeleteCustomerAsync/{customerId}", Name = "DeleteCustomerAsyncV2")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> DeleteAsync(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _customersApplication.DeleteAsync(customerId);

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
		[HttpGet("GetCustomerAsync/{customerId}", Name = "GetCustomerAsyncByIdV2")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetAsync(string customerId)
		{
			if (string.IsNullOrEmpty(customerId))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _customersApplication.GetAsync(customerId);

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
		[HttpGet("GetAllCustomersAsync", Name = "GetAllCustomersAsyncV2")]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllAsync()
		{
			var response = await _customersApplication.GetAllAsync();

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
		[HttpGet("GetAllCustomersWithPaginationAsync", Name = "GetAllCustomersWithPaginationAsyncV2")]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
		{
			var response = await _customersApplication.GetAllWithPaginationAsync(pageNumber, pageSize);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		#endregion
	}
}
