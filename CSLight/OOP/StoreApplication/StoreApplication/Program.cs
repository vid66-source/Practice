using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication;

public static class Constants
{
    // Main Menu Headers
    public const string MAIN_HEADER = "Welcome to our store. You can see a list of our goods at the right. Add goods into the cart and then buy them!";
    public const string MENU_TITLE = "Menu:";
    public const string ADD_TO_CART_OPTION = "1) Add any product to your cart";
    public const string PURCHASE_OPTION = "2) Purchase products in your cart";
    public const string EXIT_OPTION = "3) Exit";
    public const string CHOOSE_OPTION = "Choose option: ";

    // Section Headers
    public const string STORE_INVENTORY = "Store assortment:";
    public const string YOUR_PURCHASES = "Your purchases:";
    public const string SHOPPING_CART = "Your Cart:";

    // Input Prompts
    public const string ENTER_PRODUCT_NAME = "Enter product name: ";
    public const string ENTER_QUANTITY = "Enter quantity: ";
    public const string ENTER_WEIGHT = "Enter weight: ";

    // Success Messages
    public const string PRODUCT_ADDED = "Product added to cart.";
    public const string PURCHASE_SUCCESSFUL = "Purchase successful!";

    // Error Messages
    public const string PRODUCT_NOT_FOUND = "Product not found";
    public const string INSUFFICIENT_FUNDS = "Insufficient funds.";
    public const string INVALID_INPUT = "Invalid input.";
    public const string INVALID_CHOICE = "Invalid choice. Try again.";
    public const string NOT_ENOUGH_PRODUCT = "There is not enough product";
    public const string AMOUNT_MUST_BE_POSITIVE = "The number must be greater than zero.";
    public const string WHOLE_NUMBER_REQUIRED = "For a piece product, the quantity must be a whole number";

    // Display Labels
    public const string STORE_MONEY_LABEL = "Store money";
    public const string YOUR_BALANCE_LABEL = "Your balance";
    public const string TOTAL_COST_LABEL = "Total cost";
    public const string DEFAULT_MONEY_LABEL = "Money";

    // Unit Labels
    public const string UNIT_PIECES = "pcs";
    public const string UNIT_KG = "kg";
    public const string PRICE_PER_PIECE = "piece";
    public const string PRICE_PER_KG = "kg";
}

public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
    decimal Quantity { get; }
    bool IsPieceProduct { get; }
    string GetDisplayInfo(IBalanceHolder owner);
    void UpdateQuantity(decimal newQuantity);
}

public interface IBalanceHolder
{
    decimal Balance { get; }
    List<IProduct> Products { get; }
}

// Інтерфейс для тих, хто може отримувати гроші
public interface IMoneyReceiver : IBalanceHolder
{
    void AddMoney(decimal amount);
}

// Інтерфейс для тих, хто може витрачати гроші
public interface IMoneySpender : IBalanceHolder
{
    void DeductMoney(decimal amount);
}


public class BaseProduct : IProduct
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public decimal Quantity { get; private set; }
    public bool IsPieceProduct { get; private set; }

    public BaseProduct(string name, decimal quantity, decimal price, bool isPieceProduct)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        IsPieceProduct = isPieceProduct;
    }

    public virtual string GetDisplayInfo(IBalanceHolder owner)
    {
        string unit = IsPieceProduct ? Constants.UNIT_PIECES : Constants.UNIT_KG;
        string priceUnit = IsPieceProduct ? Constants.PRICE_PER_PIECE : Constants.PRICE_PER_KG;

        var details = new StringBuilder($"Product:: {Name}, ");
        details.Append(IsPieceProduct
            ? $"Quantity: {Quantity} {unit}"
            : $"Weight: {Quantity} {unit}");

        if (owner is Seller)
        {
            details.Append($" | Price per {priceUnit}: {Price}₴");
        }

        return details.ToString();
    }

    public void UpdateQuantity(decimal newQuantity)
    {
        Quantity = IsPieceProduct
            ? Math.Round(newQuantity)
            : Math.Round(newQuantity, 2);
    }
}

public class Seller : IMoneyReceiver
{
    public decimal Balance { get; private set; }
    public List<IProduct> Products { get; private set; }

    public Seller(decimal initialBalance)
    {
        Balance = initialBalance;
        Products = CreateInitialProductList();
    }

    private List<IProduct> CreateInitialProductList()
    {
        return new List<IProduct>
                    {
                    new BaseProduct("Balloons", 30m, 2.99m, true),
                    new BaseProduct("Kinder Surprise", 12m, 12.99m, true),
                    new BaseProduct("Chocolate Bar", 15m, 8.50m, true),
                    new BaseProduct("Toy Soldier", 8m, 15.99m, true),
                    new BaseProduct("Milk", 5m, 10m, true),
                    new BaseProduct("Toy Car", 6m, 25.99m, true),
                    new BaseProduct("Banana", 10.0m, 5.99m, false),
                    new BaseProduct("Carrot", 8.0m, 3.99m, false),
                    new BaseProduct("Chicken Meat", 5.0m, 8.99m, false),
                    new BaseProduct("Veal", 7.0m, 5.99m, false),
                    new BaseProduct("Onion", 6.0m, 2.99m, false),
                    new BaseProduct("Potato", 12.0m, 5.99m, false),
                    new BaseProduct("Tomato", 1.0m, 5.99m, false)
                    };
    }

    public void AddMoney(decimal amount) => Balance += amount;

}

public class Customer : IMoneySpender
{
    public decimal Balance { get; private set; }
    public List<IProduct> Products { get; private set; }

    public Customer(decimal initialBalance)
    {
        Balance = initialBalance;
        Products = new List<IProduct>();
    }

    public void DeductMoney(decimal amount) => Balance -= amount;

}

public class ShoppingCart : IBalanceHolder
{
    public decimal Balance => CalculateTotalCost();
    public List<IProduct> Products { get; private set; }

    public ShoppingCart()
    {
        Products = new List<IProduct>();
    }

    public decimal CalculateTotalCost() =>
        Products.Sum(p => p.Price * p.Quantity);

}

public class ProductManager
{
    public static bool TransferProduct(
        List<IProduct> sourceList,
        List<IProduct> destinationList,
        string productName,
        decimal amount)
    {
        var product = sourceList.FirstOrDefault(p =>
            p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (product == null)
        {
            Console.WriteLine(Constants.PRODUCT_NOT_FOUND);
            return false;
        }

        if (amount <= 0)
        {
            Console.WriteLine(Constants.AMOUNT_MUST_BE_POSITIVE);
            return false;
        }

        if (product.IsPieceProduct && amount % 1 != 0)
        {
            Console.WriteLine(Constants.WHOLE_NUMBER_REQUIRED);
            return false;
        }

        if (amount > product.Quantity)
        {
            string measureUnit = product.IsPieceProduct ? Constants.PRICE_PER_PIECE : Constants.UNIT_KG;
            Console.WriteLine($"{Constants.NOT_ENOUGH_PRODUCT}. Available: {product.Quantity} {measureUnit}");
            return false;
        }

        // Округлення значення залежно від типу продукту
        decimal validatedAmount = product.IsPieceProduct ? Math.Floor(amount) : Math.Round(amount, 2);

        var transferredProduct = new BaseProduct(
            product.Name,
            validatedAmount,
            product.Price,
            product.IsPieceProduct
        );

        destinationList.Add(transferredProduct);
        product.UpdateQuantity(product.Quantity - validatedAmount);
        return true;
    }

    public static void MergeSimilarProducts(List<IProduct> products)
    {
        var mergedProducts = products
            .GroupBy(p => p.Name)
            .Select(g => new BaseProduct(
                g.Key,
                g.Sum(p => p.Quantity),
                g.First().Price,
                g.First().IsPieceProduct
            ))
            .ToList();

        products.Clear();
        products.AddRange(mergedProducts);
    }

    public static void RemoveEmptyProducts(List<IProduct> products)
    {
        products.RemoveAll(p => p.Quantity <= 0);
    }
}

public class ConsoleInterface
{
    public static void DisplayProducts(
        List<IProduct> products,
        IBalanceHolder owner, // Змінено на базовий інтерфейс
        string header = null)
    {
        if (!string.IsNullOrEmpty(header))
        {
            Console.WriteLine(header);
        }

        foreach (var product in products)
        {
            Console.WriteLine(product.GetDisplayInfo(owner));
        }

        // Динамічне формування підсумкового рядка
        decimal totalAmount = owner switch
        {
            Seller seller => seller.Balance,
            Customer customer => customer.Balance,
            ShoppingCart cart => cart.Balance,
            _ => 0
        };

        // Використання відповідного значення для різних типів
        string totalLabel = owner switch
        {
            Seller => Constants.STORE_MONEY_LABEL,
            Customer => Constants.YOUR_BALANCE_LABEL,
            ShoppingCart => Constants.TOTAL_COST_LABEL,
            _ => Constants.DEFAULT_MONEY_LABEL
        };

        Console.WriteLine($"{totalLabel}: {totalAmount:C2}");
    }
}

public class StoreApplication
{
    public void Run()
    {
        var seller = new Seller(0);
        var customer = new Customer(500);
        var cart = new ShoppingCart();

        while (true)
        {
            Console.Clear();
            DisplayMainMenu();

            ConsoleInterface.DisplayProducts(seller.Products, seller, Constants.STORE_INVENTORY);
            ConsoleInterface.DisplayProducts(customer.Products, customer, Constants.YOUR_PURCHASES);
            ConsoleInterface.DisplayProducts(cart.Products, cart, Constants.SHOPPING_CART);

            ProcessUserChoice(seller, customer, cart);
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine(Constants.MAIN_HEADER);
        Console.WriteLine(Constants.MENU_TITLE);
        Console.WriteLine(Constants.ADD_TO_CART_OPTION);
        Console.WriteLine(Constants.PURCHASE_OPTION);
        Console.WriteLine(Constants.EXIT_OPTION);
        Console.Write(Constants.CHOOSE_OPTION);
    }

    private void ProcessUserChoice(Seller seller, Customer customer, ShoppingCart cart)
    {
        switch (Console.ReadLine())
        {
            case "1":
                AddProductToCart(seller, cart);
                break;
            case "2":
                PurchaseProducts(seller, customer, cart);
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine(Constants.INVALID_CHOICE);
                break;
        }
    }

    private void AddProductToCart(Seller seller, ShoppingCart cart)
    {
        Console.Write(Constants.ENTER_PRODUCT_NAME);
        string productName = Console.ReadLine();

        var product = seller.Products.FirstOrDefault(p =>
            p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (product == null)
        {
            Console.WriteLine(Constants.PRODUCT_NOT_FOUND);
            return;
        }

        Console.Write(product.IsPieceProduct ? Constants.ENTER_QUANTITY : Constants.ENTER_WEIGHT);
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine(Constants.INVALID_INPUT);
            return;
        }

        if (ProductManager.TransferProduct(seller.Products, cart.Products, productName, amount))
        {
            ProductManager.MergeSimilarProducts(cart.Products);
            ProductManager.RemoveEmptyProducts(seller.Products);
            Console.WriteLine(Constants.PRODUCT_ADDED);
        }
    }

    private void PurchaseProducts(Seller seller, Customer customer, ShoppingCart cart)
    {
        decimal totalCost = cart.Balance;

        if (customer.Balance >= totalCost)
        {
            customer.DeductMoney(totalCost);
            seller.AddMoney(totalCost);

            // Transfer all products from cart to customer
            foreach (var product in cart.Products.ToList())
            {
                customer.Products.Add(product);
            }
            cart.Products.Clear();

            Console.WriteLine(Constants.PURCHASE_SUCCESSFUL);
        }
        else
        {
            Console.WriteLine(Constants.INSUFFICIENT_FUNDS);
        }
    }

    public static void Main()
    {
        new StoreApplication().Run();
    }
}