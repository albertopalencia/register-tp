using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.Municipio;

namespace Test.Application.Abstract
{
	public interface IMunicipioService
	{
		Task<ResponseGenericDto<List<MunicipioListDto>>> Municipios();
	}
}