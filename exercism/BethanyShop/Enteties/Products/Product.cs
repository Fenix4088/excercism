using System.Text;

namespace Exercism.BethanyShop.Enteties.Products;


public class Product
{

    public static int StockTreshold = 5;

    private string name;
    private string description;
    private int amountInStock;
    protected const int maxItemInStock = 100;
    private static readonly Price price = new(0, Currency.Dollar);
    public string? Description
    {
        get => description;
        set => description = (value ?? string.Empty).Length > 250 ? value[..250] : value ?? string.Empty;
    }
    public string Name {
        get => name;
        set => name = value.Length > 50 ? value[..50] : value;
    }
    public int MaxItemInStock { get; set; } = maxItemInStock;
    
    // private int amoutInStock;

    public int AmountInStock
    {
        get => amountInStock;
        protected set
        {
            amountInStock = value;
            UpdateLowStock();
        }
    }

    public Price Price { get; set; } = price;
    public UnitType UnitType { get; set; }
    public string Id { get; private set; } = Guid.NewGuid().ToString("N");

    public bool IsBelowStockTreshold { get;  protected set; }
    
    public Product(
        string name,
        Price price,
        UnitType unitType,
        int maxItemInStock = 0,
        string? description = null,
        int amountInStock = 0)
    {
        Name = name;
        Price = price;
        UnitType = unitType;
        MaxItemInStock = maxItemInStock;
        Description = description;
        AmountInStock = amountInStock;
        UpdateLowStock();
    }
    
    public static void ChangeStockTreshold(int newTreshold) {
        if (newTreshold > 0) StockTreshold = newTreshold;
    }


    public virtual void UseProduct(int items)
    {
        if (items <= AmountInStock)
        {
            AmountInStock -= items;

            UpdateLowStock();

            Log($"Amount in stock updated. Now {AmountInStock} items in stock.");
            return;
        }

        Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested.");
    }

    public virtual void IncreaseStock() => AmountInStock ++;

    public virtual void IncreaseStock(int amount)
    {
        int newStock = AmountInStock + amount;

        if (newStock <= maxItemInStock)
        {
            AmountInStock += amount;
        }
        else
        {
            AmountInStock = maxItemInStock;
            Log($"{CreateSimpleProductRepresentation()} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be store.");
        }

        if (amountInStock > StockTreshold) IsBelowStockTreshold = false;

    }

    public virtual string DisplayDetailsShort() => $"{Id}. {Name} \n{AmountInStock} items in stock";

    public virtual string DisplayDetailsFull() => DisplayDetailsFull("");
    
    public virtual string DisplayDetailsFull(string extraDetails)
    {
        StringBuilder sb = new();
        //ToDo: add price here too
        sb.Append($"{Id} {Name} \n{Description}\n{Price.ToString()}\n{AmountInStock} item(s) in stock");

        sb.Append(extraDetails);

        if (IsBelowStockTreshold)
        {
            sb.Append("\n!!STOCK LOW!!");
        }

        return sb.ToString();

    }

    public virtual void UpdateLowStock()
    {
        if (AmountInStock < StockTreshold) IsBelowStockTreshold = true;
    }
    
    protected virtual void DecreaseStock(int items, string reason)
    {
        AmountInStock = items <= AmountInStock ? AmountInStock - items : 0;

        UpdateLowStock();

        Log(reason);
    }
    
    protected virtual void Log(string message) => Console.WriteLine(message);

    protected virtual string CreateSimpleProductRepresentation() => $"Product {Id} ({Name})";
}
