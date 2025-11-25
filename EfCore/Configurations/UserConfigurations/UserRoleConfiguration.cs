using Domain.Aggregates.UserManagementAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.UserConfigurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(ur => ur.UserId)
              .IsRequired();

        builder.HasOne<Role>()
              .WithMany()
              .HasForeignKey(ur => ur.RoleId)
              .IsRequired();
    }
}

