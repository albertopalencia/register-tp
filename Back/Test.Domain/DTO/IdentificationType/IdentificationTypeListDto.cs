using Test.Domain.Entities;

namespace Test.Domain.DTO.IdentificationType
{
	public class IdentificationTypeListDto
	{
		public int Id { get; set; }
		public string Type { get; set; }


		public static implicit operator IdentificationTypeListDto(IdentificationTypeEntity entity)
		{
			return new()
			{
				Id = entity.Id,
				Type = entity.Type
			};
		}
	}
}