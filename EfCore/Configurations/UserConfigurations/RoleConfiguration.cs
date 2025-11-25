using Domain.Aggregates.UserManagementAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.UserConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(r => r.UUId)
                  .HasDefaultValueSql("NEWID()");
    }
}

