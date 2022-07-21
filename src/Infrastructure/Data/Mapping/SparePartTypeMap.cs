using Colossus.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colossus.Infrastructure.Data.EF.Mapping
{
    public class SparePartTypeMap : IEntityTypeConfiguration<SparePartType>
    {
        public void Configure(EntityTypeBuilder<SparePartType> builder)
        {

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Description)
                    .IsRequired();

            builder.ToTable("SparePartTypes");
        }
    }
}
