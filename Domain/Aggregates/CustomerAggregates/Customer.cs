using Domain.Aggregates.OrderAggregates;
using Domain.Aggregates.UserManagementAggregates;
using Domain.Frameworks.Abstracts;
using Domain.Frameworks.Bases;

namespace Domain.Aggregates.CustomerAggregates;

public class Customer : BaseEntity, ICreateOnDate, IUpdateOnDate, IActiveEntity, IDeletedEntity, IDbSetEntity
{
    public int UserId { get; set; }

    public User User { get; set; }

    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsActive { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }

    public ICollection<Order> Orders { get; set; }
}
