using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class IdentificationTypeRepository: GenericRepository<IdentificationTypeEntity>, IIdentificationTypeRepository
	{
		public IdentificationTypeRepository(TestContext context) : base(context)
		{
		}
	}
}