using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;

namespace Model.DomainModels.ProductAggregates;

public class OrderDetail : BaseEntity, ICodedEntity<long>, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
    public int UnitPrice { get; set; }
    public int Quantity { get; set; }
    public long Code { get ; set ; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }
}
