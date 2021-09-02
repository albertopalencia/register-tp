using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess
{
	/// <summary>
	/// Class TestContext.
	/// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class TestContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TestContext" /> class.
		/// </summary>
		public TestContext()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TestContext" /> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public TestContext(DbContextOptions<TestContext> options ) : base(options)
		{
			
		}


		/// <summary>
		/// Gets or sets the municipios.
		/// </summary>
		/// <value>The proyects.</value>
		public virtual DbSet<MunicipioEntity> Municipios { get; set; }


		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		/// <value>The users.</value>
		public virtual DbSet<IdentificationTypeEntity> IdentificationTypes { get; set; }


		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		/// <value>The users.</value>
		public virtual DbSet<UserEntity> Users { get; set; }

 
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}