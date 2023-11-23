using KassaLibrary.FileInfo;
using KassaLibrary.PrdoukInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KassaSystem.PrdoukInfo
{
    public class Checkout
    {
        public List<Product> Produkters { get; set; }
        public decimal TotalPrice { get; private set; }
        public Checkout(List<Product> produkters)
        {
            Produkters = produkters;
        }

      
        private decimal GetTotalPrice()
        {
            var totalPrice = 0m;
            foreach (var p in Produkters)
            {
                totalPrice += p.Price;
            }
            return TotalPrice;
        }
        public void CheckoutProcces(producthanter produkthanter)
        {
            while (true)
            {
                

                Console.WriteLine("\"Ange koden och antal (eller tryck Enter för att avsluta):");
                
                string Myuserinput = Console.ReadLine();

                if (string.IsNullOrEmpty(Myuserinput))
                {
                    break;
                }
                string[] split = Myuserinput.Split(' ');
                int kod;
                int antal;

                Console.WriteLine("Vill Du Lägga Till Produkt\n 'Ja' / 'Nej' ");
                string Myuserinput2 = Console.ReadLine();

                if (Myuserinput2.ToLower() == "ja")
                {
                    Console.WriteLine("Ange Kod och Antal");
                    produkthanter.AddProduct();

                }
                else if (Myuserinput2.ToLower() == "nej")
                {
                    break;
                }



                if (split.Length == 2 && int.TryParse(split[0], out kod) && int.TryParse(split[1], out antal))
                { 
                  

                    Console.WriteLine("Skriv 'pay' för att betala: ");
                    
                    string input = Console.ReadLine();

                    if (input.ToLower() == "pay")
                    {
                        Product p = Produkters.FirstOrDefault(p => p.ProduktDescription == kod);
                        if (p != null)
                        {
                            decimal totalPrice = p.Price * antal;
                            Console.WriteLine($"Totalt Priset Är: {totalPrice} kr ");

                            Console.WriteLine("Tack För Betalning");

                        }
                    }
                }
            }

        }
      

    }
}
