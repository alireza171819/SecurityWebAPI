using Domain.Aggregates.UserManagementAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.UserConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(r => r.UUId)
                  .HasDefaultValueSql("NEWID()");
    }
}

