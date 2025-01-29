using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace OopHWFourthTask;

public static class WinUIManager
{
    public static int ScreenWidth, ScreenHeight;
    static WinUIManager()
    {
        ScreenWidth = Console.LargestWindowWidth;
        ScreenHeight = Console.LargestWindowHeight;
    }

    public static void WindowSizeOption(float screenShrinkRatioWidth, float screenShrinkRatioHight)
    {

        Console.SetWindowSize((int)(ScreenWidth * screenShrinkRatioWidth), (int)(ScreenHeight * screenShrinkRatioHight));
        Console.SetBufferSize((int)(ScreenWidth * screenShrinkRatioWidth), (int)(ScreenHeight * screenShrinkRatioHight));
    }

    public static void UIElementHeadder(float xOffset, int yOffset)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        Console.WriteLine("Welcome to our store. You can see a list of our goods at the right. Add goods into the cart and then buy them!");
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset + 1);
        Console.WriteLine("______________________________________________________________________________________________________________");

    }

    public static void UIElementMenu(float xOffset, int yOffset)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        Console.Write("Menu:");
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset + 1);
        Console.Write("1)Add any product to your cart.");
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset + 2);
        Console.Write("2)Purchase products in your cart.");
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset + 3);
        Console.Write("Please choose your option");
    }

    public static void UIElementListHeadder(float xOffset, int yOffset, string text)
    {

        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        Console.Write(text);
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset + 1);
        Console.Write("_________________________________________________________");
    }

    public static void SetCursorWithScreenOffset(float xOffset, int yOffset)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
    }
    public static void SetCursorWithScreenOffset(float xOffset, int yOffset, string text)
    {
        Console.SetCursorPosition((int)(ScreenWidth * xOffset), yOffset);
        Console.Write(text);
    }
}

public static class ProductManager
{
    public static void RelocateProduct(List<Product> productsList1, List<Product> productslList2, string productName, float amount)
    {
        int productIndex = DetectProductIndex(productsList1, productName);
        Product product = productsList1[productIndex];

        if (amount <= product.ProductCount && product.IsPieceProduct)
        {
            product.UpdateCount(product.ProductCount - amount);
            var productForCart = new Product(product.ProductName, amount, product.ProductPrice, true);
            productslList2.Add(productForCart);
        }

        if (amount <= product.ProductCount && !product.IsPieceProduct)
        {
            if (amount % 1 != 0)
            {
                Console.WriteLine("Please enter valid amount.");
            }
            product.UpdateCount(product.ProductCount - amount);
            var productForCart = new Product(product.ProductName, amount, product.ProductPrice, false);
            productslList2.Add(productForCart);
        }
        else if (amount > product.ProductCount)
        {
            string weightOrPiece = product.IsPieceProduct ? "quantity" : "weight";
            Console.WriteLine($"There is not enough product, please enter a different {weightOrPiece}.");
        }
    }


    public static int DetectProductIndex(List<Product> products, string productName)
    {
        int productIndex = 0;
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductName == productName)
            {
                productIndex = i;
                break;
            }
        }
        return productIndex;
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

    public static void ShowProductsList<T>(float storePosX, int storePosY, List<Product> products, T owner) where T : class
    {
        foreach (var item in products)
        {
            WinUIManager.SetCursorWithScreenOffset(storePosX, storePosY, item.ProductShowInf(owner));
            storePosY++;
        }
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
        Seller seller = new Seller(10000);
        Customer customer = new Customer(1200);
        Cart cart = new Cart();

        //UI design

        if (OperatingSystem.IsWindows())
        {
            WinUIManager.WindowSizeOption(0.8f, 0.8f);
        }
        else
        {
            int screenWidth = 100;
            int screenHeight = 100;
        }

        while (storeIsOpen)
        {
            //Headder
            WinUIManager.UIElementHeadder(0.1f, 0);
            //Menu
            WinUIManager.UIElementMenu(0.1f, 2);
            //Customer
            WinUIManager.UIElementListHeadder(0.1f, seller.SellerProducts.Count + 5, "Your Purchases:");
            ProductManager.ShowProductsList(0.4f, 4, customer.CustomerProducts, customer);
            //Store
            WinUIManager.UIElementListHeadder(0.5f, 2, "Store assortment:");
            ProductManager.ShowProductsList(0.5f, 4, seller.SellerProducts, seller);
            float sellerMoneyNum = seller.Money;
            string sellerMoneyNumTxt = string.Format("{0:F2}", sellerMoneyNumTxt);
            //Cart
            WinUIManager.UIElementListHeadder(0.5f, seller.SellerProducts.Count + 5, "Your Cart:");
            ProductManager.ShowProductsList(0.5f, seller.SellerProducts.Count + 7, cart.CartProducts, cart);
            float cartProductsSum = cart.CartProducts.Count > 0 ? cart.TotalCost() : 0;
            string cartProductsSumTxt = string.Format("{0:F2}", cartProductsSum);
            WinUIManager.SetCursorWithScreenOffset(0.5f, seller.SellerProducts.Count + 7 + cart.CartProducts.Count);
            Console.Write("Total cost: " + cartProductsSumTxt + "$");
            WinUIManager.SetCursorWithScreenOffset(0.1f, 6);

            switch (Console.ReadLine())
            {
                case "1":
                    WinUIManager.SetCursorWithScreenOffset(0.1f, 7);
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();
                    string weightText = seller.SellerProducts[ProductManager.DetectProductIndex(seller.SellerProducts, productName)].IsPieceProduct ? "quantity" : "weight";
                    WinUIManager.SetCursorWithScreenOffset(0.1f, 8);
                    Console.Write($"Enter the {weightText} of the product you wish to purchase: ");
                    string amount = Console.ReadLine();
                    ProductManager.RelocateProduct(seller.SellerProducts, cart.CartProducts, productName, float.Parse(amount));
                    ProductManager.Availability(seller.SellerProducts);
                    ProductManager.SearchForDuplicate(cart.CartProducts);
                    Console.Clear();
                    break;
                case "2":
                    float customerMoney = customer.Money;
                    float cartTotalCost = cart.TotalCost();
                    if (cartTotalCost <= customerMoney)
                    {
                        customer.PayMoney(cart.TotalCost());
                        ProductManager.AddProductsToList(customer.CustomerProducts, cart.CartProducts);
                        ProductManager.SearchForDuplicate(customer.CustomerProducts);
                        cart.CartProducts.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money.");
                    }

                    break;
                default:
                    Console.WriteLine("Choose an option");
                    break;
            }
        }
    }
}

class Seller
{
    public List<Product> SellerProducts { get; private set; }
    public float Money { get; private set; }

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

class Customer
{
    public List<Product> CustomerProducts { get; private set; }
    public float Money { get; private set; }
    public Customer(float money)

    {
        CustomerProducts = new List<Product> { };
        Money = money;
    }

    public void PayMoney(float productsPrice)
    {
        Money -= productsPrice;
    }
}

class Cart
{
    public List<Product> CartProducts { get; private set; }

    public Cart()
    {
        CartProducts = new List<Product>();
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

    public string ProductShowInf(object owner)
    {
        string unit = IsPieceProduct ? "pcs" : "kg";
        string productDetails = $"Product: {ProductName}, ";

        if (IsPieceProduct)
        {
            productDetails += $"Quantity: {ProductCount} {unit}";
        }
        else
        {
            productDetails += $"Weight: {ProductCount} {unit}";
        }

        if (owner is Seller)
        {
            productDetails += $", Price: {ProductPrice}$";
        }

        return productDetails;
    }

}
