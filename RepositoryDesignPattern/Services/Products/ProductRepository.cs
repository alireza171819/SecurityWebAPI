using Domain.Aggregates.UserManagementAggregates;
using EfCore;
using Microsoft.EntityFrameworkCore;
using Model.DomainModels.ProductAggregates;
using RepositoryDesignPattern.Contracts.Products;
using RepositoryDesignPattern.Frameworks.Bases;
using ResponseFramework;

namespace RepositoryDesignPattern.Services.Products;
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

    #region Select()
    public override async Task<IResponse<List<Product>>> Select()
    {
        var q = await DbSet.AsNoTracking().Where(p => p.IsDeleted == false).ToListAsync();
        var response = new Response<List<Product>>(new List<Product>()) { Result = q };
        return response;
    }
    #endregion

    #region SelectByProductName()

    public async Task<IResponse<List<Product>>> Select(string name)
    {
        var q = await DbSet.AsNoTracking().Where(p => p.ProductName.Contains(name)).ToListAsync();
        var response = new Response<List<Product>>(new List<Product>()) { Result = q };
        return response;
    }
    #endregion
}
