namespace ACME.OOP.SCM.Domain.Model.ValueObjects;

/// <summary>
/// Rerepresent a unique identifier for a supplier
/// </summary>
public record SupplierId()
{
    public string Identifier { get; init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SupplierId"/> value object.
    /// </summary>
    /// param name="identifier">The unique identifier for the supplier.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null or empty.</exception>
    public SupplierId(string identifier)
    {
        if (string.IsNullOrEmpty(identifier))
            throw new ArgumentException("Supplier id cannot be null or empty.", nameof(identifier));
        Identifier = identifier;
    }
    
    /// <summary>
    /// override ToString method to return the identifier as a string.
    /// </summary>
    public override string ToString() => $"{Identifier}";
}