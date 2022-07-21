using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colossus.Infrastructure.Data.EF.Mapping
{
    public class SparePartMap : IEntityTypeConfiguration<SparePart>
    {
        public void Configure(EntityTypeBuilder<SparePart> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Description)
                    .IsRequired();

            builder.ToTable("SpareParts");
        }
    }
}
