using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
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
		[HttpPost(Name = "InsertCustomer")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
		[ProducesResponseType(400)]
		public IActionResult Insert([FromBody] CustomersDto customersDto)
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
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateCustomer", Name = "UpdateCustomer")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
		[ProducesResponseType(400)]
		public IActionResult Update([FromBody] CustomersDto customersDto)
		{
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
		[HttpDelete("DeleteCustomer/{customerId}", Name = "DeleteCustomer")]
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
		[HttpGet("GetCustomer/{customerId}", Name = "GetCustomerById")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public ActionResult<CustomersDto> Get(string customerId)
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
		[HttpGet("GetAllCustomers", Name = "GetAllCustomers")]
		[ProducesResponseType(typeof(IEnumerable<CustomersDto>), 200)]
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

		#endregion

		#region Métodos Asíncronos

		/// <summary>
		/// Inserts a new customer asynchronously.
		/// </summary>
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPost("InsertCustomerAsync", Name = "InsertCustomerAsync")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
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
		/// <param name="customersDto">The customer data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateCustomerAsync", Name = "UpdateCustomerAsync")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
		{
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
		[HttpDelete("DeleteCustomerAsync/{customerId}", Name = "DeleteCustomerAsync")]
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
		[HttpGet("GetCustomerAsync/{customerId}", Name = "GetCustomerAsyncById")]
		[ProducesResponseType(typeof(CustomersDto), 200)]
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
		[HttpGet("GetAllCustomersAsync", Name = "GetAllCustomersAsync")]
		[ProducesResponseType(typeof(IEnumerable<CustomersDto>), 200)]
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

		#endregion
	}
}
