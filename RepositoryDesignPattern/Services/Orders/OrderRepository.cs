using Domain.Aggregates.OrderAggregates;
using EfCore;
using RepositoryDesignPattern.Contracts.Orders;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services.Orders;

public class OrderRepository : BaseRepository<SecurityWebAPIContext, Order, int>, IOrderRepository
{
    #region Constructor
    public OrderRepository(SecurityWebAPIContext context) : base(context)
    {
    }
    #endregion
}
