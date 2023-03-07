using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.ModelId).HasColumnName("ModelId");
        builder.Property(p => p.Kilometer).HasColumnName("Kilometer");
        builder.Property(p => p.ModelYear).HasColumnName("ModelYear");
        builder.Property(p => p.Plate).HasColumnName("Plate");
        builder.Property(p => p.CarState).HasColumnName("CarState");
        builder.Property(p => p.MinFindeksCreditRate).HasColumnName("MinFindeksCreditRate");
    }
}