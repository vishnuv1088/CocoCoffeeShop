public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<MenuItem> Items { get; set; } = new();
    public string Status { get; set; } = "Pending";
    public decimal Total => Items.Sum(i => i.Price);
}