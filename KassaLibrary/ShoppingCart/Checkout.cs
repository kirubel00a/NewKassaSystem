using KassaLibrary.PrdoukInfo;
using System.Linq;
using KassaLibrary.ShoppingCart;
using System.Collections.Generic;
using KassaLibrary.FileInfo;

namespace KassaLibrary.ShoppingCart;


public class Checkout
{
    public List<Product> products;
    public ShoppingCart shoppingCart;
    public ItemList itemList;

    public Checkout(List<Product> availableProducts, ShoppingCart shoppingCart, ItemList itemList)
    {
        this.products = availableProducts;
        this.shoppingCart = shoppingCart;
        this.itemList = itemList;
    }

    public void HandleUserInput()
    {
        var fileInformation = new FileInformation();
        products = fileInformation.Products;

        bool exitCheckout = false;
        while (!exitCheckout) 
        {
            DisplayOptions();

            string userInput = Console.ReadLine();


            if (int.TryParse(userInput, out int userChoice))
            {
               
                switch (userChoice)
                {
                    case 1:
                        DisplayAvailableProducts(products);
                        Console.Write("Ange produkt-ID och antal (t.ex. 111 2'):");
                    Console.WriteLine("\n_________________________________________");
                        string productInput = Console.ReadLine();
                        string[] productParts = productInput.Split(' ');

                        if (productParts.Length == 2 && int.TryParse(productParts[0], out int productID) && int.TryParse(productParts[1], out int quantity))
                        {
                            Product addedProduct = products.Find(p => p.ProductDescription == productID);
                            shoppingCart.AddProduct(addedProduct, quantity);
                        }
                        else
                        {
                            Console.WriteLine("Felaktig input..");

                        }
                        break;
                    case 2:
                        shoppingCart.DisplayShoppingCart();
                        Console.Write("Ange produkt ID för att ta bort: ");
                        if (int.TryParse(Console.ReadLine(), out int productIndex))
                        {
                            shoppingCart.RemoveProduct(productIndex);
                        }
                        else
                        {
                            Console.WriteLine("Felaktig input.");
                        }
                        break;
                    case 3:
                        shoppingCart.ClearCart();
                        break;
                    case 4:
                        shoppingCart.GenerateReceipt();
                        break;
                    case 5:
                        shoppingCart.DisplayShoppingCart();
                        break;
                    case 6:
                        Console.WriteLine("Tack för att du handlar! Avslutar...");
                        exitCheckout = true;
                        break;
                }
            }
        }
      

    }
    public void DisplayAvailableProducts(List<Product> Products)
    {
        if (Products == null) 
        {
            Console.WriteLine("Produktlistan är ogiltig....");

        }
        Console.WriteLine("Produkter:");
        foreach (Product p in Products)
        {

            Console.WriteLine($"{p.ProductDescription}. {p.ProductName} - {p.ProductPrice}");


        }
    }
   
    public void DisplayOptions()
    {
        Console.WriteLine("| [1] Lägg till föremål   [2] Ta bort föremål    [3] Rensa varukorgen  |");
        Console.WriteLine("| [4]Betala               [5] Visa Varukorg      [6] Komplett inköp!   |");
    }
   

}








