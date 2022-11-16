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
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    //relazione molti a molti
    public List<Order> OrderList { get; set; }

    public static void ListProducts()
    {
        ECommerceContext db = new ECommerceContext();

        List<Product> products = new List<Product>();
        products.AddRange(db.Products);
        Product primo = new Product() { Name = "Primo", Description = "primo prodotto", Price = 1000 };
        Product secondo = new Product() { Name = "Seconod", Description = "primo prodotto", Price = 1000 };
        Product terzo = new Product() { Name = "Terzo", Description = "primo prodotto", Price = 1000 };
        Product quarto = new Product() { Name = "Quarto", Description = "primo prodotto", Price = 1000 };
        Product quinto = new Product() { Name = "Quinto", Description = "primo prodotto", Price = 1000 };
        Product sesto = new Product() { Name = "Sesto", Description = "primo prodotto", Price = 1000 };
        Product settimo = new Product() { Name = "Settimo", Description = "primo prodotto", Price = 1000 };
        Product ottavo = new Product() { Name = "Ottavo", Description = "primo prodotto", Price = 1000 };
        Product nono = new Product() { Name = "Nono", Description = "primo prodotto", Price = 1000 };
        Product decimo = new Product() { Name = "Decimo", Description = "primo prodotto", Price = 1000 };

        //add per ogni product
        foreach (Product product in products)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}