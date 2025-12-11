using ApplicationService.Dtos.ProductDtos;
using ResponseFramework;

namespace ApplicationService.Services.Contracts.ProductContracts;
/// <summary>
/// Defines the contract for product-related application services.
/// 
/// Responsibilities:
/// - Accepts Product DTOs from the presentation layer (e.g., controllers)
/// - Performs CRUD operations through the service implementation
/// - Returns standardized results using <see cref="IResponse{T}"/> for consistent API responses
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="postProductDto">DTO containing the data required to create a product.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Post(PostProductDto postProductDto);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="putProductDto">DTO containing the product identifier and updated data.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Put(PutProductDto putProductDto);

    /// <summary>
    /// Deletes an existing product.
    /// </summary>
    /// <param name="deleteProductDto">DTO containing the identifier of the product to delete.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Delete(DeleteProductDto deleteProductDto);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>
    /// A standardized response containing a list wrapper DTO.
    /// </returns>
    Task<IResponse<ListProductDto>> GetAll();

    /// <summary>
    /// Retrieves a single product by its identifier.
    /// </summary>
    /// <param name="getByIdProductDto">DTO containing the identifier of the product to retrieve.</param>
    /// <returns>
    /// A standardized response containing the product data when found.
    /// </returns>
    Task<IResponse<SingleProductDto>> GetById(GetByIdProductDto getByIdProductDto);

}
