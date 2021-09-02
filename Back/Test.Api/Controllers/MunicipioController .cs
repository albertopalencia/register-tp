using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Municipio;

namespace Test.Api.Controllers
{
	/// <summary>
	/// Servicio de municipio
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class MunicipioController : ControllerBase
	{
		private readonly IMunicipioService _service;

		/// <summary>
		/// Metodo Constructor
		/// </summary>
		/// <param name="service"></param>
		public MunicipioController(IMunicipioService service)
		{
			_service = service;
		}

		/// <summary>
		/// Obtiene la lista  de los municipios
		/// </summary>
		/// <returns></returns>
		[HttpGet("List")]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseGenericDto<List<MunicipioListDto>>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Municipios()
		{
			var result = await _service.Municipios();
			return Ok(result);
		}
	}
}