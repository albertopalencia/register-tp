using Test.Domain.Entities;

namespace Test.Domain.DTO.User
{
	public class UserListDto
	{
		public int Id  { get; set; }
		public int IdentificationTypeId { get; set; }
		public string IdentificationType { get; set; }
		public string IdentificationNumber { get; set; }
		public string CompanyName { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string FirstLastName { get; set; }
		public string SecondLastName { get; set; }
		public string Municipio { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="UserEntity"/> to <see cref="UserListDto"/>.
		/// </summary>
		/// <param name="userEntity">The user entity.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UserListDto(UserEntity userEntity) =>
			new()
			{
				Id = userEntity.Id,
				IdentificationNumber = userEntity.IdentificationNumber,
				IdentificationTypeId = userEntity.IdentificationTypeId,
				IdentificationType = userEntity.IdentificationType?.Type,
				CompanyName = userEntity.CompanyName,
				FirstName = userEntity.FirstName,
				SecondName = userEntity.SecondName,
				FirstLastName = userEntity.FirstLastName,
				SecondLastName = userEntity.FirstLastName,
				Municipio = userEntity.Municipio?.Name,
				Address = userEntity.Address,
				Email = userEntity.Email,
				CellPhone = userEntity.CellPhone
			};

	}
}