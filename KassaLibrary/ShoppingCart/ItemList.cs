using KassaLibrary.PrdoukInfo;

namespace KassaLibrary.ShoppingCart
{
    public class ItemList
    {
        public List<Product> Cart { get; set; }

        public ItemList()
        {
            Cart = new List<Product>();
        }

        public void DisplayItemList() 
        {

            for (int i = 0; i < Cart.Count; i++)
            {
                var product = Cart[i];
                Console.WriteLine($"| {i + 1} | {product.ProductName} | ${product.Price} | {product.Quantity} | ${product.TotalPrice} |");
            }

        }
    }
}
