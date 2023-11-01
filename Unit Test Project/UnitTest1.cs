using Vending_Machine.Controller;
using Vending_Machine.Model;

namespace Unit_Test_Project
{
    public class UnitTest1
    {
        [Fact]
        public void PurchaseValidProductReturnsProduct()
        {
            Drink drink = new Drink { Id = 1, Name = "Cola", Price = 20, Flavor = "Cola Flavor" };
            Snack snack = new Snack { Id = 2, Name = "Chips", Price = 10, Type = "Potato Chips" };
            Toy toy = new Toy { Id = 3, Name = "Robot", Price = 100, ToyType = "Remote-Controlled" };

            List<Product> products = new List<Product> { drink, snack, toy };

            VendingMachineService vendingMachine = new VendingMachineService(products);

            vendingMachine.InsertMoney(50);

            Product purchasedProduct = vendingMachine.Purchase(1, vendingMachine.moneyPool);
            Assert.Equal(drink, purchasedProduct);
        }

        [Fact]
        public void PurchaseInvalidProductReturnsNull()
        {
            var snack = new Snack { Id = 2, Name = "Chips", Price = 10, Type = "Potato Chips" };
            var toy = new Toy { Id = 3, Name = "Robot", Price = 100, ToyType = "Remote-Controlled" };

            var products = new List<Product> { snack, toy };

            var vendingMachine = new VendingMachineService(products);

            vendingMachine.InsertMoney(50);

            var purchasedProduct = vendingMachine.Purchase(1, vendingMachine.moneyPool);

            Assert.Null(purchasedProduct);
        }

    }
}