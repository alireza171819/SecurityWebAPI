using Domain.Aggregates.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CartId).IsRequired();

        builder.OwnsOne(x => x.OrderNumber, on =>
        {
            on.Property(o => o.Value)
              .HasColumnName("OrderNumber")
              .HasMaxLength(50)
              .IsRequired();
        });

        builder.OwnsOne(x => x.ShippingAddress, address =>
        {
            address.Property(a => a.City).HasMaxLength(100).IsRequired();
            address.Property(a => a.Street).HasMaxLength(200).IsRequired();
            address.Property(a => a.PostalCode).HasMaxLength(20).IsRequired();
        });

        builder.HasMany("_orderDetails")
               .WithOne()
               .HasForeignKey("OrderId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation("_orderDetails")
               .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.Property(x => x.Uuid).HasDefaultValueSql("NEWID()");
    }
}
