using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Domain.DTO;
using Test.Domain.DTO.IdentificationType;

namespace Test.Application.Abstract
{
	public interface IIdentificationTypeService
	{
		Task<ResponseGenericDto<List<IdentificationTypeListDto>>> IdentificationTypes();
	}
}