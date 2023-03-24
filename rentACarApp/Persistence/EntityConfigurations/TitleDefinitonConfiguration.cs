using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleDefinitonConfiguration : IEntityTypeConfiguration<TitleDefinition>
{
    public void Configure(EntityTypeBuilder<TitleDefinition> builder)
    {
        builder.ToTable("TitleDefinitons");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
    }
}