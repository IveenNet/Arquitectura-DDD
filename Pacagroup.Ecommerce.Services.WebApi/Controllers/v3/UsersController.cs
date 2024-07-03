using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers.v3
{
	/// <summary>
	/// Controlador para la autenticación de usuarios.
	/// </summary>
	[Authorize]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	[ApiVersion("3.0")]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly AppSettings _appSettings;

		/// <summary>
		/// Constructor del controlador UsersController.
		/// </summary>
		/// <param name="mediator">Interfaz de la aplicación de MediatR.</param>
		/// <param name="appSettings">Configuraciones de la aplicación.</param>
		public UsersController(IMediator mediator, IOptions<AppSettings> appSettings)
		{
			_mediator = mediator;
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// Autentica a un usuario.
		/// </summary>
		/// <param name="command">DTO del usuario a autenticar.</param>
		/// <returns>Respuesta con el token de autenticación si es exitoso.</returns>
		[AllowAnonymous]
		[HttpPost("authenticate", Name = "AuthenticateUserV3")]
		public async Task<IActionResult> Authenticate([FromBody] CreateUserTokenCommand command)
		{
			var response = await _mediator.Send(command);

			if (response.Data != null)
			{
				response.Data.Token = BuildToken(response);
				return Ok(response);
			}
			else
			{
				return NotFound(response);
			}

			return BadRequest(response);
		}

		/// <summary>
		/// Construye el token JWT para un usuario autenticado.
		/// </summary>
		/// <param name="userDto">DTO del usuario autenticado.</param>
		/// <returns>Token JWT como string.</returns>
		private string BuildToken(Response<UserDto> userDto)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, userDto.Data.UserId.ToString()),
                    // Agrega otros claims según sea necesario
                }),
				Expires = DateTime.UtcNow.AddMinutes(60), // Puedes ajustar el tiempo de expiración
				Issuer = _appSettings.Issuer,
				Audience = _appSettings.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
