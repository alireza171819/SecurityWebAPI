using ApplicationService.Dtos.OrderDtos;
using ApplicationService.Services.Contracts.OrderContracts;
using Domain.Aggregates.OrderAggregates;
using RepositoryDesignPattern.Contracts.Orders;
using ResponseFramework;
using System.Net;

namespace ApplicationService.Services.OrderServices;
/// <summary>
/// Application service for managing <see cref="Order"/> entities.
/// Acts as a bridge between the repository layer (<see cref="IOrderRepository"/>)
/// and higher-level layers such as controllers or APIs.
/// Provides business logic and DTO mapping for CRUD operations.
/// </summary>
public class OrderService : IOrderService
{
    #region Privet Fields
    private readonly IOrderRepository _orderRepository;
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new instance of <see cref="OrderService"/>.
    /// </summary>
    /// <param name="orderRepository">Repository used for Order persistence operations.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="orderRepository"/> is null.</exception>
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    #endregion

    #region Post()
    /// <summary>
    /// Creates a new Order.
    /// 
    /// Notes:
    /// - Generates a new UUID when not provided (Guid.Empty)
    /// - Sets creation/update timestamps on insert
    /// - Returns an <see cref="IResponse{T}"/> describing success/failure for API usage
    /// </summary>
    /// <param name="postOrderDto">Input DTO containing order data.</param>
    /// <returns>Success flag wrapped in a response object.</returns>
    public async Task<IResponse<bool>> Post(PostOrderDto postOrderDto)
    {
        if (postOrderDto is null)
            return new Response<bool>("Model is null .", HttpStatusCode.BadRequest);

        var order = new Order();
        order.ShipRegion = postOrderDto.ShipRegion;
        order.ShipCity = postOrderDto.ShipCity;
        order.ShipCountry = postOrderDto.ShipCountry;
        order.ShipAddress = postOrderDto.ShipAddress;
        order.ShipPostalCode = postOrderDto.ShipPostalCode;
        order.ShipedDate = postOrderDto.ShipedDate;
        order.ShipName = postOrderDto.ShipName;
        order.OrderDate = DateTime.Now;
        order.UUId = postOrderDto.UUId == Guid.Empty ? Guid.NewGuid() : postOrderDto.UUId;
        order.Code = postOrderDto.Code;
        order.GregorianDateCreate = DateTime.Now;
        order.GregorianDateUpdate = DateTime.Now;

        var response = await _orderRepository.InsertAsync(order);

        if (!response.IsSuccessful)
            return new Response<bool>(response.ErrorMessage, HttpStatusCode.InternalServerError);

        return new Response<bool>(true);
    }

    #endregion

    #region Put()
    /// <summary>
    /// Updates an existing Order by replacing editable fields.
    /// 
    /// Notes:
    /// - Validates that Id is present
    /// - Updates only the fields provided by PutOrderDto
    /// - Sets update timestamp on update
    /// </summary>
    /// <param name="putOrderDto">Input DTO containing updated order data.</param>
    /// <returns>Success flag wrapped in a response object.</returns>
    public async Task<IResponse<bool>> Put(PutOrderDto putOrderDto)
    {
        if (putOrderDto is null)
            return new Response<bool>("Model is null .", HttpStatusCode.BadRequest);
        if (putOrderDto.Id <= 0)
            return new Response<bool>("Id is required .", HttpStatusCode.BadRequest);

        Order order = new();
        order.Id = putOrderDto.Id;
        order.OrderDate = putOrderDto.OrderDate;
        order.ShipAddress = putOrderDto.ShipAddress;
        order.ShipCity = putOrderDto.ShipCity;
        order.ShipRegion = putOrderDto.ShipRegion;
        order.ShipPostalCode = putOrderDto.ShipPostalCode;  
        order.ShipCountry = putOrderDto.ShipCountry;
        order.ShipName = putOrderDto.ShipName;
        order.Code = putOrderDto.Code;
        order.UUId = putOrderDto.UUId == Guid.Empty ? Guid.NewGuid() : putOrderDto.UUId;
        order.GregorianDateUpdate = DateTime.Now;

        var response = await _orderRepository.UpdateAsync(order);

        if (!response.IsSuccessful)
            return new Response<bool>(response.ErrorMessage, HttpStatusCode.InternalServerError);

        return new Response<bool>(true);
    }
    #endregion

    #region Delete()
    /// <summary>
    /// Deletes a Order by deleteOrderDto.
    /// 
    /// Notes:
    /// - First checks existence via FindByIdAsync
    /// - Then performs delete by repository
    /// </summary>
    /// <param name="deleteOrderDto">Input DTO containing the Id to delete.</param>
    /// <returns>Success flag wrapped in a response object.</returns>
    public async Task<IResponse<bool>> Delete(DeleteOrderDto deleteOrderDto)
    {
        if (deleteOrderDto is null)
            return new Response<bool>("deleteProductDto is null .", HttpStatusCode.BadRequest);

        var response = await _orderRepository.FindByIdAsync(deleteOrderDto.Id);

        if (!response.IsSuccessful)
            return new Response<bool>(response.ErrorMessage, HttpStatusCode.NotFound);

        var responseDelete = await _orderRepository.DeleteAsync(response.Result.Id);

        if (!responseDelete.IsSuccessful)
            return new Response<bool>(responseDelete.ErrorMessage, HttpStatusCode.InternalServerError);

        return new Response<bool>(true);
    }
    #endregion

    #region GetById()
    /// <summary>
    /// Retrieves a single order by Id.
    /// 
    /// Notes:
    /// - Validates Id is not zero
    /// - Returns NotFound when repository returns null result
    /// - Maps entity to GetByIdOrderDto
    /// </summary>
    /// <param name="getByIdOrder">DTO containing the Id of the order to fetch.</param>
    /// <returns>A order DTO wrapped in an <see cref="IResponse{T}"/>.</returns>
    public async Task<IResponse<SingleOrderDto>> GetById(GetByIdOrderDto getByIdOrder)
    {
        if (getByIdOrder.Id == 0)
            return new Response<SingleOrderDto>("Id is empty .", HttpStatusCode.BadRequest);

        var response = await _orderRepository.FindByIdAsync(getByIdOrder.Id);

        if (response.Result is null)
            return new Response<SingleOrderDto>(response.ErrorMessage, HttpStatusCode.NotFound);

        var order = response.Result;
        SingleOrderDto orderDto = new();
        orderDto.Id = order.Id;
        orderDto.OrderDate = order.OrderDate;
        orderDto.UserId = order.UserId;
        orderDto.ShipAddress = order.ShipAddress;
        orderDto.ShipedDate = order.ShipedDate;
        orderDto.ShipCity = order.ShipCity;
        orderDto.ShipRegion = order.ShipRegion;
        orderDto.ShipName = order.ShipName;  
        orderDto.ShipPostalCode = order.ShipPostalCode;
        orderDto.ShipCountry = order.ShipCountry;   
        orderDto.Code = order.Code;
        orderDto.UUId = order.UUId;

        return new Response<SingleOrderDto>(orderDto, true, "The process was completed successfully.", "", HttpStatusCode.OK);
    }
    #endregion
}
