using System.Text;

namespace Exercism.BethanyShop.Enteties.Products;

public class Order()
{
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");
    public DateTime OrderFulfilmentDate { get; private set; } = DateTime.Now.AddSeconds(new Random().Next(100));
    public bool Fulfilled { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new ();

    public string ShowOrderDetails()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Order ID: {Id}");
        sb.AppendLine($"Order fulfilment date: {OrderFulfilmentDate}");
        sb.AppendLine($"Order fulfilled: {Fulfilled}");
        sb.AppendLine("Order items:");
        foreach (var item in OrderItems)
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString();
    }

}