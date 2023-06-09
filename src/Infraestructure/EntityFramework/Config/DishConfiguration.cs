using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Config;
public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
{
    public void Configure(EntityTypeBuilder<DishEntity> builder)
    {
        builder.ToTable("Dish");
        
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.Value).HasColumnName("value");

        builder.HasKey(p => p.Id);
    }
}