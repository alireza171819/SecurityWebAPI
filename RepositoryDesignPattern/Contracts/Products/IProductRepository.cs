using Model.DomainModels.ProductAggregates;
using RepositoryDesignPattern.Frameworks.Abstracts;

namespace RepositoryDesignPattern.Contracts.Products;

public interface IProductRepository : IBaseRepository<Product, int> 
{

}
