namespace Exercism.BethanyShop.Enteties;

public class Address(string street, string houseNumber, string zipCode, string city)
{
    public string Street { get; set; } = street;
    public string HouseNumber { get; set; } = houseNumber;
    public string ZipCode { get; set; } = zipCode;
    public string City { get; set; } = city;
}