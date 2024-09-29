namespace Exercism.BethanyShop.Enteties.Products;

public class Price(double itemPrice, Currency currency)
{
    public double ItemPrice { get; set; } = itemPrice;
    public Currency Currency { get; set; } = currency;

    public override string ToString() => $"{ItemPrice} {Currency}";
}