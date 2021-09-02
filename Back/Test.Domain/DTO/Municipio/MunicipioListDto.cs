using Test.Domain.Entities;

namespace Test.Domain.DTO.Municipio
{
	public class MunicipioListDto
	{
		public int Id { get; set; }
		public string Name { get; set; }


		public static implicit operator MunicipioListDto(MunicipioEntity entity)
		{
			return new()
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}