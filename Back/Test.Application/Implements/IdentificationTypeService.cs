using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application.Abstract;
using Test.Domain.DTO;
using Test.Domain.DTO.IdentificationType;
using Test.Domain.Entities;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Application.Implements
{
	public class IdentificationTypeService : IIdentificationTypeService
	{
		private readonly IIdentificationTypeRepository _repository;

		public IdentificationTypeService(IIdentificationTypeRepository repository)
		{
			_repository = repository;
		}

		public  async Task<ResponseGenericDto<List<IdentificationTypeListDto>>> IdentificationTypes()
		{
			var getAll = await _repository.GetAllAsync();
			var list = getAll.Select<IdentificationTypeEntity, IdentificationTypeListDto>(i => i).ToList();
			return new ResponseGenericDto<List<IdentificationTypeListDto>> { Success = true, Result = list };
		}
	}
}