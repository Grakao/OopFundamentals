namespace Inheritance;

public class Manager : Employee
{
    public Manager(string name, string department, int teamSize) : base(name, department)
    {
        TeamSize = teamSize;
    }

    public int TeamSize { get; }

    public void RunMeeting()
    {
        Console.WriteLine($"{Name} runs a meeting with {TeamSize} people.");
    }
}