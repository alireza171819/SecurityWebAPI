
using ApplicationService.Dtos.OrderDtos;
using ResponseFramework;

namespace ApplicationService.Services.Contracts.OrderContracts;

/// <summary>
/// Defines the contract for order-related application services.
/// 
/// Responsibilities:
/// - Accepts Order DTOs from the presentation layer (e.g., controllers)
/// - Performs CRUD operations through the service implementation
/// - Returns standardized results using <see cref="IResponse{T}"/> for consistent API responses
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="postOrderDto">DTO containing the data required to create a order.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Post(PostOrderDto postOrderDto);

    /// <summary>
    /// Deletes an existing order.
    /// </summary>
    /// <param name="putOrderDto">DTO containing the identifier of the order to delete.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Put(PutOrderDto putOrderDto);

    /// <summary>
    /// Deletes an existing order.
    /// </summary>
    /// <param name="deleteOrderDto">DTO containing the identifier of the order to delete.</param>
    /// <returns>
    /// A standardized response where the value indicates whether the operation succeeded.
    /// </returns>
    Task<IResponse<bool>> Delete(DeleteOrderDto deleteOrderDto);

    /// <summary>
    /// Retrieves a single order by its identifier.
    /// </summary>
    /// <param name="getByIdOrderDto">DTO containing the identifier of the order to retrieve.</param>
    /// <returns>
    /// A standardized response containing the order data when found.
    /// </returns>
    Task<IResponse<SingleOrderDto>> GetById(GetByIdOrderDto getByIdOrderDto);
}
