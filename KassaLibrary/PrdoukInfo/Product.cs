using System;

namespace KassaLibrary.PrdoukInfo
{

    public class Product
    {
        public Product()
        {
        }

        public Product(int description, string name, decimal price, string type)
        {
            ProduktName = name;
            ProduktType = type;
            ProduktDescription = description;
            Price = price;
        }
        public string produtker { get; set; }
        public int ProduktDescription { get; set; }
        public string ProduktName { get; set; }
        public decimal Price { get; set; }
        public string ProduktType { get; set; }

     
    }
}
