using Domain.Aggregates.OrderAggregates;
using RepositoryDesignPattern.Frameworks.Abstracts;

namespace RepositoryDesignPattern.Contracts.Orders;

public interface IOrderRepository : IBaseRepository<Order, int> 
{
}
