

public class Products
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Products()
    {
        Id = "0000";
        Name = "UNKNOWN";
    }

    public Products(string id, string name, int quantity, double price)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;

    }
}