using Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Users;

public class RoleConfiguration
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasQueryFilter(r => !r.IsDeleted);

        builder.Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
    }
}
