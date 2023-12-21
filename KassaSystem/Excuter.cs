using System;
using KassaLibrary.FileInfo;
using KassaLibrary.PrdoukInfo;
using System.IO;
using KassaLibrary.ShoppingCart;

namespace KassaSystem.KassaLibrary
{
    public class Excuter
    {
        public static List<Product> Products { get; set; }
        public double sum = 0;
        private static List<Product> availableProducts;

        static void Main(string[] args)
        {

            FileInformation fileInformation = new FileInformation();



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen Till Kassan");
                Console.WriteLine("1: Ny Kund");
                Console.WriteLine("2: Avsluta!");

                
                var userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (userInput)
                {

                    case 1:
                     Console.Clear();


                        fileInformation.LoadProductsFromFile();
                        Checkout checkout = new Checkout(availableProducts, new ShoppingCart(),new ItemList());
                        checkout.HandleUserInput();
                        ShoppingCart shoppingCart = new ShoppingCart(); 
                        shoppingCart.GenerateReceipt();

                        break;
                    case 2:
                        Console.WriteLine("Hej Då");
                        Environment.Exit(0);
                        break;
                        
                }
            }
        }
    }
}