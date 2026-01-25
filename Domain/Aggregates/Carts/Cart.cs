using Domain.Common;
using Domain.Exceptions;

namespace Domain.Aggregates.Carts;

public class Cart : SoftDeletableEntity
{
    private Cart() { }
    private readonly List<CartItem> _items = new();

    public Cart(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; private set; }

    internal IReadOnlyCollection<CartItem> CartItems => _items.AsReadOnly();

    public void AddItem(int productId, int quantity)
    {
        if (productId <= 0)
            throw new DomainException("productId is required.");

        if (quantity <= 0)
            throw new DomainException("quantity must be greater than zero.");

        var existingItem = _items.FirstOrDefault(x => x.ProductId == productId);

        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
        }

        _items.Add(new CartItem(productId, quantity));
        Touch();
    }

    public void RemoveItem(int productId)
    {
        if (productId <= 0)
            throw new DomainException("productId is required.");

        var item = _items.FirstOrDefault(x => x.ProductId == productId);
        if (item is null)
            return;

        _items.Remove(item);
        Touch();
    }
}
