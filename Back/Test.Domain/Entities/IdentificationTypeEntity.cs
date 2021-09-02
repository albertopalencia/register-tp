using System.Collections.Generic;

namespace Test.Domain.Entities
{
	public class IdentificationTypeEntity : Entity
	{
		public IdentificationTypeEntity()
		{
			Users = new HashSet<UserEntity>();
		}
  
		/// <summary>
		/// Type
		/// </summary>
		public string Type { get; set; }


		public  ICollection<UserEntity> Users { get; set; }
	}
}