using Domain.Aggregates.CustomerAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Configurations.CustomerConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasOne(x => x.User)
             .WithOne() 
             .HasForeignKey<Customer>(x => x.UserId)
             .OnDelete(DeleteBehavior.Restrict); // do not auto-delete orders if customer is removed


        builder.Property(c => c.UUId).HasDefaultValueSql("NEWID()");
    }
}
