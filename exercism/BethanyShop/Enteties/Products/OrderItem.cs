namespace Exercism.BethanyShop.Enteties.Products;

public class OrderItem(string productId, string productName, int amountOrdered)
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public int AmountOrdered { get;  set; } = amountOrdered;
    public string ProductId { get;  set; } = productId;
    public string ProductName { get;  set; } = productName;

    public override string ToString() =>
        $"Product ID: {ProductId} - Name: {ProductName} - Amount ordered: {AmountOrdered}";
}