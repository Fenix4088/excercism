namespace Exercism.BethanyShop.Enteties.Products;

public class Order(List<OrderItem> orderItems)
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public DateTime OrderFulfilmentDate { get; private set; } = DateTime.Now.AddSeconds(new Random().Next(100));
    public bool Fulfilled { get; private set; }
    public List<OrderItem> OrderItems { get; set; } = orderItems;

}