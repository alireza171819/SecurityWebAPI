using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.DomainModels.ProductAggregates;

namespace EfCore.Configurations.ProductConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasMany(p => p.OrderDetails)
                  .WithOne(od => od.Product)
                  .HasForeignKey(od => od.ProductId)
                  .OnDelete(DeleteBehavior.Restrict); // prevent deleting product if it has order details

        builder.Property(p => p.UUId).HasDefaultValueSql("NEWID()");
    }
}
