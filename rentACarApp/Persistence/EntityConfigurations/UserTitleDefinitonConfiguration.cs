using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserTitleDefinitonConfiguration : IEntityTypeConfiguration<UserTitleDefiniton>
{
    public void Configure(EntityTypeBuilder<UserTitleDefiniton> builder)
    {
        builder.ToTable("UserTitleDefinitons");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.UserId).HasColumnName("UserId");
        builder.Property(p => p.HrTitleDefinitonId).HasColumnName("HrTitleDefinitonId");
    }
}