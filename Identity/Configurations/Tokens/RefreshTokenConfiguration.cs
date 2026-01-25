using Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations.Tokens;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.OwnsOne(x => x.Value, tv =>
        {
            tv.Property(t => t.Value)
              .HasColumnName("Token")
              .HasMaxLength(500)
              .IsRequired();
        });

        builder.Property(x => x.ExpiresAt).IsRequired();
    }
}
