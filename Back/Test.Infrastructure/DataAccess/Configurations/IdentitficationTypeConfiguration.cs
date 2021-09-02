using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
	public class IdentitficationTypeConfiguration : IEntityTypeConfiguration<IdentificationTypeEntity>
	{
		public void Configure(EntityTypeBuilder<IdentificationTypeEntity> builder)
		{
			builder.ToTable("IdentificationType");

			builder.HasKey(i => i.Id);
			builder.Property(i => i.Id);

			builder.Property(i => i.Type)
					.IsRequired()
				   .HasMaxLength(100);

			builder
				.HasMany(g => g.Users)
				.WithOne(s => s.IdentificationType)
				.HasForeignKey(h => h.IdentificationTypeId);
		}
	}
}