using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.IdentificationType;

namespace Test.Api.Controllers
{
	/// <summary>
	/// Servicio tipo de identificacion
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class IdentificationTypeController : ControllerBase
	{
		private readonly IIdentificationTypeService _service;

		/// <summary>
		/// Metodo Constructor
		/// </summary>
		/// <param name="service"></param>
		public IdentificationTypeController(IIdentificationTypeService service)
		{
			_service = service;
		}

		/// <summary>
		/// Obtiene la lista de tipos de identificacion
		/// </summary>
		/// <returns></returns>
		[HttpGet("List")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<IdentificationTypeListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> IdentificationTypes()
		{
			var result = await _service.IdentificationTypes();
			return Ok(result);
		}
	}
}