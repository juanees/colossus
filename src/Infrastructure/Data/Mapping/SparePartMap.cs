using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colossus.Infrastructure.Data.Mapping
{
    public class SparePartMap : IEntityTypeConfiguration<SparePart>
    {
        public void Configure(EntityTypeBuilder<SparePart> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.ExternalId)           
               .HasConversion(
              v => v.Value,
              v => Id.From(v))
               .IsRequired();

            builder.HasIndex(u => u.ExternalId)
                .IsUnique();

            builder.Property(t => t.Description)
                    .IsRequired();

            builder.ToTable("SpareParts");
        }
    }
}
