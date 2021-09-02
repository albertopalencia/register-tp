using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.Municipio;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class MunicipioService : IMunicipioService
	{
		private readonly IMunicipioRepository _repository;

		public MunicipioService(IMunicipioRepository repository)
		{
			_repository = repository;
		}

		public async Task<ResponseGenericDto<List<MunicipioListDto>>> Municipios()
		{
			var getAll = await _repository.GetAllAsync();
			var list = getAll.Select<MunicipioEntity ,MunicipioListDto>(p => p).ToList();
			return new ResponseGenericDto<List<MunicipioListDto>> { Success  = true, Result = list };
		}
	}
}