using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;

namespace Model.DomainModels.ProductAggregates;

public class Order : BaseEntity, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
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
}
