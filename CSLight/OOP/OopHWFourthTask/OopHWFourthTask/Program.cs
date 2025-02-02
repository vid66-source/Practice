using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace OopHWFourthTask;

public static class UIManager
{
    public static int ScreenWidth, ScreenHeight;
    static UIManager()
    {
        ScreenWidth = Console.LargestWindowWidth;
        ScreenHeight = Console.LargestWindowHeight;
    }

    public static void WindowSizeOption(float screenShrinkRatioWidth, float screenShrinkRatioHight)
    {

        Console.SetWindowSize((int)(ScreenWidth * screenShrinkRatioWidth), (int)(ScreenHeight * screenShrinkRatioHight));
        Console.SetBufferSize((int)(ScreenWidth * screenShrinkRatioWidth), (int)(ScreenHeight * screenShrinkRatioHight));
    }

    public static void DrawHeader(float xOffset, int yOffset, string headerText)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        Console.WriteLine(headerText);
        yOffset++;
        SetCursorWithScreenOffset(xOffset, yOffset, new string('_', headerText.Length));

    }

    public static void UIElementMenu(float xOffset, int yOffset)
    {
        string[] menuItems =
        {
            "Menu:",
            "1) Add any product to your cart.",
            "2) Purchase products in your cart.",
            "Please choose your option"
        };

        for (int i = 0; i < menuItems.Length; i++)
        {
            SetCursorWithScreenOffset(xOffset, yOffset + i, menuItems[i]);
        }
    }


    public static void SetCursorWithScreenOffset(float xOffset, int yOffset, string text = null)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        if (text != null)
        {
            Console.Write(text);
        }
    }
}

public static class ProductManager
{
    public static void RelocateProduct(List<Product> productsList1, List<Product> productslList2, string productName, float amount)
    {
        int productIndex = DetectProductIndex(productsList1, productName);
        Product product = productsList1[productIndex];

        // Якщо продукт є штучним, перевіряємо, чи amount є цілим числом
        if (product.IsPieceProduct && amount % 1 != 0)
        {
            UIManager.SetCursorWithScreenOffset(0.1f, 10, "Please enter a valid integer amount for piece products.");
            return;
        }

        // Перевіряємо, чи достатньо продукту для переміщення
        if (amount <= product.ProductCount)
        {
            product.UpdateCount(product.ProductCount - amount);
            var productToRelocate = new Product(product.ProductName, amount, product.ProductPrice, product.IsPieceProduct);
            productslList2.Add(productToRelocate);
        }
        else
        {
            string weightOrPiece = product.IsPieceProduct ? "quantity" : "weight";
            UIManager.SetCursorWithScreenOffset(0.1f, 10, $"There is not enough product, please enter a different {weightOrPiece}.");
        }
    }


    public static int DetectProductIndex(List<Product> products, string productName)
    {
        return products.FindIndex(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
    }

    public static void SearchForDuplicate(List<Product> products)
    {
        for (int i = 0; i < products.Count; i++)
        {
            string productToCompare = products[i].ProductName;

            for (int j = i + 1; j < products.Count; j++)
            {
                if (products[j].ProductName == productToCompare)
                {
                    products[i].UpdateCount(products[i].ProductCount + products[j].ProductCount);
                    products.RemoveAt(j);
                    j--;
                }
            }
        }
    }

    public static void Availability(List<Product> products)
    {
        for (int i = products.Count - 1; i >= 0; i--)
        {
            if (products[i].ProductCount == 0)
            {
                products.RemoveAt(i);
            }
        }
    }

    public static void ShowProductsList<T>(float productsListPosX, int productsListPosY, List<Product> products, T owner, string headerText = null) where T : IMoneyHolder
    {
        // Відображення заголовка, якщо він переданий
        if (!string.IsNullOrEmpty(headerText))
        {
            UIManager.DrawHeader(productsListPosX, productsListPosY, headerText);
            productsListPosY += 2; // Зміщення для наступних елементів
        }

        // Відображення списку продуктів
        foreach (var item in products)
        {
            string productInfo = owner switch
            {
                Seller => $"{item.ProductShowInf(owner)}",
                Customer => $"{item.ProductShowInf(owner)} | Purchased",
                Cart => $"{item.ProductShowInf(owner)} | Total price: {item.ProductPrice * item.ProductCount}$",
                _ => item.ProductShowInf(owner)
            };

            UIManager.SetCursorWithScreenOffset(productsListPosX, productsListPosY, productInfo);
            productsListPosY++;
        }

        // Відображення загальної суми грошей
        string moneyText = string.Format("{0:F2}", owner.Money);
        string ownerType = owner switch
        {
            Seller => "Store money",
            Customer => "Your balance",
            Cart => "Total cost",
            _ => "Money"
        };
        string underListText = $"{ownerType}: {moneyText}";
        UIManager.SetCursorWithScreenOffset(productsListPosX, productsListPosY, new string('_', underListText.Length));
        productsListPosY++;
        UIManager.SetCursorWithScreenOffset(productsListPosX, productsListPosY, $"{ownerType}: {moneyText}$");
    }

    public static void AddProductsToList(List<Product> productsList1, List<Product> productslList2)
    {
        productsList1.AddRange(productslList2);
    }

}


class Program
{
    static void Main(string[] args)
    {
        bool storeIsOpen = true;
        //store entities
        Seller seller = new Seller(0);
        Customer customer = new Customer(50);
        Cart cart = new Cart();
        UIManager.WindowSizeOption(0.9f, 0.8f);
        int sellerListCount = seller.SellerProducts.Count;

        while (storeIsOpen)
        {
            //Headder
            UIManager.DrawHeader(0.1f, 0, "Welcome to our store. You can see a list of our goods at the right. Add goods into the cart and then buy them!");

            //Menu
            UIManager.UIElementMenu(0.1f, 2);

            //Customer
            ProductManager.ShowProductsList(0.1f, sellerListCount + 7, customer.CustomerProducts, customer, "Your Purchases:");

            //Store
            ProductManager.ShowProductsList(0.5f, 2, seller.SellerProducts, seller, "Store assortment:");

            //Cart
            ProductManager.ShowProductsList(0.5f, sellerListCount + 7, cart.CartProducts, cart, "Your Cart:");

            //Input Field
            UIManager.SetCursorWithScreenOffset(0.1f, 6);

            switch (Console.ReadLine())
            {
                case "1":
                    UIManager.SetCursorWithScreenOffset(0.1f, 7);
                    Console.Write("Enter product name: ");
                    string productNameInput = Console.ReadLine();
                    //Wrong input
                    if (ProductManager.DetectProductIndex(seller.SellerProducts, productNameInput) == -1)
                    {
                        UIManager.SetCursorWithScreenOffset(0.1f, 8, "Invalid input. Press any key to return to main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        continue; // Повертаємося до початку циклу
                    }
                    string amountType = seller.SellerProducts[ProductManager.DetectProductIndex(seller.SellerProducts, productNameInput)].IsPieceProduct ? "quantity" : "weight";
                    UIManager.SetCursorWithScreenOffset(0.1f, 8);
                    Console.Write($"Enter the {amountType} of the product you wish to purchase: ");
                    string amountInput = Console.ReadLine();
                    float amountNumber;
                    //Wrong input
                    if (!float.TryParse(amountInput, out amountNumber))
                    {
                        UIManager.SetCursorWithScreenOffset(0.1f, 9, "Invalid input. Press any key to return to main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    ProductManager.RelocateProduct(seller.SellerProducts, cart.CartProducts, productNameInput, amountNumber);
                    ProductManager.Availability(seller.SellerProducts);
                    ProductManager.SearchForDuplicate(cart.CartProducts);
                    UIManager.SetCursorWithScreenOffset(0.1f, 9, "Press any key to continue.");
                    Console.ReadKey();
                    break;
                case "2":
                    if (cart.TotalCost() <= customer.Money)
                    {
                        customer.PayMoney(cart.TotalCost());
                        seller.GetMoney(cart.TotalCost());
                        ProductManager.AddProductsToList(customer.CustomerProducts, cart.CartProducts);
                        ProductManager.SearchForDuplicate(customer.CustomerProducts);
                        cart.CartProducts.Clear();
                        UIManager.SetCursorWithScreenOffset(0.1f, 11, "Press any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        ProductManager.AddProductsToList(seller.SellerProducts, cart.CartProducts);
                        ProductManager.SearchForDuplicate(seller.SellerProducts);
                        cart.CartProducts.Clear();
                        UIManager.SetCursorWithScreenOffset(0.1f, 7, "You don't have enough money.");
                        UIManager.SetCursorWithScreenOffset(0.1f, 11, "Press any key to continue.");
                        Console.ReadKey();

                    }
                    break;
                default:
                    UIManager.SetCursorWithScreenOffset(0.1f, 6, "Wrong input. Press any key to return to main menu...");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
        }
    }

}

public interface IMoneyHolder
{
    float Money { get; }
    List<Product> Products { get; }
}

class Seller : IMoneyHolder
{
    public List<Product> SellerProducts { get; private set; }
    public float Money { get; private set; }

    public List<Product> Products => SellerProducts;

    public Seller(float money)
    {
        Money = money;

        SellerProducts = new List<Product>{
            new Product("Balloons", 30f, 2.99f, true),
            new Product("Chocolate Bar", 15f, 8.50f, true),
            new Product("Kinder Surprise", 12f, 12.99f, true),
            new Product("Toy Soldier", 8f, 15.99f, true),
            new Product("Milk", 5f, 10f, true),
            new Product("Toy Car", 6f, 25.99f, true),
            new Product("Banana", 10.0f, 5.99f, false),
            new Product("Carrot", 8.0f, 3.99f, false),
            new Product("Chicken Meat", 5.0f, 8.99f, false),
            new Product("Veal", 7.0f, 5.99f, false),
            new Product("Onion", 6.0f, 2.99f, false),
            new Product("Potato", 12.0f, 5.99f, false),
            new Product("Tomato", 1.0f, 5.99f, false)
        };
    }

    public void GetMoney(float productsPrice)
    {
        Money += productsPrice;
    }

}

class Customer : IMoneyHolder
{
    public List<Product> CustomerProducts { get; private set; }
    public float Money { get; private set; }

    public List<Product> Products => CustomerProducts;

    public Customer(float money)

    {
        CustomerProducts = new List<Product>();
        Money = money;
    }

    public void PayMoney(float productsPrice)
    {
        Money -= productsPrice;
    }
}

class Cart : IMoneyHolder
{
    public List<Product> CartProducts { get; private set; }

    public float Money { get; private set; }

    public List<Product> Products => CartProducts;

    public Cart()
    {
        CartProducts = new List<Product>();
        Money = TotalCost();
    }

    public float TotalCost()
    {
        float totalCost = 0;
        foreach (var item in CartProducts)
        {
            totalCost += item.ProductPrice * item.ProductCount;
        }
        return totalCost;
    }

}

public class Product
{
    public string ProductName { get; private set; }
    public float ProductCount { get; private set; }
    public float ProductPrice { get; private set; }
    public bool IsPieceProduct { get; private set; }

    public Product(string productName, float weight, float productPrice, bool isPieceProduct)
    {
        ProductName = productName;
        ProductCount = weight;
        ProductPrice = productPrice;
        IsPieceProduct = isPieceProduct;
    }

    public void UpdateCount(float newCount)
    {
        ProductCount = newCount;
    }

    public string ProductShowInf(IMoneyHolder owner)
    {
        string unit = IsPieceProduct ? "pcs" : "kg";
        string priceUnit = IsPieceProduct ? "piece" : "kg";
        string productDetails = $"Product: {ProductName}, ";

        productDetails += IsPieceProduct
            ? $"Quantity: {ProductCount} {unit}"
            : $"Weight: {ProductCount} {unit}";

        if (owner is Seller)
        {
            productDetails += $" | Price per {priceUnit}: {ProductPrice}$";
        }

        return productDetails;
    }
}
