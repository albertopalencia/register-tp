using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using Test.Domain.Entities;

namespace Test.Infrastructure.DataAccess.Configurations
{
	 
	public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		 
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.ToTable("User");

			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id);

			builder.Property(e => e.IdentificationTypeId);
			
			builder.Property(e => e.IdentificationNumber) 
				.IsRequired() 
				.IsUnicode();

			builder.Property(e => e.CompanyName)  
				.HasMaxLength(100)
				.IsUnicode(false);

			builder.Property(e => e.FirstName)  
				   .HasMaxLength(200)
				   .IsUnicode(false);

			builder.Property(e => e.SecondName)
				.HasMaxLength(50)
				.IsUnicode(false);

			builder.Property(e => e.FirstLastName)
				.HasMaxLength(50)
				.IsUnicode(false);

			builder.Property(e => e.SecondLastName)
				.HasMaxLength(50)
				.IsUnicode(false);

			builder.Property(e => e.Address)
				.HasMaxLength(150)
				.IsRequired()
				.IsUnicode(false);

			builder.Property(i => i.Email) 
				   .HasMaxLength(80);


			builder.Property(i => i.CellPhone)
				.IsRequired()
				.HasMaxLength(15);

		}
	}
}