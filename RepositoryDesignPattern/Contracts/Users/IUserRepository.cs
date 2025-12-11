using Domain.Aggregates.UserManagementAggregates;
using RepositoryDesignPattern.Frameworks.Abstracts;

namespace RepositoryDesignPattern.Contracts.Users;

public interface IUserRepository : IBaseRepository<User, int>
{
}
