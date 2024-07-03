using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Transversal.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v2
{
	[Authorize]
	[EnableRateLimiting("fixedWindow")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("2.0")]
	[SwaggerTag("Obtener Categorias del Producto")]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoriesApplication _categoriesApplication;

		public CategoriesController(ICategoriesApplication categoriesApplication)
		{
			_categoriesApplication = categoriesApplication;
		}

		/// <summary>
		/// Gets all categories.
		/// </summary>
		/// <returns>A list of categories.</returns>
		[HttpGet("GetAllCategories", Name = "GetAllCategoriesV2")]
		[SwaggerOperation(Summary = "Get Categories",
			Description = "This endpoint will return all categories",
			OperationId = "GetAllAsync",
			Tags = new string[] { "GetAll" })]
		[SwaggerResponse(200, "List of Categories", typeof(Response<IEnumerable<CategoryDto>>))]
		[SwaggerResponse(404, "Not found Categories", typeof(Response<IEnumerable<CategoryDto>>))]
		[ProducesResponseType(typeof(Response<IEnumerable<CategoryDto>>), 200)]
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
	}
}
