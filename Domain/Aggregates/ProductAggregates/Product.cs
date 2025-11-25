using Domain.Aggregates.OrderAggregates;
using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;

namespace Model.DomainModels.ProductAggregates;

public class Product : BaseEntity, ICodedEntity<long>, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public long Code { get ; set ; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
}
