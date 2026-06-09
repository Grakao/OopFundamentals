namespace Inheritance;

public class Developer : Employee
{
    public Developer(string name, string department, string programmingLanguage) : base(name, department)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public string ProgrammingLanguage { get; }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} writes {ProgrammingLanguage} code.");
    }
}