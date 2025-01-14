using System.ComponentModel;

namespace OopHWFourthTask;

class Program
{
    static void Main(string[] args)
    {

        bool storeIsOpen = true;
        Seller seller = new Seller(1000);
        Customer customer = new Customer(1200);
        Cart cart = new Cart();
        while (storeIsOpen)
        {
            Console.SetCursorPosition(5, 0);
            Console.Write("Welcome to our store. You can see a list of our goods at the right. Add goods into the cart and then buy them!");
            Console.SetCursorPosition(55, 1);
            Console.Write("Store assortment");
            Console.SetCursorPosition(55, 2);
            Console.Write("_________________________________________________________________");
            seller.ShowProducts(seller.SellerProducts, seller, 55, 3);
            Console.SetCursorPosition(0, 1);
            Console.Write("Enter 1 to add any product to your cart and than enter 2 to buy that products.");
            customer.ShowProducts(customer.CustomerProducts, customer, 0, 5);
            switch (Console.ReadLine())
            {
                case "1":

                    break;
                case "2":

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
        Money = money;
    }

    public void ShowProducts(List<Product> products, Seller seller, int columnNum, int row)
    {
        foreach (Product item in products)
        {
            Console.SetCursorPosition(columnNum, row);
            item.ProductShowInf(seller);
            Console.WriteLine();
            row++;
        }
    }

    public void Availability()
    {
        for (int i = SellerProducts.Count - 1; i >= 0; i--)
        {
            if (SellerProducts[i].ProductCount == 0)
            {
                SellerProducts.RemoveAt(i);
            }
        }
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

    public void BuyProductsFromCart(List<Product> productsFromCart)
    {
        CustomerProducts.AddRange(productsFromCart);
    }

    public void SearchForDuplicate(List<Product> customerProducts)
    {
        for (int i = 0; i < customerProducts.Count; i++)
        {
            string productToCompare = customerProducts[i].ProductName;

            for (int j = i + 1; j < customerProducts.Count; j++)
            {
                if (customerProducts[j].ProductName == productToCompare)
                {
                    customerProducts[i].UpdateCount(customerProducts[i].ProductCount + customerProducts[j].ProductCount);

                    customerProducts.RemoveAt(j);

                    j--;
                }
            }
        }
    }

    public void ShowProducts(List<Product> products, Customer customer, int columnNum, int row)
    {
        foreach (Product item in products)
        {
            Console.SetCursorPosition(columnNum, row);
            item.ProductShowInf(customer);
            Console.WriteLine();
            row++;
        }
    }
}

class Cart
{
    public List<Product> ProductsInCart { get; private set; }

    public Cart()
    {
        ProductsInCart = new List<Product>();
    }

    public void AddProductToCart(List<Product> products, string productName, float amount)
    {
        int productIndex = DetectProductIndex(products, productName);
        Product product = products[productIndex];

        if (amount <= product.ProductCount && product.IsPieceProduct)
        {
            product.UpdateCount(product.ProductCount - amount);
            var productForCart = new Product(product.ProductName, amount, product.ProductPrice, true);
            ProductsInCart.Add(productForCart);
        }

        if (amount <= product.ProductCount && !product.IsPieceProduct)
        {
            if (amount % 1 != 0)
            {
                Console.WriteLine("Please enter valid amount.");
            }
            product.UpdateCount(product.ProductCount - amount);
            var productForCart = new Product(product.ProductName, amount, product.ProductPrice, false);
            ProductsInCart.Add(productForCart);
        }
    }

    public float TotalCost()
    {
        float totalCost = 0;
        foreach (var item in ProductsInCart)
        {
            totalCost += item.ProductPrice;
        }
        return totalCost;
    }

    public void ShowProducts(Customer customer)
    {
        foreach (var item in ProductsInCart)
        {
            item.ProductShowInf(customer);
            Console.WriteLine();
        }
    }

    private int DetectProductIndex(List<Product> products, string productName)
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
}

class Product
{
    public string ProductName { get; private set; }
    public float ProductCount { get; private set; }
    public float ProductPrice { get; private set; }
    public bool IsPieceProduct { get; private set; }
    public void UpdateCount(float newCount)
    {
        ProductCount = newCount;
    }

    public Product(string productName, float weight, float productPrice, bool isPieceProduct)
    {
        ProductName = productName;
        ProductCount = weight;
        ProductPrice = productPrice;
        IsPieceProduct = isPieceProduct;
    }

    public void ProductShowInf(object person)
    {
        string unit = IsPieceProduct ? "pcs" : "kg";
        string productDetails = $"Product: {ProductName}, Weight: {ProductCount} {unit}";

        if (person is Seller)
        {
            productDetails += $", Price: {ProductPrice}";
        }

        Console.Write(productDetails);
    }


}
