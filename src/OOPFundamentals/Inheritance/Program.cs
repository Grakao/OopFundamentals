namespace Inheritance;

class Program
{
    static void Main(string[] args)
    {
        // developer and manager inherit shared data and behavior from employee, and add their specific methods.
        var developer = new Developer("Ana", "Engineering", "C#");
        var manager = new Manager("Carlos", "Engineering", 5);

        developer.PrintInfo();
        developer.WriteCode();

        Console.WriteLine();

        manager.PrintInfo();
        manager.RunMeeting();
    }
}