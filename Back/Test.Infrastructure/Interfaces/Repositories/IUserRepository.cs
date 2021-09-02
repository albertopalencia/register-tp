using Test.Domain.Entities;

namespace Test.Infrastructure.Interfaces.Repositories
{
	/// <summary>
	/// Interface IUserRepository
	/// </summary>
	public interface IUserRepository : IReadRepository<UserEntity>, ICreateRepository<UserEntity>, IUpdateRepository<UserEntity>
	{
		
	}
}