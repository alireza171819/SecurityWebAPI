using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;
using Model.DomainModels.ProductAggregates;

namespace Domain.Aggregates.OrderAggregates;

public class OrderDetail : IGuid, ICodedEntity<long>, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
    public Guid UUId { get ; set ; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }

    public int UnitPrice { get; set; }
    public int Quantity { get; set; }
    public long Code { get ; set ; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }
    
}
