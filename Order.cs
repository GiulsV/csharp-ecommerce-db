/*
 Order
    id
    costumer_id
    emploee_id
    date
    amount
    status
 */
public class Order
{
    public int OrderId { get; set; }
    public DateTime Date { get; set; }
    public float Ammount { get; set; }
    public string Status { get; set; }

    //relazioni
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public List<Payment> Payments { get; set; }
    public List<Product> ProductList { get; set; }

}