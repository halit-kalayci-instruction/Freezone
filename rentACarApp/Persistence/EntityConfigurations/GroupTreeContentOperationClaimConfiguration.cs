using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GroupTreeContentOperationClaimConfiguration : IEntityTypeConfiguration<GroupTreeContentOperationClaim>
{
    public void Configure(EntityTypeBuilder<GroupTreeContentOperationClaim> builder)
    {
        builder.ToTable("GroupTreeContentOperationClaims");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.GroupTreeContentId).HasColumnName("GroupTreeContentId");
        builder.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
    }
}