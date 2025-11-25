using Domain.Aggregates.OrderAggregates;
using Domain.Frameworks.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace Domain.Aggregates.UserManagementAggregates;

public class User : IdentityUser<int>, IGuid, ICreateOnDate, IUpdateOnDate, IActiveEntity, IDeletedEntity, IDbSetEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid UUId { get; set; }
    public DateTime GregorianDateCreate { get ; set ; }
    public DateTime GregorianDateUpdate { get ; set ; }
    public bool IsActive { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime GregorianDateDeleted { get ; set ; }

    public ICollection<Order> Orders { get; set; }
}
