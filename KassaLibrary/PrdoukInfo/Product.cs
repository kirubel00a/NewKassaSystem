using System;
using KassaLibrary;


namespace KassaLibrary.PrdoukInfo
{

    public class Product
    {

       

        public Product(int productDescription, string productName, string productType, double Price, double quantity = 1 )
        {
            ProductDescription = productDescription;
            ProductName = productName;
            ProductType = productType;
            ProductPrice = Price;
            Quantity = quantity; 

        }



        public int ProductDescription { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductType { get; set; }
        public double ProductPrice { get; }
        public double Quantity { get; set; }
        public double TotalPrice => ProductPrice * Quantity;
    }
}
