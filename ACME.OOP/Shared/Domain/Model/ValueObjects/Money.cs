namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represent an amount of money in a specific currency
/// </summary>
public record Money()
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    /// <summary>
    ///  creates a new instance of Money
    /// </summary>
    /// <param name="amount">The amount of money</param>
    /// <param name="currency">The currency of the money, must be a valid ISO 4217 code</param>
    /// <exception cref="ArgumentException">Thrown wshne amount is negative ro currency is invalid</exception>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be a valid ISO 4217 code.", nameof(currency));
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
    }
    
    /// <summary>
    /// Returns a string format
    /// </summary>
    public override string ToString() => $"{Amount} {Currency}";
}