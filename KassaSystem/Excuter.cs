using System;
using KassaSystem.KassaLibrary;
using KassaLibrary.FileInfo;
using KassaSystem.PrdoukInfo;
using KassaLibrary.PrdoukInfo;
using System.IO;

namespace KassaSystem.KassaLibrary

{
    public class Excuter
    {
   
        static void Main(string[] args)
        {

            var fileInformation = new FileInformation();
           List<Product>products = fileInformation.LoadProductsFromFile();

            var checkout = new Checkout(products);



            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen Till Kassan");
                Console.WriteLine("1: Ny Kund");
                Console.WriteLine("2: Exit");

                var userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (userInput)
                {

                    case 1:
                     Console.Clear();
                        
                     fileInformation.LoadProductsFromFile();
                        var produkthanter = new producthanter(products);
                        checkout.CheckoutProcces(produkthanter);
                    

                        break;
                        
                }
            }
        }
    }
}