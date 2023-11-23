using KassaLibrary.PrdoukInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaSystem.PrdoukInfo
{
    public class producthanter
    {
        private List<Product> Produkters {  get; set; }

        public producthanter(List<Product> produkters) 
        {
            Produkters = new List<Product>();
        }
        public void AddProduct()
        {

                
                if (int.TryParse(Console.ReadLine(), out int kod))
                {
                    Product produkter = new Product();
                    produkter.ProduktDescription = kod;
                    Produkters.Add(produkter);
                }
                
            

        }
        public void RemoveProduct(Product produkter)
        {
            Produkters.Remove(produkter);
        }
    }
}
