namespace UserClass;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("Alex", 18, "Slovenia", "alexalex2006@yahoo.com", "+38649659161");
        user1.ShowInfo();
        Console.ReadKey();
    }
}

class User
{
    private string _name;
    private int _age;
    private string _country;
    private string _email;
    private string _phone;

    public User(string name, int age, string country, string email, string phone)
    {
        _name = name;
        _age = age;
        _country = country;
        _email = email;
        _phone = phone;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"User's name: {_name}.\nUser's age: {_age}.\nUser's country: {_country}.\nUser's email: {_email}.\nUser's phone: {_phone}.");
    }
}
