using Domain.Aggregates.OrderAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.OrderConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(od => new { od.OrderId, od.ProductId });

        builder.HasOne(x => x.Order)
         .WithMany(o => o.OrderDetails)
         .HasForeignKey(x => x.OrderId)
         .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
         .WithMany(p => p.OrderDetails)
         .HasForeignKey(x => x.ProductId)
         .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.UUId).IsUnique();

        builder.Property(x => x.UUId).HasDefaultValueSql("NEWID()");
    }
}
