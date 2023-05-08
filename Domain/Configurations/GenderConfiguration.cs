using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Gender");
        builder.HasIndex(g => g.Name)
            .IsUnique()
            .HasFilter("IsDeleted = 0");
        
        //Pone un filtro por defecto a las entidades del modelo. En este caso, que no estén borrados
        // Los query filter no funcionan para los modelos compilados
        // builder.HasQueryFilter(g => !g.IsDeleted);

        //Create una propiedad sombra
        //builder.Property<DateTime>("DateCreate").HasDefaultValueSql("GetDate()").HasColumnType("datetime2");
    }
}