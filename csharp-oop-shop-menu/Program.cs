using System;
using System.Collections.Generic;

namespace csharp_oop_shop_menu
{
    internal class Program
    {
        // Dichiarazione della lista dei prodotti
        public static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                MenuManager.DisplayMenu();
                int choice = MenuManager.GetUserChoice();
                switch (choice)
                {
                    case 1:
                        MenuManager.InsertProduct();
                        break;
                    case 2:
                        MenuManager.DisplayProductList();
                        break;
                    case 3:
                        MenuManager.ModifyProduct();
                        break;
                    case 4:
                        MenuManager.DeleteProduct();
                        break;
                    case 0:
                        Console.WriteLine("Uscita dal programma.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
    }
}