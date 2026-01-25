using Domain.Common;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Aggregates.Orders;

public class Order : SoftDeletableEntity
{
    private Order() { }
    private readonly List<OrderDetial> _orderDetails = new();

    public Order(int userId, int cartId, DateTime orderDate, DateTime shipedDate, OrderNumber orderNumber, Address shippingAddress)
    {
        UserId = userId;
        CartId = cartId;
        OrderDate = orderDate;
        ShipedDate = shipedDate;
        OrderNumber = orderNumber;
        ShippingAddress = shippingAddress;
    }
    public int UserId { get; private set; }
    public int CartId { get; private set; }

    public DateTime OrderDate { get; private set; }
    public DateTime ShipedDate { get; private set; }
    public OrderNumber OrderNumber { get ; private set ; }
    public Address ShippingAddress { get; private set; }

    internal IReadOnlyCollection<OrderDetial> OrderDetails => _orderDetails.AsReadOnly();

    public void AddItem(int productId, decimal unitPrice, int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("quantity must be greater than zero.");

        _orderDetails.Add(new OrderDetial(productId, unitPrice, quantity));
        Touch();
    }

    public void ChangeItemQuantity(int productId, int quantity)
    {
        if (productId <= 0)
            throw new DomainException();

        var item = _orderDetails.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
            throw new DomainException();

        if (quantity <= 0)
        {
            _orderDetails.Remove(item);
            Touch();
            return;
        }

        item.ChangeQuantity(quantity);
        Touch();
    }
}
