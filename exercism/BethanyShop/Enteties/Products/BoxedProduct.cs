
using System.Text;
using Exercism.BethanyShop.Enteties.Products;

namespace exercism.BethanyShop.Enteties.Products;

public class BoxedProduct(
    string name,
    Price price,
    int maxItemInStock,
    string? description,
    int amountInStock,
    int amountPerBox): Product(name, price, UnitType.PerBox, maxItemInStock, description, amountInStock)
{

    public int AmountPerBox { get; set; } = amountPerBox;
    public override void UseProduct(int items)
    {
        int smallestMultiple = 0;
        int batchSize;

        while (true)
        {
            smallestMultiple++;
            if (smallestMultiple * AmountPerBox > items)
            {
                batchSize = smallestMultiple * AmountPerBox;
                break;
            }
        }

        base.UseProduct(batchSize);

    }

    public override void IncreaseStock()
    {
        AmountInStock += AmountPerBox;
    }

    //these come boxed, so what we're getting in is the amount of boxes
    public override void IncreaseStock(int amount)
    {

        //it is possible to call the base here too, but we are assuming that this is handled differently

        int newStock = AmountInStock + amount * AmountPerBox;

        if (newStock <= maxItemInStock)
        {
            AmountInStock += amount * AmountPerBox;
        }
        else
        {
            AmountInStock = maxItemInStock;//we only store the possible items, overstock isn't stored
            Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordere that couldn't be stored.");
        }

        if (AmountInStock > StockTreshold)
        {
            IsBelowStockTreshold = false;
        }
    }

    public string ConvertToStringForSaving()
    {
        return $"{Id};{Name};{Description};{maxItemInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};1;{AmountPerBox};";
    }
    
    public override string DisplayDetailsFull()
    {
        //Console.WriteLine(name);
        StringBuilder sb = new StringBuilder();

        sb.Append("Boxed Product\n");

        sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

        if (IsBelowStockTreshold)
        {
            sb.Append("\n!!STOCK LOW!!");
        }

        return sb.ToString();
    }
    

}