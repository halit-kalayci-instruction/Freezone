using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.ToTable("CarImages");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.CarId).HasColumnName("CarId");
        builder.Property(p => p.Path).HasColumnName("Path");
    }
}