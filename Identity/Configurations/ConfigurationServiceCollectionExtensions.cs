
using Identity.Entities;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigurationServiceCollectionExtensions
{
    public static void AddConfigurationIdentity(this IServiceCollection services, IConfiguration config)
    {
        

        builder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(rt => rt.Id);

            entity.Property(rt => rt.Value).IsRequired();
            entity.Property(rt => rt.ExpiresAt).IsRequired();
            entity.Property(rt => rt.IsRevoked).HasDefaultValue(false);
            entity.Property(rt => rt.CreatedAt).IsRequired();
        });
    }
}
