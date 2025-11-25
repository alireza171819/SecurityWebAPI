using Domain.Aggregates.UserManagementAggregates;
using EfCore;
using RepositoryDesignPattern.Contracts.Users;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services.Users
{
    public class UserRepository : BaseRepository<SecurityWebAPIContext, User, int>, IUserRepository
    {
        #region Constructor
        public UserRepository(SecurityWebAPIContext context) : base(context)
        {
        }
        #endregion
    }
}
