using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.User;

namespace Test.Api.Controllers
{
	/// <summary>
	/// UserController
	/// </summary>
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		/// <summary>
		/// The user service
		/// </summary>
		private readonly IUserService _userService;

		 /// <summary>
		 ///  Constructor
		 /// </summary>
		/// <param name="userService"></param>
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		 /// <summary>
		 /// Obtiene la lista de todos los usuarios
		 /// </summary>
		 /// <param name="user">The identifier.</param>
		 /// <returns>Task&lt;IActionResult&gt;.</returns>
		 [HttpGet("List")]
		 [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<UserListDto>>))]
		 [ProducesResponseType((int)HttpStatusCode.BadRequest)]
		 public async Task<IActionResult> Users()
		 {
			 var list = await _userService.UserList();
			 return Ok(list);
		 }


		/// <summary>
		/// Consulta un usuario por el identificationNumber
		/// </summary>
		/// <param name="identificationNumber">The identifier.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpGet("Validate")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<UserResponseDto>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Validate(string identificationNumber)
		{
			var projects = await _userService.Validate(identificationNumber);
			return Ok(projects);
		}


		/// <summary>
		/// Crea un nuevo usuario
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns>Task&lt;IActionResult&gt;.</returns>
		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(ResponseGenericDto<bool>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> CreateUser(UserCreateDto user)
		{
			var userCreated = await _userService.Create(user);
			return CreatedAtAction("CreateUser", userCreated);
		}
	}
}