using KassaLibrary.PrdoukInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KassaLibrary.ShoppingCart 
{
    public class ShoppingCart
    {

        private List<Product> cart;

        public List<Product> Products { get; set; }
        public ItemList ItemList { get; set; }

        public double TotalSum { get; private set; }

        public ShoppingCart()
        {

            cart = new List<Product>();
            ItemList = new ItemList();
        }

        public void AddProduct(Product Product, int quantity)
        {
            if (Product != null && quantity > 0)
            {
                var cartItem = new Product(Product.ProductDescription, Product.ProductName, Product.ProductType, Product.ProductPrice, quantity);
                cart.Add(cartItem);

                Console.WriteLine($"{quantity} st av {cartItem.ProductName} har lagts till i kundvagnen");
            }
            else
            {
                Console.WriteLine("Ogiltig produkt eller kvantitet. Produkten har inte lagts till i kundvagnen.");
            }

        }

        public void RemoveProduct(int ProductDescrIption)
        {
            int productIndex = cart.FindIndex(p => p.ProductDescription == ProductDescrIption);

            if (productIndex != -1)
            {
                var productToRemove = cart[productIndex];
                cart.Remove(productToRemove);
                Console.WriteLine($"{productToRemove.ProductName} har tagits bort från kundvagnen.");
            }
            else
            {
                Console.WriteLine("Ogiltigt produktindex. Ingen produkt borttagen från varukorgen.");
            }
        }
        public void ClearCart()
        {
            cart.Clear();
            Console.WriteLine("Varukrget har tömts");
        }
        public void DisplayShoppingCart()
        {
            Console.WriteLine("VaruKorg:");
            if (cart.Count == 0) 
            {
                Console.WriteLine("Du har inte lagt in produkt än...");
            }
            for (int i = 0; i < cart.Count; i++)
            {
                var product = cart[i];
                Console.WriteLine($"| {i + 1} | {product.ProductName} | ${product.ProductPrice} | {product.Quantity} | ${product.TotalPrice} |");
            }

        }
        public void GenerateReceipt()
        {
            Console.WriteLine("+" + new string('-', 29) + "+");
            Console.WriteLine($"| KVITTOT {DateTime.Now:yyyy-MM-dd HH:mm:ss} |");
            Console.WriteLine("+" + new string('-', 29) + "+");

            foreach (Product Product in cart)
            {

                Console.WriteLine($"{Product.ProductName} - {Product.ProductPrice}Kr * {Product.Quantity} = {Product.TotalPrice}kr");
            }
            Console.WriteLine( "+" + new string('-', 15) + "+");
            Console.WriteLine($"| Totalt: {GetTotalSum()}kr   |");
            Console.WriteLine( "+" + new string('-', 15) + "+");

            Console.WriteLine("Tack För Betalningen!");
        }
        public double GetTotalSum()
        {
            return cart.Sum(product => product.TotalPrice);
        }

    }

}

