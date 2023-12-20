using System;
using System.Collections.Generic;
using System.IO;
using KassaLibrary.PrdoukInfo;

namespace KassaLibrary.FileInfo
{
    public class FileInformation 
    {
        public List<Product> Products { get; private set; }
        public FileInformation()
        {
            Products =  LoadProductsFromFile();
        }
        
        public List<Product> LoadProductsFromFile()
        {
            try
            {
                string filePath = Path.GetFullPath("../../../File/kassa.txt");
                string[] allLines = File.ReadAllLines(filePath);
                Products = new List<Product>();

                foreach (string productString in allLines)
                {
                    string[] product = productString.Split(':');

                    int description = Convert.ToInt32(product[0]);
                    string name = product[1];
                    double price = (double)Convert.ToDecimal(product[2]);
                    string type = product[3];

                    //Product p = new Product(description, name, price,type);
                    Products.Add(new Product(description, name, type, price));

                }
                return Products;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"{ex.Message}");
                return new List<Product>();
            } 
            


            //foreach (Product P in products)
            //{
            //    int cursorLeft = Console.WindowWidth - (maxNameWidth + 10);
            //    Console.SetCursorPosition(cursorLeft, Console.CursorTop);
            //    Console.WriteLine($"[{P.ProductDescription}], [{P.ProductName}]");
            //}



        }

    }
}
