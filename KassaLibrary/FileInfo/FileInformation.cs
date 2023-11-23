using System;
using KassaLibrary.PrdoukInfo;

namespace KassaLibrary.FileInfo
{
    public class FileInformation 
    {
        public List<Product> produkters = new List<Product>();
        public FileInformation()
        {
            produkters = LoadProductsFromFile();
        }

        public List<Product> LoadProductsFromFile()
        {

            string[] allLines = File.ReadAllLines("../../../File/kassa.txt");
            List<Product> produkters = new List<Product>();

            foreach (string produktString in allLines)
            {
                string[] produkt = produktString.Split(':');

                int description = Convert.ToInt32(produkt[0]);
                string namn = produkt[1];
                decimal price = Convert.ToDecimal(produkt[2]);
                string type = produkt[3];

                Product p = new Product(description, namn, price, type);
                produkters.Add(p);

            }
            foreach (Product P in produkters)
            {
                Console.WriteLine($"[{P.ProduktDescription}]," +
                    $"[{P.ProduktName}]");
            }
            return produkters;


        }

    }
}
