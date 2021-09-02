 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
	 
	public class MunicipioConfiguration : IEntityTypeConfiguration<MunicipioEntity>
	{
		 
		public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
		{
			builder.ToTable("Municipio");

			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id); 

			builder.Property(i => i.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder
				.HasMany(g => g.Users)
				.WithOne(s => s.Municipio)
				.HasForeignKey(h => h.MunicipioId);
		}
	}
}