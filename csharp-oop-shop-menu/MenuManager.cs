namespace csharp_oop_shop_menu
{
    internal class MenuManager
    {
        // Divisore
        public static void Divider()
        {
            Console.WriteLine("\n===============================================================================================================");
        }
        // Metodo per visualizzare menu
        public static void DisplayMenu()
        {
            string[] menu = { "Inserimento prodotto", "Visualizza prodotti", "Modifica prodotto", "Elimina prodotto" };
            Divider();
            Console.WriteLine("\nMenu:");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
            Console.WriteLine("0. Esci");
        }
        //Funzione per prendere input dall'utente
        public static int GetUserChoice()
        {
            Console.WriteLine("\nScegli un'opzione:");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                return -1;  
            }
        }
        // Metodo per l'inserimento di un nuovo prodotto
        public static void InsertProduct()
        {
            Divider();
            Console.WriteLine("\n-- Inserimento prodotto --");
            Console.Write("\nInserisci il nome del prodotto: ");
            string name = Console.ReadLine();

            Console.Write("Inserisci la descrizione del prodotto: ");
            string description = Console.ReadLine();

            decimal price;
            do
            {
                Console.Write("Inserisci il prezzo del prodotto: ");
            } while (!decimal.TryParse(Console.ReadLine(), out price));

            int vat;
            do
            {
                Console.Write("Inserisci l'IVA in percentuale (senza simbolo '%'): ");
            } while (!int.TryParse(Console.ReadLine(), out vat));

            Product newProduct = new Product(name, description, price, vat);
            Program.products.Add(newProduct);

            Console.WriteLine("\nProdotto inserito con successo!");
        }
        // Metodo per visualizzare l'intera lista dei prodotti
        public static void DisplayProductList()
        {
            Divider();
            Console.WriteLine("\n-- Visualizzazione lista dei prodotti --");
            if (Program.products.Count == 0)
            {
                Console.WriteLine("Nessun prodotto presente.");
            }
            else
            {
                foreach (var product in Program.products)
                {
                    product.SeeDetails();
                }
            }
        }
        // Metodo per modificare un prodotto esistente
        public static void ModifyProduct()
        {
            Divider();
            Console.WriteLine("\n-- Modifica prodotto --");
            if (Program.products.Count == 0)
            {
                Console.WriteLine("Nessun prodotto presente.");
            }
            else
            {
                Console.Write("\nInserisci il nome del prodotto che desideri modificare: ");
                string nameToModify = Console.ReadLine().ToLower();
                bool productFound = false;

                foreach (var product in Program.products)
                {
                    if (product.Name.ToLower() == nameToModify)
                    {
                        Console.WriteLine("\nProdotto trovato:");
                        product.SeeDetails();
                        Console.WriteLine("\nInserisci i nuovi dettagli del prodotto:");

                        Console.Write("Nuovo nome: ");
                        string newName = Console.ReadLine();

                        Console.Write("Nuova descrizione: ");
                        string newDescription = Console.ReadLine();

                        decimal newPrice;
                        do
                        {
                            Console.Write("Nuovo prezzo: ");
                        } while (!decimal.TryParse(Console.ReadLine(), out newPrice));

                        int newVat;
                        do
                        {
                            Console.Write("Nuova IVA in percentuale (senza simbolo '%'): ");
                        } while (!int.TryParse(Console.ReadLine(), out newVat));

                        // Aggiornamento dei dettagli del prodotto
                        product.Name = newName;
                        product.Description = newDescription;
                        product.Price = newPrice;
                        product.Vat = newVat;

                        Console.WriteLine("\nProdotto modificato con successo!");
                        productFound = true;
                        break;
                    }
                }
                if (!productFound)
                {
                    Console.WriteLine("Prodotto non trovato.");
                }
            }
        }
        // Metodo per eliminare un prodotto esistente
        public static void DeleteProduct()
        {
            Divider();
            Console.WriteLine("\n-- Elimina prodotto --");
            if (Program.products.Count == 0)
            {
                Console.WriteLine("Nessun prodotto presente.");
            }
            else
            {
                Console.Write("\nInserisci il nome del prodotto che desideri eliminare: ");
                string nameToDelete = Console.ReadLine().ToLower();
                bool productFound = false;

                for (int i = 0; i < Program.products.Count; i++)
                {
                    if (Program.products[i].Name.ToLower() == nameToDelete)
                    {
                        Console.WriteLine("\nProdotto trovato:");
                        Program.products[i].SeeDetails();
                        Console.Write("\nSei sicuro di voler eliminare questo prodotto? (S/N): ");
                        string confirmation = Console.ReadLine().ToLower();
                        if (confirmation == "s")
                        {
                            Program.products.RemoveAt(i);
                            Console.WriteLine("\nProdotto eliminato con successo!");
                        }
                        else if (confirmation == "n")
                        {
                            Console.WriteLine("\nOperazione annullata. Il prodotto non è stato eliminato.");
                        }
                        else
                        {
                            Console.WriteLine("\nScelta non valida. Operazione annullata.");
                        }
                        productFound = true;
                        break;
                    }
                }
                if (!productFound)
                {
                    Console.WriteLine("Prodotto non trovato.");
                }
            }
        }
    }
}