using ACME.OOP.Procurrement.Domain.Model.ValueObject;
using ACME.OOP.SCM.Domain.Model.Aggregates;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurrement.Domain.Model.Aggregates;

/// <summary>
/// Represent a purchase order aggregate for the Procurrement Bounded Context
/// Encapsulates information about a purchase order, including its order number, supplier, order date,
/// currency, and a collection of purchase order items.
/// </summary>
/// <param name="orderNumber">The unique order number for the purchase order.</param>
/// <param name="supplierId">The <see cref="SupplierId"/> unique identifier of the supplier from whom the order is placed.</param>
/// <param name="orderDate">The date when the order was placed.</param>
/// <param name="currency">The three-letter ISO currency code representing the currency used for the order (e.g., "USD", "EUR").</param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = new List<PurchaseOrderItem>();
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId Supplier { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;

    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3
        ? throw new ArgumentNullException(nameof(currency))
        : currency.ToUpper();

    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds a new item to the purchase order.
    /// </summary>
    /// <param name="productId">The <see cref="ProductId"/> unique identifier of the product being ordered.</param>
    /// <param name="quantity">The quantity of the product being ordered. Must be greater than zero.</param>
    /// <param name="unitPriceAmount">The unit price of the product as a decimal value. Must be non-negative.</param>
    /// <exception cref="ArgumentNullException">Thrown when productId is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if quantity is less than or equal to zero or if unit price is negative</exception>
    public PurchaseOrder AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount < 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit price cannot be negative.");

        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
        return this;
    }
    
    /// <summary>
    /// Calculates the total amount for the purchase order by summing the total of each item in the order.
    /// </summary>
    /// <returns>A <see cref="Money"/> object representing the total amount for the purchase order.</returns>
    public Money CalculateOrderTotal()
    {
        var totalAmount = _items.Sum(item => item.CalculateItemTotal().Amount);
        return new Money(totalAmount, Currency);
    }
}