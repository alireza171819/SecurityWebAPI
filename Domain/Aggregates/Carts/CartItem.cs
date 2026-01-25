using Domain.Common;
using Domain.Exceptions;

namespace Domain.Aggregates.Carts;

internal class CartItem : AuditableEntity
{
    private CartItem() {}

    public CartItem(int productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }

    public int ProductId { get; private set; }
    public int Quantity { get; private set; }

    internal void IncreaseQuantity(int amount)
    {
        if (amount <= 0)
            throw new DomainException();

        Quantity += amount;
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount <= 0)
            throw new DomainException();

        if (Quantity - amount <= 0)
            throw new DomainException("Quantity cannot be zero.");

        Quantity -= amount;
    }
}
