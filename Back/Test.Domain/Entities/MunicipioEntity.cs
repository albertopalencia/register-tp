using System.Collections.Generic;

namespace Test.Domain.Entities
{
	/// <summary>
	/// Class MunicipioEntity.
	/// Implements the <see cref="Test.Domain.Entities.Entity" />
	/// </summary>
	/// <seealso cref="Test.Domain.Entities.Entity" />
	public class MunicipioEntity : Entity
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MunicipioEntity" /> class.
		/// </summary>
		public MunicipioEntity()
		{
			Users = new HashSet<UserEntity>();
		}

		/// <summary>
		/// Gets or sets the name of the municipios.
		/// </summary>
		/// <value>The name of the municipio.</value>
		public string Name { get; set; }


		public ICollection<UserEntity> Users { get; set; }

	}
}