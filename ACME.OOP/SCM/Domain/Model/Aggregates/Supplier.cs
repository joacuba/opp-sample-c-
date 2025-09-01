using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// Represent a supplier of products or services
/// </summary>
/// <param name="indentifier">The unique identifer for the supplier</param>
/// <param name="name">The name of the supplier</param>
/// <param name="address"> The <see cref="Address"/> object assigned to the supplier</param>
public class Supplier(string indentifier, string name, Address address)
{
    public string Indentifier { get; } = identifier ?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public Address Address { get; } = address ?? throw new ArgumentNullException(nameof(address));
}