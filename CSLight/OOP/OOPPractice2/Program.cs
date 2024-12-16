namespace OOPPractice2;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("Jhon");
        User user2 = new User("James");
        List list = new List(new Task[] { new Task(user1, "Buy a milk."), new Task(user2, "Cook a dinner.") });

        list.ShowAllTasks();
        Console.ReadKey();
    }

    class User
    {
        public string Name;

        public User(string name)
        {
            Name = name;
        }
    }

    class List
    {
        public Task[] Tasks;

        public List(Task[] tasks)
        {
            Tasks = tasks;
        }

        public void ShowAllTasks()
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                Tasks[i].ShowInfo();
            }
        }
    }

    class Task
    {
        public User Worker;
        public string Description;


        public Task(User worker, string description)
        {
            Worker = worker;
            Description = description;
        }

        public void ShowInfo()
        {
            System.Console.WriteLine($"Acting person {Worker.Name}\nTask description: {Description}");
        }
    }
}
