/*
 Product
    id
    name
    description
    price
 */

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    //relazione molti a molti
    public List<Order>? OrderList { get; set; }
}