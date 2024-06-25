using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{
	[Authorize]
	[EnableRateLimiting("fixedWindow")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("2.0")]
	public class CategoriesController : Controller
	{
		private readonly ICategoriesApplication _categoriesApplication;

		public CategoriesController(ICategoriesApplication categoriesApplication)
		{
			_categoriesApplication = categoriesApplication;
		}

		#region Métodos Síncronos


		/// <summary>
		/// Gets all categories.
		/// </summary>
		/// <returns>A list of categories.</returns>
		[HttpGet("GetAllCategories", Name = "GetAllCategoriesV2")]
		[ProducesResponseType(typeof(IEnumerable<CustomersDto>), 200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetAllAsync()
		{
			var response = await _categoriesApplication.GetAll();

			if (response.IsSuccess)
			{
				return Ok(response);
			}

			return BadRequest(response.Message);
		}

		#endregion


	}
}
