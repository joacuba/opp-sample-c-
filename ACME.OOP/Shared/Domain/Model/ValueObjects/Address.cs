namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represent an international physicall address
/// </summary>
public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string StateOrRegion { get; init; }
    public string ZipCode { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="street"></param>
    /// <param name="number"></param>
    /// <param name="city"></param>
    /// <param name="stateOrRegion"></param>
    /// <param name="zipCode"></param>
    /// <param name="postalCode"></param>
    /// <param name="country"></param>
    /// <exception cref="ArgumentException"></exception>

    public Address(string street, string number, string city, string stateOrRegion, string zipCode, string postalCode,
        string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or whitespace.", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Number cannot be null or whitespace.", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or whitespace.", nameof(city));
        if (string.IsNullOrWhiteSpace(stateOrRegion))
            throw new ArgumentException("State Or Region cannot be null or whitespace.", nameof(stateOrRegion));
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("Zip Code cannot be null or whitespace.", nameof(zipCode));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal Code cannot be null or whitespace.", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or whitespace.", nameof(country));
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        ZipCode = zipCode;
        PostalCode = postalCode;
        Country = country;
    }

    /// <summary>
    /// Returns a string format
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
        $"{Street}, {Number}, {City}, {StateOrRegion}, {ZipCode}, {PostalCode}, {Country}";
}