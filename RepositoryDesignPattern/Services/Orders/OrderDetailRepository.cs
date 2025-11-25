using Domain.Aggregates.OrderAggregates;
using EfCore;
using RepositoryDesignPattern.Contracts.Orders;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services.Orders;

public class OrderDetailRepository : BaseRepository<SecurityWebAPIContext, OrderDetail, int>, IOrderDetailRepository
{
    #region Constructor
    public OrderDetailRepository(SecurityWebAPIContext context) : base(context)
    {
    }
    #endregion
}
