using EfCore;
using Model.DomainModels.ProductAggregates;
using RepositoryDesignPattern.Contracts;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services;
/// <summary>
/// Repository implementation for <see cref="Product"/> entity.
/// Provides CRUD operations (Insert, Update, Delete, Select) using Entity Framework Core.
/// This repository communicates with the database via <see cref="SecurityWebAPIContext"/>.
/// </summary>
public class ProductRepository : BaseRepository<SecurityWebAPIContext, Product, int> , IProductRepository
{
    #region Constructor
    public ProductRepository(SecurityWebAPIContext context) : base(context)
    {
    }
    #endregion
}
