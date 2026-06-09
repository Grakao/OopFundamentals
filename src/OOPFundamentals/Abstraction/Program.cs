namespace Abstraction;

class Program
{
    static void Main(string[] args)
    {
        var coffeeMachine = new CoffeeMachine();

        // Main does not care how the coffee is done. That is abstraction.
        // The implementation details are hidden from the caller.
        coffeeMachine.MakeEspresso();
        coffeeMachine.MakeLatte();
    }
}