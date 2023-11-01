using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine.Model;

namespace Vending_Machine.Controller
{
    public class VendingMachineService : IVending
    {
        public int moneyPool;
        public int[] ValidDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        public List<Product> products;

        public VendingMachineService(List<Product> initialProducts)
        {
            products = initialProducts;
            moneyPool = 0;
        }

        public Product Purchase(int productId, int moneyPool)
        {
            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null && moneyPool >= product.Price)
            {
                this.moneyPool -= product.Price;
                return product;
            }
            return null;
        }

        public List<string> ShowAll()
        {
            return products.Select(p => $"Id: {p.Id} - Name: {p.Name} - Price: {p.Price}SEK").ToList();
        }

        public string Details(int productId)
        {
            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                return product.Examine();
            }
            return "Product not found.";
        }

        public void InsertMoney(int amount)
        {
            if (ValidDenominations.Contains(amount))
            {
                moneyPool += amount;
            }
            else { Console.WriteLine("Invalid amount"); }
        }

        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> change = new Dictionary<int, int>();
            int[] denominations = ValidDenominations.OrderByDescending(d => d).ToArray();

            foreach (int denomination in denominations)
            {
                if (moneyPool >= denomination)
                {
                    int count = moneyPool / denomination;
                    moneyPool %= denomination;
                    change[denomination] = count;
                }
            }

            return change;
        }


    }
}
