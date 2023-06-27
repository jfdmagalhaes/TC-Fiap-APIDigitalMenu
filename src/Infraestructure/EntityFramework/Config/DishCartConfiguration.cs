using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Config;
public class DishCartConfiguration : IEntityTypeConfiguration<DishCartEntity>
{
    public void Configure(EntityTypeBuilder<DishCartEntity> builder)
    {
        builder.ToTable("DishCart");

        builder.Property(p => p.CartId)
            .HasColumnName("cartid")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Quantity).HasColumnName("quantity").IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("unitprice").IsRequired();
        builder.Property(p => p.DishId).HasColumnName("dishid").IsRequired();

        builder.HasKey(p => p.CartId);
        builder.HasOne(p => p.DishEntity)
            .WithMany()
            .HasForeignKey(x => new { x.DishId });
    }
}