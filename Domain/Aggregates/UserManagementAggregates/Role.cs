using Domain.Frameworks.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace Domain.Aggregates.UserManagementAggregates;

public class Role : IdentityRole<int>, IGuid, ICreateOnDate, IUpdateOnDate, IDeletedEntity, IDbSetEntity
{
    public Guid UUId { get; set; }
    public DateTime GregorianDateCreate { get; set; }
    public DateTime GregorianDateUpdate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime GregorianDateDeleted { get; set; }
}
