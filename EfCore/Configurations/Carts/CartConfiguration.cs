using Domain.Aggregates.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.Carts;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId).IsRequired();

        builder.HasMany("_items")
               .WithOne()
               .HasForeignKey("CartId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation("_items")
               .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
    }
}
