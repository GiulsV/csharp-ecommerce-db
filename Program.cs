// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/*
 
 Prima parte
Dato lo schema in allegato, producete tutte le classi e le relazioni necessarie per poter utilizzare EntityFramework (in modalità code-first) al fine di generare il relativo database.

Seconda Parte
Considerando che:
        - ci sono clienti che effettuano ordini.
        - Un ordine viene preparato da un dipendente.
        - Un ordine ha associato uno o più pagamenti (considerando eventuali tentativi falliti)

Realizzate le seguenti funzionalità
        - inserite 10 prodotti all’avvio del programma (i prodotti non devono essere inseriti in caso si riavvi l’applicazione)
        - quando l’applicazione si avvia chiede se l’utente è un dipendete o un cliente
                 - se è un dipendente potrà eseguire CRUD sugli ordini
                 - se è un cliente potrà acquistare degli ordini
        - simulate randomicamente l’esito di un acquisto (status = ok | status = ko)

Bonus
Il dipendente deve poter spedire gli ordini acquistati per cui il pagamento è andato a buon fine. 

 */


 using System.Collections.Generic;

Console.WriteLine("Benvenuto nell'ecommerce!");

ECommerceContext db = new ECommerceContext();

bool exit = true;

do
{

    Console.Write("Inserisci se sei un dipendente [d] o un cliente [c] ");
    string input = Console.ReadLine();


    switch (input)
    {
        case "d":

            bool exitEmployee = true;
            do
            {
                // leggi ordine (read)
                List<Order> ordini = db.Orders.ToList();
                foreach(Order order in ordini)
                {
                    Console.WriteLine("{0} - {1} - {2}", order.Date, order.Ammount, order.Status);
                }
                // modifica ordine (update)

                // cancella ordine (delete)

                // crea pagamento (create)
                Pagamento(db, ordini);

            } while (!exitEmployee);
            
            break;

        case "c":

            //            
            int i = 0;
            foreach (Product product in ProductList(db).ToList())
            {
                Console.WriteLine((i + 1) + " - " + product.Name);
                i++;
            }

            MenuCustomer();

            Console.Write("Scegli un'opzione del menu: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            bool exitClient = false;
            do
            {
                switch (choice)
                {


                    // crea ordine (create)
                    case 1:

                        //scegli il prodotto
                        Console.Write("Scegli il nome del prodotto che vuoi ordinare: ");
                        string nomeProdotto = Console.ReadLine();

                        //funzione crea ordine con parametro db 
                        CreaOrdine(db, nomeProdotto);


                        break;

                    case 2:
                        List<Product> products = ProductList(db);

                        i = 0;
                        foreach (Product product in products)
                        {
                            Console.WriteLine((i + 1) + " - " + product.Name);
                            i++;
                        }
                        break;

                    // modifica ordine (update)
                    case 3:

                        ModifyOrder(db);

                        break;

                    // elimina ordine (delete)
                    case 4:
                        Customer customer = db.Customers.First();
                        Order ordine = db.Orders.Where(ordine => ordine.CustomerId == customer.CustomerId).First();

                        db.Remove(ordine);
                        break;

                    case 5:
                        exitClient = true;
                        break;

                    

                }
            } while (!exitClient);

            break;

        case "esci":
            exit = false;
            break;

    }

} while (!exit);


void MenuCustomer()
{
    Console.WriteLine("Sezione: Lista Prodottis\n");
    Console.WriteLine("     1. Crea ordine");
    Console.WriteLine("     2. Lista Prodotti");
    Console.WriteLine("     3. Modifica ordine");
    Console.WriteLine("     4. Elimina ordine");
    Console.WriteLine("     5. Esci");
}

List<Product> ProductList(ECommerceContext db)
{
    List<Product> productList = db.Products.ToList<Product>();

    return productList;
}

void CreaOrdine(ECommerceContext db, string nomeProdotto)
{
    // trovare il prodotto
    Product product = db.Products.Where(p => p.Name == nomeProdotto).First();

    //dati utente
    Customer customer = db.Customers.First();

    //dati impiegato
    Employee employee = db.Employees.First();

    int random = new Random().Next(0, 2);
    bool stato = false;
    if (random == 1)
        stato = true;

    //creare ordine
    Order order = new Order() { Date = new DateTime(), Ammount = product.Price, Status = stato, EmployeeId = employee.EmployeeId, CustomerId = customer.CustomerId };
    db.Orders.Add(order);
    db.SaveChanges();
}

List<Order> OrderList(ECommerceContext db)
{
    List<Order> orders = db.Orders.ToList();

    return orders;
}

void Pagamento(ECommerceContext db, List<Order> ordini)
{
    int random = new Random().Next(1, 11);
    bool stato = false;
    if (random < 6)
        stato = true;
    Payment payment = new Payment() { OrderId = ordini.First().OrderId, Date = ordini.First().Date, Ammount = ordini.First().Ammount, Status = stato };
    db.Payments.Add(payment);
    db.SaveChanges();
}

void ModifyOrder(ECommerceContext db)
{
    Customer customer = db.Customers.First();
    Order ordine = db.Orders.Where(ordine => ordine.CustomerId == customer.CustomerId).First();

    ordine.Ammount = 3000;
    db.SaveChanges();
}