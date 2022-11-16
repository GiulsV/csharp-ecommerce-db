/*
 Costumer
    id
    name
    surname
    email
 */
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    //relazione uno a molti
    public List<Order>? Orders { get; set; }
}