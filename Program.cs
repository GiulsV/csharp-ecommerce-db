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

//dipendente crea ordine e cliente lo compra/seleziona?

Console.WriteLine("E-commerce");
Console.WriteLine();

ECommerceContext db = new ECommerceContext();


bool scelta = false;
while (!scelta)
{
    Console.WriteLine("Scegli se sei un cliente [c] o un dipendente [d]");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "c":
            Console.WriteLine("Sei entrato come cliente");
            Console.WriteLine();
            
            Console.WriteLine("Vuoi registrarti? [y/n]");
            string login = Console.ReadLine();
            if (login == "n")
            {
                Console.WriteLine("Non puoi effettuare ordini se non sei registrato.");
                break;
            }
            else
            { 
                //registra utente
                addNewCustomer();

                // visualizza articoli
                Console.WriteLine("Vuoi visualizzare i prodotti? [y/n]");
                string yn = Console.ReadLine();
                if (yn == "y")
                {
                    int i = 0;
                    foreach (Product product in ListProduct(db).ToList())
                    {
                        Console.WriteLine((i + 1) + " - " + product.Name);
                        i++;
                    }
                }
                scelta = true;

                // crea ordine
                // modifica ordine
                // elimina ordine
            }
            break;
        case "d":
            Console.WriteLine("dipendente");
            scelta = true;
            // visualizza ordine
            // modifica prodotti
            // annulla ordine
            // crea pagamento
            break;
    }
}


List<Product> ListProduct(ECommerceContext db)
{
    List<Product> productList = db.Products.ToList<Product>();

    return productList;
}

//registra utente
void addNewCustomer()
{
    Console.WriteLine("Inserisci il nome");
    string name = Console.ReadLine();
    Console.WriteLine("Inserisci il Cognome");
    string surname = Console.ReadLine();
    Console.WriteLine("Inserisci l'email");
    string email = Console.ReadLine();
    bool check = false;

    while (!check)
    {
        try
        {
            Customer newCustomer = new() { Name = name, Surname = surname, Email = email };
            db.Add(newCustomer);
            db.SaveChanges();
            check = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            check = false;
        }
    }
    string output = check ? "Inserimento avvenuto correttamente" : "";
    Console.WriteLine(output);
}
