using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{
	[Authorize]
	[EnableRateLimiting("fixedWindow")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("2.0")]

	public class DiscountsController : ControllerBase
	{

		private readonly IDiscountsApplication _discountsApplication;

		public DiscountsController(IDiscountsApplication discountsApplication)
		{
			_discountsApplication = discountsApplication;
		}

		#region Métodos Asincronos

		/// <summary>
		/// Creates a new discount asynchronously.
		/// </summary>
		/// <param name="discountDto">The Discount data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPost("CreateDiscountAsync", Name = "CreateDiscountAsyncV2")]
		[ProducesResponseType(typeof(DiscountDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> CreateAsync([FromBody] DiscountDto discountDto)
		{
			if (discountDto == null)
			{
				return BadRequest("Discount data cannot be null.");
			}

			var response = await _discountsApplication.CreateAsync(discountDto);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Updates an existing discount asynchronously.
		/// </summary>
		/// <param name="discountId">The discount ID.</param>
		/// <param name="discountDto">The discount data.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpPut("UpdateDiscountAsync/{customerId}", Name = "UpdateDiscountAsyncV2")]
		[ProducesResponseType(typeof(DiscountDto), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> UpdateDiscountAsync(int discountId, [FromBody] DiscountDto discountDto)
		{
			var discountDtoExists = await _discountsApplication.GetAsync(discountId);

			if (discountDtoExists == null) return NotFound(discountDtoExists.Message);

			if (discountDto == null)
			{
				return BadRequest("Discount data cannot be null.");
			}

			var response = await _discountsApplication.UpdateAsync(discountDto);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Deletes a discount by ID asynchronously.
		/// </summary>
		/// <param name="discountId">The discount ID.</param>
		/// <returns>Action result indicating success or failure.</returns>
		[HttpDelete("DeleteDiscountAsync/{discountId}", Name = "DeleteDiscountAsyncV2")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> DeleteAsync(int discountId)
		{
			if (string.IsNullOrEmpty(discountId.ToString()))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _discountsApplication.DeleteAsync(discountId);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets a discount by ID asynchronously.
		/// </summary>
		/// <param name="discountId">The discount ID.</param>
		/// <returns>The discount data.</returns>
		[HttpGet("GetDiscountAsync/{discountId}", Name = "GetDiscountAsyncV2")]
		[ProducesResponseType(typeof(DiscountDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetAsync(int discountId)
		{
			if (string.IsNullOrEmpty(discountId.ToString()))
			{
				return BadRequest("CustomerId cannot be null or empty.");
			}

			var response = await _discountsApplication.GetAsync(discountId);

			if (response == null)
			{
				return NotFound($"Customer with Id {discountId} not found.");
			}

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets all discounts asynchronously.
		/// </summary>
		/// <returns>A list of discounts.</returns>
		[HttpGet("GetAllDiscountsAsync", Name = "GetAllDiscountsAsyncV2")]
		[ProducesResponseType(typeof(IEnumerable<DiscountDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllAsync()
		{
			var response = await _discountsApplication.GetAllAsync();

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		/// <summary>
		/// Gets all discounts but now with Pagination.
		/// </summary>
		/// <param name="pageNumber">Number of the page.</param>
		/// <param name="pageSize">Number of discounts to display.</param>
		/// <returns>A list of discounts.</returns>
		[HttpGet("GetAllDiscountsWithPaginationAsync", Name = "GetAllDiscountsWithPaginationAsync")]
		[ProducesResponseType(typeof(IEnumerable<DiscountDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
		{
			var response = await _discountsApplication.GetAllWithPaginationAsync(pageNumber, pageSize);

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}


		#endregion

	}
}
