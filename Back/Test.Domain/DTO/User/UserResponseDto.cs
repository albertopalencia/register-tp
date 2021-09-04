using Test.Domain.Entities;

namespace Test.Domain.DTO.User
{
	/// <summary>
	/// Class UserResponseDto.
	/// </summary>
	public class UserResponseDto
	{
		public int Id { get; set; }

		public int IdentificationTypeId { get; set; }
		public string IdentificationNumber { get; set; }
		public string CompanyName { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string FirstLastName { get; set; }
		public string SecondLastName { get; set; }
		public int MunicipioId { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public Nomenclature Nomenclature { get; set; }


		/// <summary>
		/// Performs an implicit conversion from <see cref="UserEntity"/> to <see cref="UserResponseDto"/>.
		/// </summary>
		/// <param name="entity">The user entity.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UserResponseDto(UserEntity entity)
		{
			var userEntityAddress = entity.Address;
			return new UserResponseDto()
			{
				Id = entity.Id,
				IdentificationNumber = entity.IdentificationNumber,
				IdentificationTypeId = entity.IdentificationTypeId,
				CompanyName = entity.CompanyName,
				FirstName = entity.FirstName,
				SecondName = entity.SecondName,
				FirstLastName = entity.FirstLastName,
				SecondLastName = entity.FirstLastName,
				MunicipioId = entity.MunicipioId,
				Email = entity.Email,
				CellPhone = entity.CellPhone,
				Nomenclature = Nomenclature.ParseNomenclature(entity.Address, ref userEntityAddress),
				Address = userEntityAddress
			};
		}
	}

	public class Nomenclature
	{
		public string Via { get; set; }
		public string Nro { get; set; }
		public string Letra { get; set; }
		public string Nro1 { get; set; }
		public string Letra1 { get; set; }
		public string NroComplemento { get; set; }

		public override string ToString()
		{
			return string.Join(" ", Via, Nro, Letra, Nro1, Letra1, NroComplemento);
		}

		public static Nomenclature ParseNomenclature(string param, ref string addressTransform)
		{
			var nomenclature = new Nomenclature();

			var address = param.Split("-");
			if (address.Length <= 0) return nomenclature;
			nomenclature.Via = address[0];
			nomenclature.Nro = address[1];
			nomenclature.Letra = address[2];
			nomenclature.Nro1 = address[3];
			nomenclature.Letra1 = address[4];
			nomenclature.NroComplemento = address[5];
			addressTransform = nomenclature.ToString();
			return nomenclature;

		}
	}
}