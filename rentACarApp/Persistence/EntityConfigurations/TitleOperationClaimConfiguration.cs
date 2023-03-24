using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleOperationClaimConfiguration : IEntityTypeConfiguration<TitleOperationClaim>
{
    public void Configure(EntityTypeBuilder<TitleOperationClaim> builder)
    {
        builder.ToTable("TitleOperationClaims");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.TitleDefinitionId).HasColumnName("TitleDefinitionId");
        builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
    }
}