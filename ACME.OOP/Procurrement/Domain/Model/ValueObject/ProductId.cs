namespace ACME.OOP.Procurrement.Domain.Model.ValueObject;

/// <summary>
/// Represent a unique identifier for a product
/// </summary>
public record ProductId()
{
    /// <summary>
    /// The unique identifier for the product
    /// </summary>
    public Guid Id { get; init; }

    public ProductId(Guid id)
    {
        if(id == Guid.Empty)
            throw new ArgumentException("Product id cannot be an empty UUID.", nameof(id));
        Id = id;
    }
    
    /// <summary>
    /// Generates a new <see cref="ProductId"/> with a unique UUID.
    /// </summary>
    /// <returns>A new instance of <see cref="ProductId"/> with a newly generated GUID.</returns>
    public static ProductId New() => new(Guid.NewGuid());
    
    /// <summary>
    /// Override ToString method to return the identifier as a string.
    /// </summary>
    public override string ToString() => Id.ToString();
}