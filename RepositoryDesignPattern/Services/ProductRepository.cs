using EfCore;
using Model.DomainModels.ProductAggregates;
using RepositoryDesignPattern.Contracts;
using RepositoryDesignPattern.Frameworks.Bases;

namespace RepositoryDesignPattern.Services;

public class ProductRepository : GenericRepository<SecurityWebAPIContext, Product, int> , IProductRepository
{

}
