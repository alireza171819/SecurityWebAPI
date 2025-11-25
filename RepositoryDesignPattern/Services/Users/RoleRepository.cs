using Domain.Aggregates.UserManagementAggregates;
using EfCore;
using RepositoryDesignPattern.Contracts.Users;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services.Users
{
    public class RoleRepository : BaseRepository<SecurityWebAPIContext, Role, int>, IRoleRepository
    {
        #region Constructor
        public RoleRepository(SecurityWebAPIContext context) : base(context)
        {
        }
        #endregion
    }
}
