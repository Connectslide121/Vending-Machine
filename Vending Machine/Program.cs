using Vending_Machine.Controller;
using Vending_Machine.Model;

//*************************** POPULATE PRODUCT LIST **********************************

Drink drink = new Drink { Id = 1, Name = "Cola", Price = 20, Flavor = "Cola Flavor" };
Snack snack = new Snack { Id = 2, Name = "Chips", Price = 10, Type = "Potato Chips" };
Toy toy = new Toy { Id = 3, Name = "Robot", Price = 100, ToyType = "Remote-Controlled" };

List<Product> products = new List<Product> { drink, snack, toy };

VendingMachineService vendingMachine = new VendingMachineService(products);

//*************************** INSERT COIN **********************************

string money;
int moneyInt;

do
{
    Console.WriteLine("Please insert coin");
    money = Console.ReadLine();
}
while (!int.TryParse(money, out moneyInt) || !vendingMachine.ValidDenominations.Contains(moneyInt));

vendingMachine.InsertMoney(moneyInt);
Console.WriteLine($"{money} SEK succesfully inserted");
Console.WriteLine("Press any key to continue");
Console.ReadKey();

//*************************** PURCHASE PRODUCT **********************************

string productId;
int productIdInt;

do
{
    Console.Clear();
    Console.WriteLine($"Your money: {vendingMachine.moneyPool} SEK");
    Console.WriteLine("Available products:");
    Console.WriteLine();

    foreach (string product in vendingMachine.ShowAll())
    {
        Console.WriteLine(product);
    }

    Console.WriteLine();
    Console.WriteLine("Please insert Id of the product you want to purchase");
    productId = Console.ReadLine();

}
while (!int.TryParse(productId, out productIdInt) || !products.Any(product => product.Id == productIdInt));

Product purchasedProduct = vendingMachine.Purchase(productIdInt, vendingMachine.moneyPool);

if (purchasedProduct != null)
{
    Console.WriteLine($"You've purchased: {purchasedProduct.Name}");
    Console.WriteLine(purchasedProduct.Use());
    Console.WriteLine();
}
else
{
    Console.WriteLine("Not enough money to purchase the product.");
}

//*************************** RETURN CHANGE **********************************

var change = vendingMachine.EndTransaction();

Console.WriteLine("Here is your change:");

foreach (var denomination in change)
{
    Console.WriteLine($"{denomination.Value} x {denomination.Key}kr");
}



