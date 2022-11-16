using Microsoft.EntityFrameworkCore;

public class ECommerceContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }

    public ECommerceContext()
    {


        if (!Products.Any())
        {
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
            Products.Add(primo);
            Products.Add(secondo);
            Products.Add(terzo);
            Products.Add(quarto);
            Products.Add(quinto);
            Products.Add(sesto);
            Products.Add(settimo);
            Products.Add(ottavo);
            Products.Add(nono);
            Products.Add(decimo);

            Customer user = new Customer() { Name = "Mario", Surname = "Rossi", Email = "mrossi@gmail.com" };
            Customers.Add(user);

            Employee employee = new Employee() { Name = "Pietro", Surname = "Bianchi" };
            Employees.Add(employee);

        }

        SaveChanges();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_ecommerce;Integrated Security=True");
    }

}