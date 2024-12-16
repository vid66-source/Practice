namespace OOPPractice3;

class Program
{
    static void Main(string[] args)
    {
        Knight knight = new Knight(100, 50);
        Barbarian barbarian = new Barbarian(100, 1, 20, 2);

        barbarian.TakeDamage(500);
        knight.TakeDamage(120);

        barbarian.ShowInfo();
        knight.ShowInfo();
        Console.ReadKey();
    }

    class Warrior
    {
        protected int Health;
        protected int Armor;
        protected int Damage;

        public Warrior(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void ShowInfo()
        {
            System.Console.WriteLine($"{Health}");
        }
    }

    class Knight : Warrior
    {
        public Knight(int health, int damage) : base(health, 5, damage) { }

        public void Pray()
        {
            Armor += 2;
        }
    }

    class Barbarian : Warrior
    {

        public Barbarian(int health, int armor, int damage, int attackSpeed) : base(health, armor, damage * attackSpeed) { }

        public void Waagh()
        {
            Armor -= 2;
            Health += 10;
        }
    }
}
