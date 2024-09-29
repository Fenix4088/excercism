namespace Exercism.BethanyShop.Enteties.Products;

public class OrderItem(string productId, string productName, int amountOrdered)
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public int AmountOrdered { get; private set; } = amountOrdered;
    public string ProductId { get; private set; } = productId;
    public string ProductName { get; private set; } = productName;

    public override string ToString() =>
        $"Product ID: {ProductId} - Name: {ProductName} - Amount ordered: {AmountOrdered}";
}