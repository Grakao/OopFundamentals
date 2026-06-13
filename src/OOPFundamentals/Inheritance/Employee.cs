namespace Inheritance;

public class Employee
{
    public Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }

    public string Name { get; }

    public string Department { get; }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} works in {Department}.");
    }
}