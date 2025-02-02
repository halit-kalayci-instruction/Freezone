using Freezone.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims");

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");

        builder.HasIndex(indexExpression: p => p.Name, name: "UK_OperationClaims_Name").IsUnique();

        List<OperationClaim> seed = new();
        int id = 0;

        #region FeatureOperationClaims
        seed.Add(new OperationClaim { Id = ++id, Name = "CarImages.Create" });
        seed.Add(new OperationClaim { Id = ++id, Name = "CarImages.Delete" });
        seed.Add(new OperationClaim { Id = ++id, Name = "CarImages.Update" });
        seed.Add(new OperationClaim { Id = ++id, Name = "CarImages.Get" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Transmissions.Create" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Transmissions.Delete" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Transmissions.Update" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Transmissions.Get" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Cars.Create" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Cars.Delete" });
        seed.Add(new OperationClaim { Id = ++id, Name = "Cars.Update" });
        seed.Add(new OperationClaim { Id = ++id, Name = "GroupTreeContentOperationClaims.Create" });
        seed.Add(new OperationClaim { Id = ++id, Name = "GroupTreeContentOperationClaims.Delete" });
        seed.Add(new OperationClaim { Id = ++id, Name = "GroupTreeContentOperationClaims.Update" });
        seed.Add(new OperationClaim { Id = ++id, Name = "GroupTreeContentOperationClaims.Get" });

        seed.Add(new OperationClaim { Id = ++id, Name = "Cars.Get" });
        #endregion

        builder.HasData(seed);
    }
}
