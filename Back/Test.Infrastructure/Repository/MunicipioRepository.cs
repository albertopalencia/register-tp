using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	public class MunicipioRepository : GenericRepository<MunicipioEntity>, IMunicipioRepository
	{
		public MunicipioRepository(TestContext context) : base(context)
		{
		}
	}
}