using Etl.Domain.Entities.University;
using Etl.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Etl.Infrastructure.Configurations.UniversityConfigutation
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable("universities");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                id => id.Value,
                value => UniversityId.Create(value));

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(v => v.Country)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

            builder.Property(u => u.Site)
                .IsRequired();
        }
    }
}
