// See https://aka.ms/new-console-template for more information

using ACME.OOP.Procurrement.Domain.Model.Aggregates;
using ACME.OOP.Procurrement.Domain.Model.ValueObject;
using ACME.OOP.SCM.Domain.Model.Aggregates;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

// Example usage of the PurchaseOrder and Supplier classes
// Creating a supplier and a purchase order with items
var supplierAddress = new Address("Supplier St", "123", "Supplier City", "Supplier State", "12345", "54321", "Supplier Country");
var supplier = new Supplier("SUP001", "Microsoft, Inc.", supplierAddress);

var purchaseOrder = new PurchaseOrder("PO001", new SupplierId(supplier.Indentifier), DateTime.Now, "USD");
purchaseOrder.AddItem(ProductId.New(), 10, 25.99m)
             .AddItem(ProductId.New(), 20, 19.99m);

Console.WriteLine($"Purchase Order Number: {purchaseOrder.OrderNumber} created for the supplier: {supplier.Name}");
foreach (var item in purchaseOrder.Items)
{
    Console.WriteLine($"Order Item Total: {item.CalculateItemTotal()}");
}
Console.WriteLine($"Total Order Amount: {purchaseOrder.CalculateOrderTotal()}");