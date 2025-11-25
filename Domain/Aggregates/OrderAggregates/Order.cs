using Domain.Aggregates.CustomerAggregates;
using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;

namespace Domain.Aggregates.OrderAggregates;

public class Order : BaseEntity, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipedDate { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
}
