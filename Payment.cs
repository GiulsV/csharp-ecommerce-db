/*
 id
    order_id
    date
    amount
    status
 */

public class Payment
{
    public int PaymentId { get; set; }
    public DateTime Date { get; set; }
    public float Ammount { get; set; }
    public bool Status { get; set; }

    //relazione molti a uno
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}