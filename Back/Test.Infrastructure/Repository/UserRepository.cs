using Test.Domain.Entities;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;

namespace Test.Infrastructure.Repository
{
	 
	public class UserRepository : GenericRepository<UserEntity>, IUserRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UserRepository(TestContext context) : base(context)
		{
		}
	}
}