namespace csharp_oop_shop_menu
{
    internal class Product
    {
        // Attributi
        public decimal Code { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Vat { get; set; }

        // Costruttore
        public Product(string name, string description, decimal price, int vat)
        {
            Code = GenerateCode();
            Name = name;
            Description = description;
            Price = price;
            Vat = vat;
        }
        //METODI
        // Metodo per generare un codice casuale
        private decimal GenerateCode()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999);
        }

        // Metodo getter per il prezzo comprensivo di iva
        public decimal GetPriceWithVat()
        {
            return Price * (1 + (decimal)Vat / 100);
        }

        // Metodo per ottenere il nome esteso (codice + nome)
        public string GetNameWithCode()
        {
            return Code.ToString().PadLeft(8, '0') + "-" + Name;
        }

        // Metodo per stampare i dettagli del prodotto
        public void SeeDetails()
        {
            Console.WriteLine($"\nCodice: {Code}  \nNome: {Name}  \nDescrizione: {Description}  \nPrezzo base: {Price:F2} euro  \nPrezzo con IVA: {GetPriceWithVat():F2} euro  \nIVA: {Vat:F2}%");
        }
    }
}