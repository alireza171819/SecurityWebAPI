using Domain.Aggregates.UserManagementAggregates;
using EfCore;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Contracts.Users;
using RepositoryDesignPattern.Frameworks.Bases;
using ResponseFramework;

namespace RepositoryDesignPattern.Services.Users
{
    public class UserRoleRepository : BaseRepository<SecurityWebAPIContext, UserRole, int>, IUserRepository
    {

        #region Constructor
        public UserRoleRepository(SecurityWebAPIContext context) : base(context)
        {

        }
        #endregion
    }
}
