using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GroupTreeContentConfiguration : IEntityTypeConfiguration<GroupTreeContent>
{
    public void Configure(EntityTypeBuilder<GroupTreeContent> builder)
    {
        builder.ToTable("GroupTreeContents");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Title).HasColumnName("Title");
        builder.Property(p => p.ParentId).HasColumnName("ParentId");
        builder.Property(p => p.Target).HasColumnName("Target");
        builder.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(p => p.NavigateUrl).HasColumnName("NavigateUrl");
        builder.Property(p => p.RowOrder).HasColumnName("RowOrder");
        builder.Property(p => p.Type).HasColumnName("Type");
    }
}