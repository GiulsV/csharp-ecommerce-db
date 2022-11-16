/*
 Employee
    id
    name
    surname
    level
 */
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Level { get; set; }

    //relazione uno a molti
    public List<Order>? Orders { get; set; }
}