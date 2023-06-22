using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFramework.Config;
public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
{
    public void Configure(EntityTypeBuilder<DishEntity> builder)
    {
        builder.ToTable("dish");
        
        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .UseIdentityColumn()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name).HasColumnName("name").HasMaxLength(60);
        builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(100);
        builder.Property(p => p.Price).HasColumnName("price");
        builder.Property(p => p.AttachmentName).HasColumnName("attachmentname");

        builder.HasKey(p => p.Id);
    }
}