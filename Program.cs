// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

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

