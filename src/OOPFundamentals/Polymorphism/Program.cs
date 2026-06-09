namespace Polymorphism;

class Program
{
    static void Main(string[] args)
    {
        // Same method with different parameter types. This is Polymorphism.
        Print(100);
        Print("Hello");
        Print(99.90m);
    }

    static void Print(int value)
    {
        Console.WriteLine($"Integer value: {value}");
    }

    static void Print(string value)
    {
        Console.WriteLine($"Text value: {value}");
    }

    static void Print(decimal value)
    {
        Console.WriteLine($"Money value: {value:F2}");
    }
}
